import { useState } from "react";
import FetchPeachApi from "../../../FetchPeachApi.jsx";
import { API_ENDPOINTS } from "../../../../../utils/constants.js";

const ACTIVITY_ENDPOINT = API_ENDPOINTS.activities;

export default function FetchDeleteActivity() {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState("");
  const [okMessage, setOkMessage] = useState("");

  const deleteActivity = async (id) => {
    setLoading(true);
    setError("");
    setOkMessage("");
    try {
      await FetchPeachApi(`${ACTIVITY_ENDPOINT}/${Number(id)}`, {
        method: "DELETE",
      });
      setOkMessage("Aktivitet raderad!");
    } catch (e) {
      setError(e.message || "Kunde inte radera aktiviteten.");
      throw e;
    } finally {
      setLoading(false);
    }
  };

  return { deleteActivity, loading, error, okMessage };
}

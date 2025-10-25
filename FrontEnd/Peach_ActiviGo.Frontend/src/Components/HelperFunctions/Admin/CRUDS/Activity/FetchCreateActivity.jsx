import { useState } from "react";
import FetchPeachApi from "../../../FetchPeachApi.jsx";
import { API_ENDPOINTS } from "../../../../../utils/constants.js";

const ACTIVITY_ENDPOINT = API_ENDPOINTS.activities;

export default function FetchCreateActivity() {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState("");
  const [okMessage, setOkMessage] = useState("");

  const createActivity = async (payload) => {
    setLoading(true);
    setError("");
    setOkMessage("");
    try {
      await FetchPeachApi(ACTIVITY_ENDPOINT, {
        method: "POST",
        data: payload,
      });
      setOkMessage("Aktivitet skapad!");
    } catch (e) {
      setError(e.message || "Kunde inte skapa aktiviteten.");
      throw e;
    } finally {
      setLoading(false);
    }
  };

  return { createActivity, loading, error, okMessage };
}

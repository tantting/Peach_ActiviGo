import { useState } from "react";
import FetchPeachApi from "../../../FetchPeachApi.jsx";
import { API_ENDPOINTS } from "../../../../../utils/constants.js";

const ACTIVITY_SLOT_ENDPOINT = API_ENDPOINTS.activitySlots;

export default function FetchDeleteActivitySlot() {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState("");
  const [okMessage, setOkMessage] = useState("");

  const deleteActivitySlot = async (id) => {
    setLoading(true);
    setError("");
    setOkMessage("");
    try {
      await FetchPeachApi(`${ACTIVITY_SLOT_ENDPOINT}/${id}`, {
        method: "DELETE",
      });
      setOkMessage("Aktivitetstillfälle raderat!");
    } catch (e) {
      setError(e.message || "Kunde inte radera aktivitetstillfället.");
      throw e;
    } finally {
      setLoading(false);
    }
  };

  return { deleteActivitySlot, loading, error, okMessage };
}

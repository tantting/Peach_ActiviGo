import { useState } from "react";
import FetchPeachApi from "../../../FetchPeachApi.jsx";
import { API_ENDPOINTS } from "../../../../../utils/constants.js";

const ACTIVITY_SLOT_ENDPOINT = API_ENDPOINTS.activitySlots;

export default function FetchCreateActivitySlot() {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState("");
  const [okMessage, setOkMessage] = useState("");

  const createActivitySlot = async (payload) => {
    setLoading(true);
    setError("");
    setOkMessage("");
    try {
      await FetchPeachApi(ACTIVITY_SLOT_ENDPOINT, {
        method: "POST",
        data: payload,
      });
      setOkMessage("Aktivitetstillfälle skapat!");
    } catch (e) {
      setError(e.message || "Kunde inte skapa aktivitetstillfället.");
      throw e;
    } finally {
      setLoading(false);
    }
  };

  return { createActivitySlot, loading, error, okMessage };
}

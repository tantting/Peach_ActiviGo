import { useState } from "react";
import FetchPeachApi from "../../../FetchPeachApi.jsx";
import { API_ENDPOINTS } from "../../../../../utils/constants.js";

const ACTIVITY_SLOT_ENDPOINT = API_ENDPOINTS.activitySlots;

export default function FetchUpdateActivitySlot() {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState("");
  const [okMessage, setOkMessage] = useState("");
  const [data, setData] = useState(null); // senast hämtat aktivitetstillfälle

  const reset = () => {
    setError("");
    setOkMessage("");
  };

  // GET /api/ActivitySlots/{id}
  const fetchById = async (id) => {
    setLoading(true);
    reset();
    try {
      const res = await FetchPeachApi(`${ACTIVITY_SLOT_ENDPOINT}/${id}`, {
        method: "GET",
      });
      setData(res);
      return res;
    } catch (e) {
      setError(e.message || "Kunde inte hämta aktivitetstillfälle.");
      setData(null);
      throw e;
    } finally {
      setLoading(false);
    }
  };

  // PUT /api/ActivitySlots/{id}
  const updateActivitySlot = async (id, payload) => {
    setLoading(true);
    reset();
    try {
      await FetchPeachApi(`${ACTIVITY_SLOT_ENDPOINT}/${id}`, {
        method: "PUT",
        data: payload,
      });
      setOkMessage("Aktivitetstillfälle uppdaterat!");
    } catch (e) {
      setError(e.message || "Kunde inte uppdatera aktivitetstillfället.");
      throw e;
    } finally {
      setLoading(false);
    }
  };

  return {
    fetchById,
    updateActivitySlot,
    loading,
    error,
    okMessage,
    data,
    reset,
  };
}

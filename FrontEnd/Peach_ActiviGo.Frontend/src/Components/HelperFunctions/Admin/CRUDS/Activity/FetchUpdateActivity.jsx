import { useState } from "react";
import FetchPeachApi from "../../../FetchPeachApi.jsx";
import { API_ENDPOINTS } from "../../../../../utils/constants.js";

const ACTIVITY_ENDPOINT = API_ENDPOINTS.activities;

export default function FetchUpdateActivity() {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState("");
  const [okMessage, setOkMessage] = useState("");
  const [data, setData] = useState(null); // senast hämtad aktivitet

  const reset = () => {
    setError("");
    setOkMessage("");
  };

  // GET /api/activities/{id}
  const fetchById = async (id) => {
    setLoading(true);
    reset();
    try {
      const res = await FetchPeachApi(`${ACTIVITY_ENDPOINT}/${id}`, {
        method: "GET",
      });
      setData(res);
      return res;
    } catch (e) {
      setError(e.message || "Kunde inte hämta aktivitet.");
      setData(null);
      throw e;
    } finally {
      setLoading(false);
    }
  };

  // PUT /api/activities/{id}
  const updateActivity = async (id, payload) => {
    setLoading(true);
    reset();
    try {
      await FetchPeachApi(`${ACTIVITY_ENDPOINT}/${id}`, {
        method: "PUT",
        data: payload,
      });
      setOkMessage("Aktivitet uppdaterad!");
    } catch (e) {
      setError(e.message || "Kunde inte uppdatera aktiviteten.");
      throw e;
    } finally {
      setLoading(false);
    }
  };

  return { fetchById, updateActivity, loading, error, okMessage, data, reset };
}

import { useState, useEffect } from "react";
import FetchPeachApi from "../../../FetchPeachApi.jsx";
import { API_ENDPOINTS } from "../../../../../utils/constants.js";

const ACTIVITY_SLOT_ENDPOINT = API_ENDPOINTS.activitySlots;

export default function FetchAllActivitySlots() {
  const [activitySlots, setActivitySlots] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  const loadAll = async () => {
    setLoading(true);
    setError(null);
    try {
      const data = await FetchPeachApi(ACTIVITY_SLOT_ENDPOINT, {
        method: "GET",
      });
      console.log(data);
      setActivitySlots(Array.isArray(data) ? data : []);
    } catch (e) {
      setError(e.message || "Kunde inte hämta aktivitetstillfällen");
      setActivitySlots([]);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    loadAll();
  }, []);

  // Returnera data som en custom hook
  return { activitySlots, loading, error, loadAll };
}

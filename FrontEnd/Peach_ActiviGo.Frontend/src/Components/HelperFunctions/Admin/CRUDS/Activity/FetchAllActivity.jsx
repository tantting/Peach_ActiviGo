import { useState, useEffect } from "react";
import FetchPeachApi from "../../../FetchPeachApi.jsx";
import { API_ENDPOINTS } from "../../../../../utils/constants.js";

const ACTIVITY_ENDPOINT = API_ENDPOINTS.activities;

export default function FetchAllActivity() {
  const [activity, setActivity] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  const loadAll = async () => {
    setLoading(true);
    setError(null);
    try {
      const data = await FetchPeachApi(ACTIVITY_ENDPOINT, {
        method: "GET",
      });
      setActivity(Array.isArray(data) ? data : []);
    } catch (e) {
      setError(e.message || "Kunde inte hämta aktiviteter");
      setActivity([]);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    loadAll();
  }, []);

  // Returnera data som en custom hook
  return { activity, loading, error, loadAll };
}

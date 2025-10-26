import { useState, useEffect } from "react";
import FetchPeachApi from "../../../FetchPeachApi.jsx";
import { API_ENDPOINTS } from "../../../../../utils/constants.js";

const LOCATION_ENDPOINT = API_ENDPOINTS.locations;

export default function FetchAllLocations() {
  const [locations, setLocations] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  const loadAll = async () => {
    setLoading(true);
    setError(null);
    try {
      const data = await FetchPeachApi(LOCATION_ENDPOINT, { method: "GET" });
      setLocations(Array.isArray(data) ? data : []);
    } catch (e) {
      setError(e.message || "Kunde inte hämta platser");
      setLocations([]);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    loadAll();
  }, []);

  // Returnera data som en custom hook
  return { locations, loading, error, loadAll };
}

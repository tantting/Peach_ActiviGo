import { useState, useEffect } from "react";
import FetchPeachApi from "../../../FetchPeachApi.jsx";

const ACTIVITYLOCATION_ENDPOINT =
  "/api/ActivityLocation/GetAllActivityLocations";

export default function FetchAllActivityLocations() {
  const [activityLocations, setActivityLocations] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  const loadAll = async () => {
    setLoading(true);
    setError(null);
    try {
      const data = await FetchPeachApi(ACTIVITYLOCATION_ENDPOINT, {
        method: "GET",
      });
      setActivityLocations(Array.isArray(data) ? data : []);
    } catch (e) {
      setError(e.message || "Kunde inte hämta aktivitet-platser");
      setActivityLocations([]);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    loadAll();
  }, []);

  return { activityLocations, loading, error, loadAll };
}

import { useState, useEffect } from "react";
import FetchPeachApi from "./FetchPeachApi.jsx";

const FetchActivityLocations = () => {
  const [activityLocations, setActivityLocations] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const apiCall = () => {
      setLoading(true);
      FetchPeachApi("/api/ActivityLocation/GetAllActivityLocations")
        .then((data) => {
          setActivityLocations(data);
        })
        .catch((error) => {
          setError(error.message);
          setActivityLocations([]);
        })
        .finally(() => {
          setLoading(false);
        });
    };

    apiCall();
  }, []);

  // Returnera data som en custom hook som sen används i ActivityView.jsx
  return { activityLocations, loading, error };
};

export default FetchActivityLocations;

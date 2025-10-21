import { useState, useEffect } from "react";
import FetchPeachApi from "./FetchPeachApi.jsx";

const FetchActivitySlots = (activityLocationId = null) => {
  const [ActivitySlots, setActivitySlots] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const apiCall = () => {
      setLoading(true);
      FetchPeachApi("/api/ActivitySlots")
        .then((data) => {
            const filteredData = activityLocationId
            ? data.filter(
                (slot) => slot.activityLocationId === activityLocationId
            )
            : data;
            console.log("Fetched Activity Slots:", data);

          setActivitySlots(filteredData);
        })
        .catch((error) => {
          setError(error.message);
          setActivitySlots([]);
        })
        .finally(() => {
          setLoading(false);
        });
    };

    apiCall();
  }, [activityLocationId]);

  // Returnera data som en custom hook
  return { ActivitySlots, loading, error };
};

export default FetchActivitySlots;

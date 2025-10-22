import { useState, useEffect } from "react";
import FetchPeachApi from "./FetchPeachApi";

export default function FetchActivityDetail(
  id,
  initialActivityLocation = null
) {
  const [activityLocation, setActivityLocation] = useState(
    initialActivityLocation
  );
  const [loading, setLoading] = useState(!initialActivityLocation);
  const [error, setError] = useState(null);

  useEffect(() => {
    if (activityLocation) return; // Om vi redan har data, gör inget

    const fetchActivityDetail = async () => {
      try {
        setLoading(true);
        setError(null);
        const data = await FetchPeachApi(
          `/api/ActivityLocation/GetActivityLocationById/${id}`
        );
        setActivityLocation(data);
      } catch (err) {
        setError(err.message);
      } finally {
        setLoading(false);
      }
    };

    if (id) {
      fetchActivityDetail();
    } else {
      setError("Inget aktivitets-ID hittades");
      setLoading(false);
    }
  }, [id, activityLocation]);

  return { activityLocation, loading, error };
}

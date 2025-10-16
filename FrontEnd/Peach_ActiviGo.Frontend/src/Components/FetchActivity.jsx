import { useState, useEffect } from 'react'
import FetchPeachApi from './HelperFunctions/FetchPeachApi.jsx'

const FetchActivity = () => {
  const [activities, setActivities] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const apiCall = () => {
      setLoading(true);
      FetchPeachApi('/api/ActivityLocation/GetAllActivityLocations')
        .then((data) => {
          setActivities(data);
        })
        .catch((error) => {
          setError(error.message);
          setActivities([]);
        })
        .finally(() => {
          setLoading(false);
        });
    };

    apiCall();
  }, []);

  // Returnera data som en custom hook som sen används i ActivityView.jsx
  return { activities, loading, error };
};

export default FetchActivity
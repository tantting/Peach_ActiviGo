import { useState, useEffect } from 'react'
/*https://dev.to/paperbyte/async-await-vs-fetchthen-20oe*/
const API_BASE_URL = "https://localhost:7242";
const API_Endpoint = "";

const FetchActivity = () => {
  const [activities, setActivities] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const apiCall = () => {
      setLoading(true);
      
      fetch(`${API_BASE_URL}/api/ActivityLocation/GetAllActivityLocations`)
        .then((response) => response.json())
        .then((data) => {
          console.log('Fetched activities:', data);
          setActivities(data);
        })
        .catch((error) => {
          console.error('Error:', error);
          setError(error.message);
          setActivities([]);
        })
        .finally(() => {
          setLoading(false);
        });
    };

    apiCall();
  }, []);

  // Returnera data som en custom hook som sen används i Aktiviteter.jsx
  return { activities, loading, error };
};

export default FetchActivity
import { useState, useEffect } from "react";
import FetchPeachApi from "./FetchPeachApi.jsx";

const FetchBookings = () => {
  const [bookings, setBookings] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const apiCall = () => {
      setLoading(true);
      FetchPeachApi("/api/Booking")
        .then((data) => {
          setBookings(data || []);
        })
        .catch((error) => {
          setError(error.message);
          setBookings([]);
        })
        .finally(() => {
          setLoading(false);
        });
    };

    apiCall();
  }, []);

  // Returnera data som en custom hook som sen används i BookingsView.jsx
  return { bookings, loading, error };
};

export default FetchBookings;

import React from "react";
import { useState, useEffect } from "react";
import FetchContent from "../Components/HelperFunctions/FetchContent";
import "../Styles/BookingStatistics.css";

export default function BookingStatistics() {
  const [adminStats, setAdminStats] = useState([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);

  const fetchStat = async () => {
    setLoading(true);
    try {
      const data = await FetchContent("/api/Booking/statistics");
      setAdminStats(data || []);
    } catch (err) {
      setError("Kunde inte hämta statistik");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchStat();
  }, []);

  return (
    <div className="page-container">
      <h2>Bokningsstatistik</h2>
      <div className="div-container">
        {/* Översikt */}
        <div className="statDiv">
          <h3>Översikt</h3>
          <ul>
            {Object.entries(adminStats || {})
              .filter(([key, value]) => key !== "totalBookingsPerActivity") // filtrera bort nested objektet
              .map(([heading, value]) => (
                <li key={heading}>
                  {heading}: {value}
                </li>
              ))}
          </ul>
        </div>

        <div className="statDiv">
          <h3>Totalt antal bokningar per aktivitet</h3>
          <ul>
            {Object.entries(adminStats.totalBookingsPerActivity || {}).map(
              ([activity, count]) => (
                <li key={activity}>
                  {activity}: {count}
                </li>
              )
            )}
          </ul>
        </div>
      </div>
      <div className="button-container">
        <button onClick={fetchStat} disabled={loading}>
          {loading ? "Uppdaterar..." : "Uppdatera statistik"}
        </button>

        {error && <p className="error-message">{error}</p>}
      </div>
    </div>
  );
}

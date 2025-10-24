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

  const headingsMap = {
    totalBookingsThisMonth: "Totalt bokningar denna månad",
    totalBookingsThisWeek: "Totalt bokningar denna vecka",
    mostPopularActivity: "Mest populära aktivitet",
    topCustomer: "Toppkund",
    totalRevenue: "Total intäkt",
    activeBookings: "Aktiva bokningar",
    canceledBookings: "Avbokade bokningar",
  };

  return (
    <div className="page-container">
      <h1>Statistik</h1>
      <div className="stat-table-container">
        <h2>Översikt</h2>
        <table className="stat-table">
          <tbody>
            {Object.entries(adminStats || {})
              .filter(([key]) => key !== "totalBookingsPerActivity")
              .map(([heading, value]) => (
                <tr key={heading}>
                  <td className="stat-heading">
                    {headingsMap[heading] || heading}
                  </td>
                  <td className="stat-value">{value}</td>
                </tr>
              ))}
          </tbody>
        </table>
      </div>

      <div className="stat-table-container">
        <h2>Totalt antal bokningar per aktivitet</h2>
        <table className="stat-table">
          <tbody>
            {Object.entries(adminStats.totalBookingsPerActivity || {}).map(
              ([activity, count]) => (
                <tr key={activity}>
                  <td className="stat-heading">{activity}</td>
                  <td className="stat-value">{count}</td>
                </tr>
              )
            )}
          </tbody>
        </table>
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

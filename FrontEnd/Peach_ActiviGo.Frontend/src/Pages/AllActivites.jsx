
import React, { useEffect, useState } from "react";
import FetchContent from "../Components/HelperFunctions/FetchContent";
import "../Styles/BookingStatistics.css"; // återanvänd enkel tabell-stil om du vill

export default function AllActivities({ showTitle = true, containerClassName = "" }) {
  const [activities, setActivities] = useState([]);
  const [loading, setLoading]       = useState(false);
  const [error, setError]           = useState(null);

  const loadAll = async () => {
    setLoading(true);
    setError(null);
    try {
      const data = await FetchContent("/api/activities");
      setActivities(Array.isArray(data) ? data : []);
    } catch (e) {
      setError("Kunde inte hämta aktiviteter");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    loadAll();
  }, []);

  return (
    <div className={`page-container ${containerClassName}`}>
      {showTitle && <h1>Alla aktiviteter</h1>}

      <div className="stat-table-container">
        <h2>Lista</h2>

        {loading && <p>Hämtar…</p>}
        {error && <p className="error-message">{error}</p>}

        {!loading && !error && activities.length === 0 && (
          <p>Ingen data att visa.</p>
        )}

        {activities.length > 0 && (
          <div className="stat-table-wrapper">
            <table className="stat-table">
              <thead>
                <tr>
                  <th>ID</th>
                  <th>Namn</th>
                  <th>Pris</th>
                  <th>Kategori</th>
                  <th>Plats</th>
                </tr>
              </thead>
              <tbody>
                {activities.map((a) => (
                  <tr key={a.id}>
                    <td>{a.id}</td>
                    <td>{a.name}</td>
                    <td>{a.price}</td>
                    <td>{a.categoryName ?? a.categoryId}</td>
                    <td>{a.locationName ?? "-"}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        )}

        <div className="button-container" style={{ marginTop: 12 }}>
          <button onClick={loadAll} disabled={loading}>
            {loading ? "Uppdaterar..." : "Uppdatera lista"}
          </button>
        </div>
      </div>
    </div>
  );
}

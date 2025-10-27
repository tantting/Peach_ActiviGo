import React from "react";
import FetchAllActivityLocations from "../../../../Components/HelperFunctions/Admin/CRUDS/ActivityLocation/FetchAllActivityLocations.jsx";
import "../../../../Styles/BookingStatistics.css";

export default function GetAllActivityLocationsView({
  showTitle = true,
  containerClassName = "",
}) {
  const { activityLocations, loading, error, loadAll } =
    FetchAllActivityLocations();

  return (
    <div className={`page-container ${containerClassName}`}>
      {showTitle && <h1>Alla aktivitet-platser</h1>}

      <div className="stat-table-container">
        <h2>Lista</h2>

        {loading && <p>Hämtar…</p>}
        {error && <p className="error-message">{error}</p>}

        {!loading && !error && activityLocations.length === 0 && (
          <p>Ingen data att visa.</p>
        )}

        {activityLocations.length > 0 && (
          <div className="stat-table-wrapper">
            <table className="stat-table">
              <thead>
                <tr>
                  <th>ID</th>
                  <th>Aktivitet</th>
                  <th>Plats</th>
                  <th>Aktiv</th>
                  <th>Inomhus</th>
                </tr>
              </thead>
              <tbody>
                {activityLocations.map((al) => (
                  <tr key={al.id}>
                    <td>{al.id}</td>
                    <td>{al.activityName ?? al.activityId}</td>
                    <td>{al.locationName ?? al.locationId}</td>
                    <td>{al.isActive ? "Ja" : "Nej"}</td>
                    <td>{al.isIndoor ? "Ja" : "Nej"}</td>
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

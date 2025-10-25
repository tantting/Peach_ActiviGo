import React from "react";
import FetchAllLocations from "../../../../Components/HelperFunctions/Admin/CRUDS/Location/FetchAllLocations.jsx";
import "../../../../Styles/BookingStatistics.css"; // återanvänd enkel tabell-stil

export default function GetAllLocationsView({
  showTitle = true,
  containerClassName = "",
}) {
  const { locations, loading, error, loadAll } = FetchAllLocations();

  return (
    <div className={`page-container ${containerClassName}`}>
      {showTitle && <h1>Alla platser</h1>}

      <div className="stat-table-container">
        <h2>Lista</h2>

        {loading && <p>Hämtar…</p>}
        {error && <p className="error-message">{error}</p>}

        {!loading && !error && locations.length === 0 && (
          <p>Ingen data att visa.</p>
        )}

        {locations.length > 0 && (
          <div className="stat-table-wrapper">
            <table className="stat-table">
              <thead>
                <tr>
                  <th>ID</th>
                  <th>Namn</th>
                  <th>Adress</th>
                  <th>Latitude</th>
                  <th>Longitude</th>
                </tr>
              </thead>
              <tbody>
                {locations.map((location) => (
                  <tr key={location.id}>
                    <td>{location.id}</td>
                    <td>{location.name}</td>
                    <td>{location.address}</td>
                    <td>{location.latitude}</td>
                    <td>{location.longitude}</td>
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

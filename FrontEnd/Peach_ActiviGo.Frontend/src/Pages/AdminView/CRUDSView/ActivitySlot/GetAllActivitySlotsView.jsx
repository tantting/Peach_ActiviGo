import React from "react";
import FetchAllActivitySlots from "../../../../Components/HelperFunctions/Admin/CRUDS/ActivitySlots/FetchAllActivitySlots.jsx";
import "../../../../Styles/BookingStatistics.css"; // återanvänd enkel tabell-stil

export default function GetAllActivitySlotsView({
  showTitle = true,
  containerClassName = "",
}) {
  const { activitySlots, loading, error, loadAll } = FetchAllActivitySlots();

  // Formatera datum och tid för visning
  const formatDateTime = (dateTimeString) => {
    if (!dateTimeString) return "-";
    const date = new Date(dateTimeString);
    return date.toLocaleString("sv-SE");
  };

  return (
    <div className={`page-container ${containerClassName}`}>
      {showTitle && <h1>Alla aktivitetstillfällen</h1>}

      <div className="stat-table-container">
        <h2>Lista</h2>

        {loading && <p>Hämtar…</p>}
        {error && <p className="error-message">{error}</p>}

        {!loading && !error && activitySlots.length === 0 && (
          <p>Ingen data att visa.</p>
        )}

        {activitySlots.length > 0 && (
          <div className="stat-table-wrapper">
            <table className="stat-table">
              <thead>
                <tr>
                  <th>ID</th>
                  <th>Starttid</th>
                  <th>Sluttid</th>
                  <th>ActivityLocation-ID</th>
                  <th>Kapacitet</th>
                  <th>Status</th>
                </tr>
              </thead>
              <tbody>
                {activitySlots.map((slot) => (
                  <tr key={slot.id}>
                    <td>{slot.id}</td>
                    <td>{formatDateTime(slot.startTime)}</td>
                    <td>{formatDateTime(slot.endTime)}</td>
                    <td>{slot.activityLocationId}</td>
                    <td>{slot.slotCapacity}</td>
                    <td>
                      <span
                        style={{
                          color: slot.isCanselled ? "#d32f2f" : "#2e7d32",
                          fontWeight: "bold",
                        }}
                      >
                        {slot.isCanselled ? "Inställt" : "Aktiv"}
                      </span>
                    </td>
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

import React from "react";
import FetchDeleteLocation from "../../../../Components/HelperFunctions/Admin/CRUDS/Location/FetchDeleteLocation.jsx";
import "../../../../Styles/AdminView.css";

export default function DeleteLocationView({
  showTitle = true,
  containerClassName = "",
  onBack,
}) {
  // ⬅️ LOCATION DELETE via hook
  const {
    deleteLocation,
    loading: deleteLocationLoading,
    error: deleteLocationError,
    okMessage: deleteLocationOkMessage,
  } = FetchDeleteLocation();

  return (
    <section className={`action-panel ${containerClassName}`}>
      {showTitle && (
        <div className="panel-header">
          <h2>Radera plats</h2>
          <p>Ange ID och radera platsen.</p>
        </div>
      )}

      {deleteLocationLoading && <p>Raderar…</p>}
      {deleteLocationError && (
        <p className="error-message">{deleteLocationError}</p>
      )}
      {deleteLocationOkMessage && (
        <p style={{ color: "#2e7d32" }}>{deleteLocationOkMessage}</p>
      )}

      <form
        className="panel-form"
        onSubmit={async (e) => {
          e.preventDefault();
          const formData = new FormData(e.target);
          const id = formData.get("locationId");
          if (!id) return;

          const confirmed = window.confirm(
            `Är du säker på att du vill radera plats med ID ${id}?`
          );
          if (!confirmed) return;

          try {
            await deleteLocation(Number(id));
            e.target.reset();
          } catch {
            // felmeddelande visas via deleteLocationError från hooken
          }
        }}
      >
        <div className="form-row inline">
          <div>
            <label>Plats-ID</label>
            <input
              type="number"
              name="locationId"
              placeholder="t.ex. 3"
              min="1"
              required
            />
          </div>
          <div className="panel-actions compact">
            <button
              type="submit"
              className="btn primary"
              disabled={deleteLocationLoading}
            >
              {deleteLocationLoading ? "Raderar…" : "Radera"}
            </button>
            <button type="button" className="btn ghost" onClick={onBack}>
              Tillbaka
            </button>
          </div>
        </div>
      </form>
    </section>
  );
}

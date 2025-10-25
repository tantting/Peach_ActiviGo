import React, { useState } from "react";
import FetchCreateLocation from "../../../../Components/HelperFunctions/Admin/CRUDS/Location/FetchCreateLocation.jsx";
import "../../../../Styles/AdminView.css";

export default function CreateLocationView({
  showTitle = true,
  containerClassName = "",
  onBack,
}) {
  // --- LOCATION CREATE: formulär-state ---
  const [createLocationForm, setCreateLocationForm] = useState({
    name: "",
    address: "",
    latitude: "",
    longitude: "",
  });

  // Koppla in LOCATION CREATE-hooken
  const {
    createLocation,
    loading: createLocationLoading,
    error: createLocationError,
    okMessage: createLocationOkMessage,
  } = FetchCreateLocation();

  // onChange handler
  const onCreateLocationChange = (e) => {
    const { name, value } = e.target;
    setCreateLocationForm((p) => ({ ...p, [name]: value }));
  };

  return (
    <section className={`action-panel ${containerClassName}`}>
      {showTitle && (
        <div className="panel-header">
          <h2>Skapa ny plats</h2>
          <p>Fyll i uppgifterna och spara.</p>
        </div>
      )}

      <form
        className="panel-form"
        onSubmit={async (e) => {
          e.preventDefault();
          const payload = {
            name: createLocationForm.name,
            address: createLocationForm.address,
            latitude: Number(createLocationForm.latitude),
            longitude: Number(createLocationForm.longitude),
          };
          await createLocation(payload);
          setCreateLocationForm({
            name: "",
            address: "",
            latitude: "",
            longitude: "",
          });
        }}
      >
        {createLocationLoading && <p>Skapar plats…</p>}
        {createLocationError && (
          <p style={{ color: "var(--peach-royal)" }}>{createLocationError}</p>
        )}
        {createLocationOkMessage && (
          <p style={{ color: "var(--peach-passion)" }}>
            {createLocationOkMessage}
          </p>
        )}

        <div className="form-row">
          <label>Namn</label>
          <input
            type="text"
            name="name"
            value={createLocationForm.name}
            onChange={onCreateLocationChange}
            required
          />
        </div>

        <div className="form-row">
          <label>Adress</label>
          <input
            type="text"
            name="address"
            value={createLocationForm.address}
            onChange={onCreateLocationChange}
            required
          />
        </div>

        <div className="form-row grid-2">
          <div>
            <label>Latitude</label>
            <input
              type="number"
              name="latitude"
              value={createLocationForm.latitude}
              onChange={onCreateLocationChange}
              step="0.000001"
              required
            />
          </div>
          <div>
            <label>Longitude</label>
            <input
              type="number"
              name="longitude"
              value={createLocationForm.longitude}
              onChange={onCreateLocationChange}
              step="0.000001"
              required
            />
          </div>
        </div>

        <div className="panel-actions">
          <button type="button" className="btn ghost" onClick={onBack}>
            Tillbaka
          </button>
          <button
            type="submit"
            className="btn primary"
            disabled={createLocationLoading}
          >
            {createLocationLoading ? "Sparar…" : "Spara"}
          </button>
        </div>
      </form>
    </section>
  );
}

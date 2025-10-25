import React, { useState } from "react";
import FetchUpdateLocation from "../../../../Components/HelperFunctions/Admin/CRUDS/Location/FetchUpdateLocation.jsx";
import "../../../../Styles/AdminView.css";

export default function UpdateLocationView({
  showTitle = true,
  containerClassName = "",
  onBack,
}) {
  // --- LOCATION UPDATE: sök + formulär-state ---
  const [lookupLocationId, setLookupLocationId] = useState(""); // Location ID att hämta
  const [updateLocationForm, setUpdateLocationForm] = useState({
    id: "",
    name: "",
    address: "",
    latitude: "",
    longitude: "",
  });

  // ⬅️ LOCATION UPDATE via hook
  const {
    fetchById: fetchLocationById,
    updateLocation,
    loading: updateLocationLoading,
    error: updateLocationError,
    okMessage: updateLocationOkMessage,
    reset: resetLocationUpdate,
  } = FetchUpdateLocation();

  // onChange handler
  const onUpdateLocationChange = (e) => {
    const { name, value } = e.target;
    setUpdateLocationForm((p) => ({ ...p, [name]: value }));
  };

  // ⬅️ LOCATION UPDATE via hook — GET
  const handleFetchLocationById = async (e) => {
    e.preventDefault();
    resetLocationUpdate();
    try {
      const data = await fetchLocationById(lookupLocationId);
      setUpdateLocationForm({
        id: data.id,
        name: data.name ?? "",
        address: data.address ?? "",
        latitude: data.latitude ?? "",
        longitude: data.longitude ?? "",
      });
    } catch {
      // felmeddelande visas via updateLocationError från hooken
    }
  };

  // ⬅️ LOCATION UPDATE via hook — PUT
  const submitLocationUpdate = async (e) => {
    e.preventDefault();
    resetLocationUpdate();
    const payload = {
      name: updateLocationForm.name,
      address: updateLocationForm.address,
      latitude: Number(updateLocationForm.latitude),
      longitude: Number(updateLocationForm.longitude),
    };
    try {
      await updateLocation(updateLocationForm.id, payload);
    } catch {
      // felmeddelande visas via updateLocationError från hooken
    }
  };

  return (
    <section className={`action-panel ${containerClassName}`}>
      {showTitle && (
        <div className="panel-header">
          <h2>Uppdatera plats</h2>
          <p>Sök fram en plats och justera fälten.</p>
        </div>
      )}

      {/* Status för update */}
      {updateLocationLoading && <p>Jobbar…</p>}
      {updateLocationError && (
        <p style={{ color: "var(--peach-royal)" }}>{updateLocationError}</p>
      )}
      {updateLocationOkMessage && (
        <p style={{ color: "var(--peach-passion)" }}>
          {updateLocationOkMessage}
        </p>
      )}

      {/* 1) Sökdel (ID + Hämta) */}
      <form className="panel-form" onSubmit={handleFetchLocationById}>
        <div className="form-row inline">
          <div>
            <label>Plats-ID</label>
            <input
              type="number"
              value={lookupLocationId}
              onChange={(e) => setLookupLocationId(e.target.value)}
              placeholder="t.ex. 1"
              min="1"
              required
            />
          </div>
          <div className="panel-actions compact">
            <button
              type="submit"
              className="btn primary"
              disabled={updateLocationLoading}
            >
              {updateLocationLoading ? "Hämtar…" : "Hämta"}
            </button>
            <button type="button" className="btn ghost" onClick={onBack}>
              Tillbaka
            </button>
          </div>
        </div>
      </form>

      {/* 2) Edit-form som visas när vi har data */}
      {updateLocationForm.id && (
        <form className="panel-form" onSubmit={submitLocationUpdate}>
          <div className="form-row grid-2">
            <div>
              <label>ID</label>
              <input type="text" value={updateLocationForm.id} disabled />
            </div>
            <div>
              <label>Namn</label>
              <input
                type="text"
                name="name"
                value={updateLocationForm.name}
                onChange={onUpdateLocationChange}
                required
              />
            </div>
          </div>

          <div className="form-row">
            <label>Adress</label>
            <input
              type="text"
              name="address"
              value={updateLocationForm.address}
              onChange={onUpdateLocationChange}
              required
            />
          </div>

          <div className="form-row grid-2">
            <div>
              <label>Latitude</label>
              <input
                type="number"
                name="latitude"
                value={updateLocationForm.latitude}
                onChange={onUpdateLocationChange}
                step="0.000001"
                required
              />
            </div>
            <div>
              <label>Longitude</label>
              <input
                type="number"
                name="longitude"
                value={updateLocationForm.longitude}
                onChange={onUpdateLocationChange}
                step="0.000001"
                required
              />
            </div>
          </div>

          <div className="panel-actions">
            <button type="button" className="btn ghost" onClick={onBack}>
              Avbryt
            </button>
            <button
              type="submit"
              className="btn primary"
              disabled={updateLocationLoading}
            >
              {updateLocationLoading ? "Sparar…" : "Spara ändringar"}
            </button>
          </div>
        </form>
      )}
    </section>
  );
}

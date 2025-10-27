import React, { useState } from "react";
import FetchUpdateActivitySlot from "../../../../Components/HelperFunctions/Admin/CRUDS/ActivitySlots/FetchUpdateActivitySlot.jsx";
import FetchAllActivityLocations from "../../../../Components/HelperFunctions/Admin/CRUDS/ActivityLocation/FetchAllActivityLocations.jsx";
import "../../../../Styles/AdminView.css";

export default function UpdateActivitySlotView({
  showTitle = true,
  containerClassName = "",
  onBack,
}) {
  // --- ACTIVITY SLOT UPDATE: sök + formulär-state ---
  const [lookupActivitySlotId, setLookupActivitySlotId] = useState(""); // ActivitySlot ID att hämta
  const [updateActivitySlotForm, setUpdateActivitySlotForm] = useState({
    id: "",
    startTime: "",
    endTime: "",
    activityLocationId: "",
    slotCapacity: "",
  });

  // ⬅️ ACTIVITY SLOT UPDATE via hook
  const {
    fetchById: fetchActivitySlotById,
    updateActivitySlot,
    loading: updateActivitySlotLoading,
    error: updateActivitySlotError,
    okMessage: updateActivitySlotOkMessage,
    reset: resetActivitySlotUpdate,
  } = FetchUpdateActivitySlot();

  // onChange handler
  const onUpdateActivitySlotChange = (e) => {
    const { name, value } = e.target;
    setUpdateActivitySlotForm((p) => ({ ...p, [name]: value }));
  };

  // Hämta alla ActivityLocations för dropdown
  const {
    activityLocations,
    loading: activityLocationsLoading,
    error: activityLocationsError,
  } = FetchAllActivityLocations();

  // ⬅️ ACTIVITY SLOT UPDATE via hook — GET
  const handleFetchActivitySlotById = async (e) => {
    e.preventDefault();
    resetActivitySlotUpdate();
    try {
      const data = await fetchActivitySlotById(lookupActivitySlotId);
      // Formatera datetime för HTML datetime-local input
      const formatDateTimeLocal = (dateTime) => {
        if (!dateTime) return "";
        const date = new Date(dateTime);
        return date.toISOString().slice(0, 16); // YYYY-MM-DDTHH:MM
      };

      setUpdateActivitySlotForm({
        id: data.id,
        startTime: formatDateTimeLocal(data.startTime),
        endTime: formatDateTimeLocal(data.endTime),
        activityLocationId: data.activityLocationId ?? "",
        slotCapacity: data.slotCapacity ?? "",
      });
    } catch {
      // felmeddelande visas via updateActivitySlotError från hooken
    }
  };

  // ⬅️ ACTIVITY SLOT UPDATE via hook — PUT
  const submitActivitySlotUpdate = async (e) => {
    e.preventDefault();
    resetActivitySlotUpdate();
    const payload = {
      startTime: updateActivitySlotForm.startTime,
      endTime: updateActivitySlotForm.endTime,
      activityLocationId: Number(updateActivitySlotForm.activityLocationId),
      slotCapacity: Number(updateActivitySlotForm.slotCapacity),
    };
    try {
      await updateActivitySlot(updateActivitySlotForm.id, payload);
    } catch {
      // felmeddelande visas via updateActivitySlotError från hooken
    }
  };

  return (
    <section className={`action-panel ${containerClassName}`}>
      {showTitle && (
        <div className="panel-header">
          <h2>Uppdatera aktivitetstillfälle</h2>
          <p>Sök fram ett tillfälle och justera fälten.</p>
        </div>
      )}

      {/* Status för update */}
      {updateActivitySlotLoading && <p>Jobbar…</p>}
      {updateActivitySlotError && (
        <p style={{ color: "var(--peach-royal)" }}>{updateActivitySlotError}</p>
      )}
      {updateActivitySlotOkMessage && (
        <p style={{ color: "var(--peach-passion)" }}>
          {updateActivitySlotOkMessage}
        </p>
      )}

      {/* 1) Sökdel (ID + Hämta) */}
      <form className="panel-form" onSubmit={handleFetchActivitySlotById}>
        <div className="form-row inline">
          <div>
            <label>Tillfälle-ID</label>
            <input
              type="number"
              value={lookupActivitySlotId}
              onChange={(e) => setLookupActivitySlotId(e.target.value)}
              placeholder="t.ex. 1"
              min="1"
              required
            />
          </div>
          <div className="panel-actions compact">
            <button
              type="submit"
              className="btn primary"
              disabled={updateActivitySlotLoading}
            >
              {updateActivitySlotLoading ? "Hämtar…" : "Hämta"}
            </button>
            <button type="button" className="btn ghost" onClick={onBack}>
              Tillbaka
            </button>
          </div>
        </div>
      </form>

      {/* 2) Edit-form som visas när vi har data */}
      {updateActivitySlotForm.id && (
        <form className="panel-form" onSubmit={submitActivitySlotUpdate}>
          <div className="form-row grid-2">
            <div>
              <label>ID</label>
              <input type="text" value={updateActivitySlotForm.id} disabled />
            </div>
            <div>
              <label>Kapacitet</label>
              <input
                type="number"
                name="slotCapacity"
                value={updateActivitySlotForm.slotCapacity}
                onChange={onUpdateActivitySlotChange}
                min="1"
                required
              />
            </div>
          </div>

          <div className="form-row grid-2">
            <div>
              <label>Starttid</label>
              <input
                type="datetime-local"
                name="startTime"
                value={updateActivitySlotForm.startTime}
                onChange={onUpdateActivitySlotChange}
                required
              />
            </div>
            <div>
              <label>Sluttid</label>
              <input
                type="datetime-local"
                name="endTime"
                value={updateActivitySlotForm.endTime}
                onChange={onUpdateActivitySlotChange}
                required
              />
            </div>
          </div>

          <div className="form-row">
            <label>Aktivitet-plats</label>
            <select
              name="activityLocationId"
              value={updateActivitySlotForm.activityLocationId}
              onChange={onUpdateActivitySlotChange}
              required
            >
              <option value="">-- Välj aktivitet-plats --</option>
              {!activityLocationsLoading &&
                Array.isArray(activityLocations) &&
                activityLocations.map((al) => (
                  <option key={al.id} value={al.id}>
                    {al.activity?.name ||
                      al.activityName ||
                      `Akt:${al.activityId}`}{" "}
                    -{" "}
                    {al.location?.name ||
                      al.locationName ||
                      `Plats:${al.locationId}`}{" "}
                    {al.capacity ? ` (kap ${al.capacity})` : ""}
                  </option>
                ))}
            </select>
            {activityLocationsError && (
              <p style={{ color: "var(--peach-royal)" }}>
                {activityLocationsError}
              </p>
            )}
          </div>

          <div className="panel-actions">
            <button type="button" className="btn ghost" onClick={onBack}>
              Avbryt
            </button>
            <button
              type="submit"
              className="btn primary"
              disabled={updateActivitySlotLoading}
            >
              {updateActivitySlotLoading ? "Sparar…" : "Spara ändringar"}
            </button>
          </div>
        </form>
      )}
    </section>
  );
}

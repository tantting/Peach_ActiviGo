import React, { useState } from "react";
import FetchCreateActivitySlot from "../../../../Components/HelperFunctions/Admin/CRUDS/ActivitySlots/FetchCreateActivitySlot.jsx";
import "../../../../Styles/AdminView.css";

export default function CreateActivitySlotView({
  showTitle = true,
  containerClassName = "",
  onBack,
}) {
  // --- ACTIVITY SLOT CREATE: formulär-state ---
  const [createActivitySlotForm, setCreateActivitySlotForm] = useState({
    startTime: "",
    endTime: "",
    activityLocationId: "",
    slotCapacity: "",
  });

  // Koppla in ACTIVITY SLOT CREATE-hooken
  const {
    createActivitySlot,
    loading: createActivitySlotLoading,
    error: createActivitySlotError,
    okMessage: createActivitySlotOkMessage,
  } = FetchCreateActivitySlot();

  // onChange handler
  const onCreateActivitySlotChange = (e) => {
    const { name, value } = e.target;
    setCreateActivitySlotForm((p) => ({ ...p, [name]: value }));
  };

  return (
    <section className={`action-panel ${containerClassName}`}>
      {showTitle && (
        <div className="panel-header">
          <h2>Skapa nytt aktivitetstillfälle</h2>
          <p>Fyll i uppgifterna och spara.</p>
        </div>
      )}

      <form
        className="panel-form"
        onSubmit={async (e) => {
          e.preventDefault();
          const payload = {
            startTime: createActivitySlotForm.startTime,
            endTime: createActivitySlotForm.endTime,
            activityLocationId: Number(
              createActivitySlotForm.activityLocationId
            ),
            slotCapacity: Number(createActivitySlotForm.slotCapacity),
          };
          await createActivitySlot(payload);
          setCreateActivitySlotForm({
            startTime: "",
            endTime: "",
            activityLocationId: "",
            slotCapacity: "",
          });
        }}
      >
        {createActivitySlotLoading && <p>Skapar aktivitetstillfälle…</p>}
        {createActivitySlotError && (
          <p style={{ color: "var(--peach-royal)" }}>
            {createActivitySlotError}
          </p>
        )}
        {createActivitySlotOkMessage && (
          <p style={{ color: "var(--peach-passion)" }}>
            {createActivitySlotOkMessage}
          </p>
        )}

        <div className="form-row grid-2">
          <div>
            <label>Starttid</label>
            <input
              type="datetime-local"
              name="startTime"
              value={createActivitySlotForm.startTime}
              onChange={onCreateActivitySlotChange}
              required
            />
          </div>
          <div>
            <label>Sluttid</label>
            <input
              type="datetime-local"
              name="endTime"
              value={createActivitySlotForm.endTime}
              onChange={onCreateActivitySlotChange}
              required
            />
          </div>
        </div>

        <div className="form-row grid-2">
          <div>
            <label>ActivityLocation-ID</label>
            <input
              type="number"
              name="activityLocationId"
              value={createActivitySlotForm.activityLocationId}
              onChange={onCreateActivitySlotChange}
              min="1"
              required
            />
          </div>
          <div>
            <label>Kapacitet</label>
            <input
              type="number"
              name="slotCapacity"
              value={createActivitySlotForm.slotCapacity}
              onChange={onCreateActivitySlotChange}
              min="1"
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
            disabled={createActivitySlotLoading}
          >
            {createActivitySlotLoading ? "Sparar…" : "Spara"}
          </button>
        </div>
      </form>
    </section>
  );
}

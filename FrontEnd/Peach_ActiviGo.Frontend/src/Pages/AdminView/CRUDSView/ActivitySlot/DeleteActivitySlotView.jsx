import React from "react";
import FetchDeleteActivitySlot from "../../../../Components/HelperFunctions/Admin/CRUDS/ActivitySlots/FetchDeleteActivitySlot.jsx";
import "../../../../Styles/AdminView.css";

export default function DeleteActivitySlotView({
  showTitle = true,
  containerClassName = "",
  onBack,
}) {
  // ⬅️ ACTIVITY SLOT DELETE via hook
  const {
    deleteActivitySlot,
    loading: deleteActivitySlotLoading,
    error: deleteActivitySlotError,
    okMessage: deleteActivitySlotOkMessage,
  } = FetchDeleteActivitySlot();

  return (
    <section className={`action-panel ${containerClassName}`}>
      {showTitle && (
        <div className="panel-header">
          <h2>Radera aktivitetstillfälle</h2>
          <p>Ange ID och radera tillfället.</p>
        </div>
      )}

      {deleteActivitySlotLoading && <p>Raderar…</p>}
      {deleteActivitySlotError && (
        <p className="error-message">{deleteActivitySlotError}</p>
      )}
      {deleteActivitySlotOkMessage && (
        <p style={{ color: "#2e7d32" }}>{deleteActivitySlotOkMessage}</p>
      )}

      <form
        className="panel-form"
        onSubmit={async (e) => {
          e.preventDefault();
          const formData = new FormData(e.target);
          const id = formData.get("activitySlotId");
          if (!id) return;

          const confirmed = window.confirm(
            `Är du säker på att du vill radera aktivitetstillfälle med ID ${id}?`
          );
          if (!confirmed) return;

          try {
            await deleteActivitySlot(Number(id));
            e.target.reset();
          } catch {
            // felmeddelande visas via deleteActivitySlotError från hooken
          }
        }}
      >
        <div className="form-row inline">
          <div>
            <label>Tillfälle-ID</label>
            <input
              type="number"
              name="activitySlotId"
              placeholder="t.ex. 5"
              min="1"
              required
            />
          </div>
          <div className="panel-actions compact">
            <button
              type="submit"
              className="btn primary"
              disabled={deleteActivitySlotLoading}
            >
              {deleteActivitySlotLoading ? "Raderar…" : "Radera"}
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

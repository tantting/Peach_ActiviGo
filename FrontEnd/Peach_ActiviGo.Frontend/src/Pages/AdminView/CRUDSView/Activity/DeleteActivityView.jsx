import React, { useState } from "react";
import FetchDeleteActivity from "../../../../Components/HelperFunctions/Admin/CRUDS/Activity/FetchDeleteActivity";
import "../../../../Styles/BookingStatistics.css";

export default function DeleteActivityView({
  showTitle = true,
  containerClassName = "",
}) {
  const [id, setId] = useState("");
  const { deleteActivity, loading, error, okMessage } = FetchDeleteActivity();

  const onDelete = async (e) => {
    e.preventDefault();
    if (!id) return;

    const confirmed = window.confirm(
      `Är du säker på att du vill radera aktivitet med ID ${id}?`
    );
    if (!confirmed) return;

    try {
      await deleteActivity(id);
      setId("");
    } catch (err) {
      // Error handling är redan hanterat av hooken
    }
  };

  return (
    <div className={`page-container ${containerClassName}`}>
      {showTitle && <h1>Radera aktivitet</h1>}

      {loading && <p>Raderar…</p>}
      {error && <p className="error-message">{error}</p>}
      {okMessage && <p style={{ color: "#2e7d32" }}>{okMessage}</p>}

      <form className="panel-form" onSubmit={onDelete}>
        <div className="form-row inline">
          <div>
            <label>Aktivitets-ID</label>
            <input
              type="number"
              min="1"
              value={id}
              onChange={(e) => setId(e.target.value)}
              placeholder="t.ex. 3"
              required
            />
          </div>
          <div className="panel-actions compact">
            <button type="submit" className="btn primary" disabled={loading}>
              {loading ? "Raderar…" : "Radera"}
            </button>
          </div>
        </div>
      </form>
    </div>
  );
}

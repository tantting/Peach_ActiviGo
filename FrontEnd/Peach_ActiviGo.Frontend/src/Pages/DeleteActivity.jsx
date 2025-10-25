import React, { useState } from "react";
import FetchContent from "../Components/HelperFunctions/FetchContent";
import "../Styles/BookingStatistics.css";

export default function DeleteActivity({ showTitle = true, containerClassName = "" }) {
  const [id, setId] = useState("");
  const [loading, setLoading] = useState(false);
  const [ok, setOk] = useState("");
  const [error, setError] = useState("");

  const onDelete = async (e) => {
    e.preventDefault();
    setOk("");
    setError("");
    if (!id) return;

    const confirmed = window.confirm(`Är du säker på att du vill radera aktivitet med ID ${id}?`);
    if (!confirmed) return;

    try {
      setLoading(true);
      await FetchContent(`/api/activities/${Number(id)}`, null, "DELETE");
      setOk("Aktivitet raderad!");
      setId("");
    } catch (err) {
      setError("Kunde inte radera aktiviteten.");
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className={`page-container ${containerClassName}`}>
      {showTitle && <h1>Radera aktivitet</h1>}

      {loading && <p>Raderar…</p>}
      {error && <p className="error-message">{error}</p>}
      {ok && <p style={{ color: "#2e7d32" }}>{ok}</p>}

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

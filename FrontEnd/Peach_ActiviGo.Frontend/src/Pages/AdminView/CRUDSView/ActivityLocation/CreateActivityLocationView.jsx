import React, { useState } from "react";
import FetchCreateActivityLocation from "../../../../Components/HelperFunctions/Admin/CRUDS/ActivityLocation/FetchCreateActivityLocation.jsx";
import FetchAllActivity from "../../../../Components/HelperFunctions/Admin/CRUDS/Activity/FetchAllActivity.jsx";
import FetchAllLocations from "../../../../Components/HelperFunctions/Admin/CRUDS/Location/FetchAllLocations.jsx";
import "../../../../Styles/AdminView.css";

export default function CreateActivityLocationView({
  showTitle = true,
  containerClassName = "",
  onBack,
}) {
  const [form, setForm] = useState({
    activityId: "",
    locationId: "",
    capacity: "",
    isIndoor: false,
    isActive: true,
    imageUrl: "",
  });

  const {
    createActivityLocation,
    loading: createLoading,
    error: createError,
    okMessage: createOk,
  } = FetchCreateActivityLocation();

  const { activity: activities, loading: activitiesLoading } =
    FetchAllActivity();
  const { locations, loading: locationsLoading } = FetchAllLocations();

  const onChange = (event) => {
    const { name, value, type, checked } = event.target;
    setForm((parameter) => ({
      ...parameter,
      [name]: type === "checkbox" ? checked : value,
    }));
  };

  return (
    <section className={`action-panel ${containerClassName}`}>
      {showTitle && (
        <div className="panel-header">
          <h2>Skapa ActivityLocation</h2>
          <p>Koppla en aktivitet till en plats.</p>
        </div>
      )}

      <form
        className="panel-form"
        onSubmit={async (e) => {
          e.preventDefault();
          const payload = {
            activityId: Number(form.activityId),
            locationId: Number(form.locationId),
            // capacity: form.capacity ? Number(form.capacity) : null,
            isIndoor: Boolean(form.isIndoor),
            isActive: Boolean(form.isActive),
          };

          await createActivityLocation(payload);

          setForm({
            activityId: "",
            locationId: "",
            // capacity: "",
            isIndoor: false,
            isActive: true,
            imageUrl: "",
          });
        }}
      >
        {createLoading && <p>Skapar koppling…</p>}
        {createError && (
          <p style={{ color: "var(--peach-royal)" }}>{createError}</p>
        )}
        {createOk && (
          <p style={{ color: "var(--peach-passion)" }}>{createOk}</p>
        )}

        <div className="form-row">
          <label>Aktivitet</label>
          <select
            name="activityId"
            value={form.activityId}
            onChange={onChange}
            required
          >
            <option value="">-- Välj aktivitet --</option>
            {!activitiesLoading &&
              Array.isArray(activities) &&
              activities.map((a) => (
                <option key={a.id} value={a.id}>
                  {a.name}
                </option>
              ))}
          </select>
        </div>

        <div className="form-row">
          <label>Plats</label>
          <select
            name="locationId"
            value={form.locationId}
            onChange={onChange}
            required
          >
            <option value="">-- Välj plats --</option>
            {!locationsLoading &&
              Array.isArray(locations) &&
              locations.map((l) => (
                <option key={l.id} value={l.id}>
                  {l.name}
                </option>
              ))}
          </select>
        </div>

        <div className="form-row grid-2">
          <div>
            <label>
              <input
                type="checkbox"
                name="isIndoor"
                checked={form.isIndoor}
                onChange={onChange}
              />{" "}
              Inomhus
            </label>
          </div>
          <div>
            <label>
              <input
                type="checkbox"
                name="isActive"
                checked={form.isActive}
                onChange={onChange}
              />{" "}
              Aktiv
            </label>
          </div>
        </div>

        <div className="panel-actions">
          <button type="button" className="btn ghost" onClick={onBack}>
            Tillbaka
          </button>
          <button
            type="submit"
            className="btn primary"
            disabled={createLoading}
          >
            {createLoading ? "Sparar…" : "Spara"}
          </button>
        </div>
      </form>
    </section>
  );
}

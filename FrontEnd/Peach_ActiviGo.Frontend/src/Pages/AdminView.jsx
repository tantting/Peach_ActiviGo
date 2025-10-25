import React, { useState } from "react";
import "../Styles/AdminView.css";
import FetchPeachApi from "../Components/HelperFunctions/FetchPeachApi.jsx";
import FetchCreateActivity from "../Components/HelperFunctions/FetchCreateActivity.jsx";
import FetchUpdateActivity from "../Components/HelperFunctions/FetchUpdateActivity.jsx";
import BookingStatistics from "../Pages/BookingStatistics.jsx";
import AllActivities from "./AllActivites.jsx";
import DeleteActivity from "./DeleteActivity.jsx";

const ACTIVITY_ENDPOINT = "/api/activities";

export default function AdminView() {
  const [showCards, setShowCards] = useState(false);
  const [selectedAction, setSelectedAction] = useState(null); // "create" | "update" | "statistics" | "list" | null  

  // --- CREATE: formulär-state ---
  const [createForm, setCreateForm] = useState({
    name: "",
    description: "",
    price: "",
    imageUrl: "",
    categoryId: "",
    // categoryName: "",
    // locationName: "",
  });

  // Koppla in CREATE-hooken
  const {
    createActivity,
    loading: createLoading,
    error: createError,
    ok: createOk,
  } = FetchCreateActivity();

  // --- UPDATE: sök + formulär-state ---
  const [lookupId, setLookupId] = useState(""); // ID att hämta
  const [updateForm, setUpdateForm] = useState({
    id: "",
    name: "",
    description: "",
    price: "",
    imageUrl: "",
    // categoryId: "",
    // categoryName: "",
  });

  // ⬅️ UPDATE via hook
  const {
    fetchById,
    updateActivity,
    loading: updateLoading,
    error: updateError,
    ok: updateOk,
    data: fetchedActivity,
    reset: resetUpdate,
  } = FetchUpdateActivity();

  // Öppnare
  const openCreate = () => setSelectedAction("create");
  const openUpdate = () => setSelectedAction("update");
  const openStatistics = () => setSelectedAction("statistics");
  const openList = () => setSelectedAction("list");
  const openDelete = () => setSelectedAction("delete");
  const goBack = () => setSelectedAction(null);

  // onChange handlers
  const onCreateChange = (e) => {
    const { name, value } = e.target;
    setCreateForm((p) => ({ ...p, [name]: value }));
  };
  const onUpdateChange = (e) => {
    const { name, value } = e.target;
    setUpdateForm((p) => ({ ...p, [name]: value }));
  };

  // ⬅️ UPDATE via hook — GET
  const handleFetchById = async (e) => {
    e.preventDefault();
    resetUpdate();
    try {
      const data = await fetchById(lookupId);
      setUpdateForm({
        id: data.id,
        name: data.name ?? "",
        description: data.description ?? "",
        price: data.price ?? 0,
        imageUrl: data.imageUrl ?? "",
        // categoryId: data.categoryId ?? "",
        // categoryName: data.categoryName ?? "",
      });
    } catch {
      // felmeddelande visas via updateError från hooken
    }
  };

  // ⬅️ UPDATE via hook — PUT
  const submitUpdate = async (e) => {
    e.preventDefault();
    resetUpdate();
    const payload = {
      name: updateForm.name,
      description: updateForm.description,
      price: Number(updateForm.price),
      imageUrl: updateForm.imageUrl,
      categoryId: Number(updateForm.categoryId),
      categoryName: updateForm.categoryName,
    };
    try {
      await updateActivity(updateForm.id, payload);
    } catch {
      // felmeddelande visas via updateError från hooken
    }
  };

  return (
    <div className="admin-container">
      {/* KORTEN */}
      <div className="card-container">
        <button className="card green-card" onClick={openCreate}>
          <span className="card-title">Lägg till aktivitet</span>
        </button>

        <button className="card yellow-card" onClick={openUpdate}>
          <span className="card-title">Uppdatera aktivitet</span>
        </button>

        <button className="card yellow-card" onClick={openStatistics}>
          <span className="card-title">Statistik</span>
        </button>

        <button className="card yellow-card" onClick={openList}>
          <span className="card-title">Hämta alla aktiviteter</span>
        </button>

        <button className="card yellow-card" onClick={openDelete}>
         <span className="card-title">Radera aktivitet</span>
        </button>
      </div>

      {/* CREATE-PANEL */}
      {selectedAction === "create" && (
        <section className="action-panel">
          <div className="panel-header">
            <h2>Skapa ny aktivitet</h2>
            <p>Fyll i uppgifterna och spara.</p>
          </div>

          <form
            className="panel-form"
            onSubmit={async (e) => {
              e.preventDefault();
              const payload = {
                name: createForm.name,
                description: createForm.description,
                price: Number(createForm.price),
                imageUrl: createForm.imageUrl,
                categoryId: Number(createForm.categoryId),
                // categoryName: createForm.categoryName,
                // locationName: createForm.locationName,
              };
              await createActivity(payload);
              setCreateForm({
                name: "",
                description: "",
                price: "",
                imageUrl: "",
                categoryId: "",
                // categoryName: "",
                // locationName: "",
              });
            }}
          >
            {createLoading && <p>Skapar aktivitet…</p>}
            {createError && <p style={{ color: "#c0392b" }}>{createError}</p>}
            {createOk && <p style={{ color: "#2e7d32" }}>{createOk}</p>}

            <div className="form-row">
              <label>Namn</label>
              <input
                type="text"
                name="name"
                value={createForm.name}
                onChange={onCreateChange}
                required
              />
            </div>

            <div className="form-row">
              <label>Beskrivning</label>
              <textarea
                name="description"
                value={createForm.description}
                onChange={onCreateChange}
                rows="3"
                required
              />
            </div>

            <div className="form-row grid-2">
              <div>
                <label>Pris</label>
                <input
                  type="number"
                  name="price"
                  value={createForm.price}
                  onChange={onCreateChange}
                  min="0"
                  step="1"
                  required
                />
              </div>
              <div>
                <label>Kategori-ID</label>
                <input
                  type="number"
                  name="categoryId"
                  value={createForm.categoryId}
                  onChange={onCreateChange}
                  min="1"
                  required
                />
              </div>
            </div>

            <div className="form-row grid-2">
              <div>
                <label>Bild-URL</label>
                <input
                  type="text"
                  name="imageUrl"
                  value={createForm.imageUrl}
                  onChange={onCreateChange}
                />
              </div>
            </div>

            <div className="panel-actions">
              <button type="button" className="btn ghost" onClick={goBack}>
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
      )}

      {/* UPDATE-PANEL */}
      {selectedAction === "update" && (
        <section className="action-panel">
          <div className="panel-header">
            <h2>Uppdatera aktivitet</h2>
            <p>Sök fram en aktivitet och justera fälten.</p>
          </div>

          {/* Status för update */}
          {updateLoading && <p>Jobbar…</p>}
          {updateError && <p style={{ color: "#c0392b" }}>{updateError}</p>}
          {updateOk && <p style={{ color: "#2e7d32" }}>{updateOk}</p>}

          {/* 1) Sökdel (ID + Hämta) */}
          <form className="panel-form" onSubmit={handleFetchById}>
            <div className="form-row inline">
              <div>
                <label>Aktivitets-ID</label>
                <input
                  type="number"
                  value={lookupId}
                  onChange={(e) => setLookupId(e.target.value)}
                  placeholder="t.ex. 1"
                  min="1"
                  required
                />
              </div>
              <div className="panel-actions compact">
                <button
                  type="submit"
                  className="btn primary"
                  disabled={updateLoading}
                >
                  {updateLoading ? "Hämtar…" : "Hämta"}
                </button>
                <button type="button" className="btn ghost" onClick={goBack}>
                  Tillbaka
                </button>
              </div>
            </div>
          </form>

          {/* 2) Edit-form som visas när vi har data */}
          {updateForm.id && (
            <form className="panel-form" onSubmit={submitUpdate}>
              <div className="form-row grid-2">
                <div>
                  <label>ID</label>
                  <input type="text" value={updateForm.id} disabled />
                </div>
                <div>
                  <label>Pris</label>
                  <input
                    type="number"
                    name="price"
                    value={updateForm.price}
                    onChange={onUpdateChange}
                    min="0"
                    step="1"
                    required
                  />
                </div>
              </div>

              <div className="form-row">
                <label>Namn</label>
                <input
                  type="text"
                  name="name"
                  value={updateForm.name}
                  onChange={onUpdateChange}
                  required
                />
              </div>

              <div className="form-row">
                <label>Beskrivning</label>
                <textarea
                  name="description"
                  value={updateForm.description}
                  onChange={onUpdateChange}
                  rows="3"
                  required
                />
              </div>

              <div className="form-row">
                <label>Bild-URL</label>
                <input
                  type="text"
                  name="imageUrl"
                  value={updateForm.imageUrl}
                  onChange={onUpdateChange}
                />
              </div>

              <div className="form-row grid-2">
                <div>
                  <label>Kategori-ID</label>
                  <input
                    type="number"
                    name="categoryId"
                    value={updateForm.categoryId}
                    onChange={onUpdateChange}
                    min="1"
                  />
                </div>

              </div>

              <div className="panel-actions">
                <button type="button" className="btn ghost" onClick={goBack}>
                  Avbryt
                </button>
                <button
                  type="submit"
                  className="btn primary"
                  disabled={updateLoading}
                >
                  {updateLoading ? "Sparar…" : "Spara ändringar"}
                </button>
              </div>
            </form>
          )}
        </section>
      )}

      {/* LIST-PANEL */}
      {selectedAction === "list" && (
        <section className="action-panel">
          <div className="panel-header">
            <h2>Alla aktiviteter</h2>
            <p>Visar hela listan från API:t.</p>
          </div>

          <AllActivities
            showTitle={false}
            containerClassName="statistics-embedded"
          />

          <div className="panel-actions">
            <button type="button" className="btn ghost" onClick={goBack}>
              Tillbaka
            </button>
          </div>
        </section>
      )}

      {/* STATISTICS-PANEL */}
      {selectedAction === "statistics" && (
        <section className="action-panel">
          <div className="panel-header">
            <h2>Statistik</h2>
            <p>Visa statistik for bokningar.</p>
          </div>
          <BookingStatistics
            showTitle={false}
            containerClassName="statistics-embedded"
          />
          <div className="panel-actions">
            <button type="button" className="btn ghost" onClick={goBack}>
              Tillbaka
            </button>
          </div>
        </section>
      )}

      {selectedAction === "delete" && (
  <section className="action-panel">
    <div className="panel-header">
      <h2>Radera aktivitet</h2>
      <p>Ange ID och radera aktiviteten.</p>
    </div>

    <DeleteActivity showTitle={false} containerClassName="statistics-embedded" />

    <div className="panel-actions">
      <button type="button" className="btn danger" onClick={goBack}>
        Tillbaka
      </button>
    </div>
  </section>
)}

    </div>
  );
}

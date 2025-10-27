import React, { useState, useEffect } from "react";
import FetchUpdateActivity from "../../../../Components/HelperFunctions/Admin/CRUDS/Activity/FetchUpdateActivity.jsx";
import FetchContent from "../../../../Components/HelperFunctions/FetchContent.jsx";
import "../../../../Styles/AdminView.css";

export default function UpdateActivityView({
  showTitle = true,
  containerClassName = "",
  onBack,
}) {
  // --- UPDATE: sök + formulär-state ---
  const [lookupId, setLookupId] = useState(""); // ID att hämta
  const [updateForm, setUpdateForm] = useState({
    id: "",
    name: "",
    description: "",
    price: "",
    imageUrl: "",
    categoryId: "",
  });

  // ⬅️ UPDATE via hook
  const {
    fetchById,
    updateActivity,
    loading: updateLoading,
    error: updateError,
    okMessage: updateOkMessage,
    reset: resetUpdate,
  } = FetchUpdateActivity();

  // onChange handler
  const onUpdateChange = (e) => {
    const { name, value } = e.target;
    setUpdateForm((p) => ({ ...p, [name]: value }));
  };

  // Hämta kategorier för dropdown
  const [categories, setCategories] = useState([]);
  const [categoriesLoading, setCategoriesLoading] = useState(false);
  const [categoriesError, setCategoriesError] = useState(null);

  useEffect(() => {
    const load = async () => {
      setCategoriesLoading(true);
      try {
        const data = await FetchContent("/api/Categories");
        setCategories(Array.isArray(data) ? data : []);
      } catch (err) {
        setCategoriesError("Kunde inte hämta kategorier");
        setCategories([]);
      } finally {
        setCategoriesLoading(false);
      }
    };
    load();
  }, []);

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
        categoryId: data.categoryId ?? "",
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
    };
    try {
      await updateActivity(updateForm.id, payload);
    } catch {
      // felmeddelande visas via updateError från hooken
    }
  };

  return (
    <section className={`action-panel ${containerClassName}`}>
      {showTitle && (
        <div className="panel-header">
          <h2>Uppdatera aktivitet</h2>
          <p>Sök fram en aktivitet och justera fälten.</p>
        </div>
      )}

      {/* Status för update */}
      {updateLoading && <p>Jobbar…</p>}
      {updateError && (
        <p style={{ color: "var(--peach-royal)" }}>{updateError}</p>
      )}
      {updateOkMessage && (
        <p style={{ color: "var(--peach-passion)" }}>{updateOkMessage}</p>
      )}

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
            <button type="button" className="btn ghost" onClick={onBack}>
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
              <label>Kategori</label>
              <select
                name="categoryId"
                value={updateForm.categoryId}
                onChange={onUpdateChange}
              >
                <option value="">-- Välj kategori --</option>
                {!categoriesLoading &&
                  Array.isArray(categories) &&
                  categories.map((c) => (
                    <option key={c.id} value={c.id}>
                      {c.name}
                    </option>
                  ))}
              </select>
              {categoriesError && (
                <p style={{ color: "var(--peach-royal)" }}>{categoriesError}</p>
              )}
            </div>
          </div>

          <div className="panel-actions">
            <button type="button" className="btn ghost" onClick={onBack}>
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
  );
}

import React, { useState, useEffect } from "react";
import FetchCreateActivity from "../../../../Components/HelperFunctions/Admin/CRUDS/Activity/FetchCreateActivity.jsx";
import FetchContent from "../../../../Components/HelperFunctions/FetchContent.jsx";
import "../../../../Styles/AdminView.css";

export default function CreateActivityView({
  showTitle = true,
  containerClassName = "",
  onBack,
}) {
  // --- CREATE: formulär-state ---
  const [createForm, setCreateForm] = useState({
    name: "",
    description: "",
    price: "",
    imageUrl: "",
    categoryId: "",
  });

  // Koppla in CREATE-hooken
  const {
    createActivity,
    loading: createLoading,
    error: createError,
    okMessage: createOk,
  } = FetchCreateActivity();

  // onChange handler
  const onCreateChange = (e) => {
    const { name, value } = e.target;
    setCreateForm((p) => ({ ...p, [name]: value }));
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

  return (
    <section className={`action-panel ${containerClassName}`}>
      {showTitle && (
        <div className="panel-header">
          <h2>Skapa ny aktivitet</h2>
          <p>Fyll i uppgifterna och spara.</p>
        </div>
      )}

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
          };
          await createActivity(payload);
          setCreateForm({
            name: "",
            description: "",
            price: "",
            imageUrl: "",
            categoryId: "",
          });
        }}
      >
        {createLoading && <p>Skapar aktivitet…</p>}
        {createError && (
          <p style={{ color: "var(--peach-royal)" }}>{createError}</p>
        )}
        {createOk && (
          <p style={{ color: "var(--peach-passion)" }}>{createOk}</p>
        )}

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
            <label>Kategori</label>
            <select
              name="categoryId"
              value={createForm.categoryId}
              onChange={onCreateChange}
              required
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

import React from "react";
import { useState, useEffect } from "react";
import FetchContent from "../Components/HelperFunctions/FetchContent";
import "../Styles/Global.css";

export default function CategoryView() {
  const [categories, setCategories] = useState([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);

  const fetchCategories = async () => {
    setLoading(true);
    try {
      const data = await FetchContent("/api/Categories");
      setCategories(data || []);
    } catch (err) {
      setError("Kunde inte hämta kategorier");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchCategories();
  }, []);

  if (loading) return <p>Laddar kategorier…</p>;
  if (error) return <p>{error}</p>;

  return (
    <div className="page-container">
      <h1>Kategorier</h1>
      <p>Utforska olika kategorier av aktiviteter</p>

      <div className="categories-list">
        {categories.map((category) => (
          <div className="category-item" key={category.name}>
            <h3>{category.name}</h3>
            <p>{category.description}</p>
          </div>
        ))}
      </div>
    </div>
  );
}

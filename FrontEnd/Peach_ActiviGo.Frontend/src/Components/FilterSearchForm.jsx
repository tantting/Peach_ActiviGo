import React, { useState } from "react";
import "../Styles/FilterSearchForm.css";
import { useForm } from "react-hook-form";

const FilterSearchForm = () => {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({ mode: "onChange" });

  const onSearch = (formdata) => {
    console.log("Data skickas");
    console.log(formdata);
  };
  const handleErrors = (errors) => {};

  const registerOption = {
    date: {
      validate: (value) => {
        if (!value) return true; // fältet är frivilligt
        const today = new Date();
        const selectedDate = new Date(value);

        // Nollställ tid för korrekt jämförelse
        today.setHours(0, 0, 0, 0);

        return selectedDate >= today || "Datum måste vara tidigast idag";
      },
    },
    category: {},
    // inOutDoor: {},
    // availableSpotsOnly: {},
    numberSpots: {
      min: {
        value: 0,
        message: "Antal måste vara större än 0",
      },
    },
  };

  return (
    <form
      className="filterSearch"
      onSubmit={handleSubmit(onSearch, handleErrors)}
    >
      <div>
        <label>Datum</label>
        <input
          type="date"
          placeholder="Datum"
          {...register("date", registerOption.date)}
        />
        {errors.date && <p className="error">{errors.date.message}</p>}
      </div>

      <div>
        <label>Kategori</label>
        <input
          type="text"
          placeholder="Kategori"
          {...register("category", registerOption.category)}
        />
      </div>

      <div>
        <label>Inne / Ute</label>
        <select {...register("inOutDoor", registerOption.inOutDoor)}>
          <option value="">Välj...</option>
          <option value="indoor">Inomhus</option>
          <option value="outdoor">Utomhus</option>
        </select>
      </div>

      <div>
        <label>Enbart tillgängliga tider</label>
        <input
          type="radio"
          name="availableSpotsOnly"
          value="true"
          {...register("availableSpotsOnly", registerOption.availableSpotsOnly)}
        />
        {errors.availableSpotsOnly && (
          <p className="error">{errors.availableSpotsOnly.message}</p>
        )}
      </div>

      <div>
        <label>Antal platser</label>
        <input
          type="number"
          placeholder="Antal platser"
          {...register("numberSpots", registerOption.numberSpots)}
        />
        {errors.numberSpots && (
          <p className="error">{errors.numberSpots.message}</p>
        )}
      </div>

      <button type="submit">Search</button>
    </form>
  );
};

export default FilterSearchForm;

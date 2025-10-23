import React, { useEffect, useState } from "react";
import "../Styles/FilterSearchForm.css";
import { useForm } from "react-hook-form";
import { API_BASE_URL } from "../utils/constants";
import FetchContent from "./HelperFunctions/FetchContent";

const TranslatePayload = (formdata) => {
  const payload = {};

  if (formdata.date) {
    payload.StartDate = new Date(
      `${formdata.date}T${formdata.startTime || "00:00"}:00`
    ).toISOString();

    payload.EndDate = new Date(
      `${formdata.date}T${formdata.endTime || "23:59"}:00`
    ).toISOString();
  }

  if (formdata.category) {
    payload.CategoryId = Number(formdata.category);
  }

  if (formdata.inOutDoor === "indoor") {
    payload.IsIndoor = true;
  } else if (formdata.inOutDoor === "outdoor") {
    payload.IsIndoor = false;
  }

  if (formdata.availableSpotsOnly === "true") {
    payload.OnlyAvailableSlots = true;
  }

  if (formdata.numberSpots && Number(formdata.numberSpots) > 0) {
    payload.NumberOfSpots = Number(formdata.numberSpots);
  }

  return payload;
};

const FilterSearchForm = ({ setActivityLocations, setLoading, setError }) => {
  const {
    register,
    watch,
    reset,
    handleSubmit,
    formState: { errors },
  } = useForm({ mode: "onChange" });

  const onSearch = async (formdata) => {
    setLoading(true);
    setError(null);

    try {
      const payload = TranslatePayload(formdata);
      const UrlAddOn = "/api/ActivityLocation/FilterActivityLocations";
      const data = await FetchContent(payload, UrlAddOn);
      setActivityLocations(data || []);
    } catch (err) {
      setError("Kunde inte hämta aktiviteter");
    } finally {
      setLoading(false);
    }
  };
  const handleReset = () => {
    reset({
      date: "",
      startTime: "",
      endTime: "",
      category: "",
      inOutDoor: "",
      availableSpotsOnly: null,
      numberSpots: 0,
    });
  };

  const handleErrors = (errors) => {};
  const startTime = watch("startTime"); // läs starttid dynamiskt
  const date = watch("date");

  const registerOption = {
    date: {
      validate: (value) => {
        console.log("startTime:", startTime, "date:", date, "value:", value);
        if (!value) return true; // fältet är frivilligt
        const today = new Date();
        const selectedDate = new Date(value);

        // Nollställ tid för korrekt jämförelse
        today.setHours(0, 0, 0, 0);

        return selectedDate >= today || "Datum måste vara tidigast idag";
      },
    },
    startTime: {
      validate: (value) => {
        console.log("startTime:", startTime, "date:", date, "value:", value);
        if (!value) return true; //frivillig
        if (!date) return "Du måste ange datum först";
        const now = new Date();
        const [hours, minutes] = value.split(":").map(Number);
        const start = new Date();
        start.setHours(hours, minutes, 0, 0);

        return (
          start >= now || "Starttid måste vara senare än nuvarande klockslag"
        );
      },
    },
    endTime: {
      validate: (value) => {
        if (!value) return true;
        if (!startTime || startTime.trim() === "")
          return "Du måste ange en starttid först";

        const [startH, startM] = startTime.split(":").map(Number);
        const [endH, endM] = value.split(":").map(Number);

        const startDate = new Date();
        startDate.setHours(startH, startM, 0, 0);

        const endDate = new Date();
        endDate.setHours(endH, endM, 0, 0);

        return endDate > startDate || "Sluttiden måste vara efter starttiden";
      },
    },
    category: {},
    inOutDoor: {},
    availableSpotsOnly: {},
    numberSpots: {
      min: {
        value: 0,
        message: "Antal måste vara större än 0",
      },
    },
  };

  const [initCategories, setInitCategories] = useState([]);
  const categoryURL = `${API_BASE_URL}/api/Categories`;

  useEffect(() => {
    async function getInitialCategory() {
      const response = await fetch(categoryURL);
      const fetchedCategories = await response.json();
      setInitCategories(fetchedCategories);
    }
    getInitialCategory();
  }, []);

  return (
    <form
      className="filterSearch"
      onSubmit={handleSubmit(onSearch, handleErrors)}
    >
      <div>
        <label>Datum: </label>
        <input
          type="date"
          placeholder="Datum"
          {...register("date", registerOption.date)}
        />
        {errors.date && <p className="error">{errors.date.message}</p>}
      </div>
      <div>
        <label>Starttid</label>
        <input
          type="time"
          {...register("startTime", registerOption.startTime)}
        />
        {errors.startTime && (
          <p className="error">{errors.startTime.message}</p>
        )}
      </div>
      <div>
        <label>Sluttid</label>
        <input type="time" {...register("endTime", registerOption.endTime)} />
        {errors.endTime && <p className="error">{errors.endTime.message}</p>}
      </div>
      <div>
        <label>Kategori: </label>
        <select {...register("category", registerOption.category)}>
          <option value="">Välj...</option>
          {initCategories.map((cat) => (
            <option key={cat.id} value={cat.id}>
              {cat.name}
            </option>
          ))}
        </select>
      </div>
      <div>
        <label>Inne/Ute: </label>
        <select {...register("inOutDoor", registerOption.inOutDoor)}>
          <option value="">Välj...</option>
          <option value="indoor">Inomhus</option>
          <option value="outdoor">Utomhus</option>
        </select>
      </div>
      <div>
        <label>Enbart tillgängliga tider: </label>
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
        <label>Antal platser: </label>
        <input
          type="number"
          placeholder="Ange antal"
          {...register("numberSpots", registerOption.numberSpots)}
        />
        {errors.numberSpots && (
          <p className="error">{errors.numberSpots.message}</p>
        )}
      </div>
      <div className="SearchReset">
        <button type="submit">Sök</button>
        <button type="button" onClick={handleReset}>
          Rensa filter
        </button>
      </div>
    </form>
  );
};

export default FilterSearchForm;

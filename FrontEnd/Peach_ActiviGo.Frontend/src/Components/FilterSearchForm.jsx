import React, { useEffect, useState } from "react";
import "../Styles/FilterSearchForm.css";
import { useForm } from "react-hook-form";
import { API_BASE_URL } from "../utils/constants";
import FetchContent from "./HelperFunctions/FetchContent";

const TranslatePayload = (formdata) => {
  const startDate = formdata.date
    ? new Date(
        `${formdata.date}T${formdata.startTime || "00:00"}:00`
      ).toISOString()
    : null;

  const endDate = formdata.date
    ? new Date(
        `${formdata.date}T${formdata.endTime || "23:59"}:00`
      ).toISOString()
    : null;

  const payload = {
    StartDate: startDate,
    EndDate: endDate,
    CategoryId: formdata.category ? Number(formdata.category) : null,
    IsIndoor: formdata.inOutDoor === "indoor" ? true : false,
    LocationId: null,
    OnlyAvailableSlots: formdata.availableSpotsOnly
      ? formdata.availableSpotsOnly === "true"
      : null,
  };
  return payload;
};

const FilterSearchForm = () => {
  const {
    register,
    watch,
    reset,
    handleSubmit,
    formState: { errors },
  } = useForm({ mode: "onChange" });

  const onSearch = async (formdata) => {
    const payload = TranslatePayload(formdata);
    console.log("Payload till API:", payload);

    const UrlAddOn = "/api/ActivityLocation/FilterActivityLocations";
    const activityLocations = await FetchContent(payload, UrlAddOn);
    console.log("Hämtade activityLocations", activityLocations);
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
        console.log("startTime:", startTime, "date:", date, "value:", value);
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
        <button type="submit">Search</button>
        <button type="button" onClick={handleReset}>
          Rensa filter
        </button>
      </div>
    </form>
  );
};

export default FilterSearchForm;

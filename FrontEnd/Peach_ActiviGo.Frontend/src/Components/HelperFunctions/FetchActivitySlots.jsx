import { useState, useEffect } from "react";
import FetchPeachApi from "./FetchPeachApi.jsx";
import { getLocalStorage, saveLocalStorage } from "./LocalStorage.jsx";

const FetchActivitySlots = (activityLocationId = null) => {
  const [slots, setSlots] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  // Hämta lokalt sparade bokade slots
  const getBookedSlots = () => {
    const bookedSlots = getLocalStorage("bookedSlots");
    return new Set(bookedSlots?.data || []);
  };

  // Spara en slot som bokad lokalt
  const markSlotAsBooked = (slotId) => {
    const bookedSlots = getBookedSlots();
    bookedSlots.add(slotId);
    saveLocalStorage("bookedSlots", Array.from(bookedSlots));
  };

  useEffect(() => {
    const apiCall = () => {
      setLoading(true);
      FetchPeachApi("/api/ActivitySlots")
        .then((data) => {
          const filteredData = activityLocationId
            ? data.filter(
                (slot) => slot.activityLocationId === activityLocationId
              )
            : data;

          // Filtrera bort lokalt sparade bokade slots
          const bookedSlots = getBookedSlots();
          const availableSlots = filteredData.filter(
            (slot) => !bookedSlots.has(slot.id)
          );

          setSlots(availableSlots);
        })
        .catch((error) => {
          setError(error.message);
          setSlots([]);
        })
        .finally(() => {
          setLoading(false);
        });
    };

    apiCall();
  }, [activityLocationId]);

  // Funktion för att ta bort en slot efter lyckad bokning
  const removeSlot = (slotId) => {
    // Markera som bokad i localStorage
    markSlotAsBooked(slotId);

    // Ta bort från aktuell lista
    setSlots((prevSlots) => prevSlots.filter((slot) => slot.id !== slotId));
  };

  // Returnera data som en custom hook
  return { slots, loading, error, removeSlot };
};

export default FetchActivitySlots;

import { useState, useEffect } from "react";
import FetchPeachApi from "./FetchPeachApi.jsx";
import { getLocalStorage, saveLocalStorage } from "./LocalStorage.jsx";

const BOOKED_SLOTS_KEY = "bookedSlots";

const getBookedSlotsSet = () => {
  const bookedSlots = getLocalStorage(BOOKED_SLOTS_KEY);
  return new Set(bookedSlots?.data || []);
};

const persistBookedSlotsSet = (bookedSlots) => {
  saveLocalStorage(BOOKED_SLOTS_KEY, Array.from(bookedSlots));
};

export const releaseBookedSlot = (slotId) => {
  if (slotId === undefined || slotId === null) {
    return;
  }
  const bookedSlots = getBookedSlotsSet();
  if (bookedSlots.delete(slotId)) {
    persistBookedSlotsSet(bookedSlots);
  }
};

const FetchActivitySlots = (activityLocationId = null) => {
  const [slots, setSlots] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  // Hämta lokalt sparade bokade slots
  const getBookedSlots = () => {
    return getBookedSlotsSet();
  };

  // Spara en slot som bokad lokalt
  const markSlotAsBooked = (slotId) => {
    const bookedSlots = getBookedSlotsSet();
    bookedSlots.add(slotId);
    persistBookedSlotsSet(bookedSlots);
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

  // Funktion för att uppdatera slotcapacity efter bokning
  const updateSlotCapacity = (slotId, remainingCapacity) => {
    setSlots((prevSlots) =>
      prevSlots.map((slot) => (slot.id ? { ...slot, remainingCapacity } : slot))
    );
  };

  // Returnera data som en custom hook
  return { slots, loading, error, updateSlotCapacity };
};

export default FetchActivitySlots;

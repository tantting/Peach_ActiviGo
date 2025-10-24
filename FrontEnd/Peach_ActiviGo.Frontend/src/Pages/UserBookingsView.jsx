import React, { useEffect, useState } from "react";
import {
  getUserBookings,
  cancelBooking,
} from "../Components/HelperFunctions/BookingService.js";
import FetchPeachApi from "../Components/HelperFunctions/FetchPeachApi.jsx";
import UserBookingCard from "../Components/UserBookingCard.jsx";
import { releaseBookedSlot } from "../Components/HelperFunctions/FetchActivitySlots.jsx";
import "../Styles/Bookings.css";

export default function MyBookingsView() {
  const [activeBookings, setActiveBookings] = useState([]);
  const [cancelledBookings, setCancelledBookings] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchBookings = async () => {
      try {
        // Hämta både bokningar och slots
        const [active, cancelled, allSlots, allLocations] = await Promise.all([
          getUserBookings("Active"),
          getUserBookings("Cancelled"),
          FetchPeachApi("/api/ActivitySlots"),
          FetchPeachApi("/api/ActivityLocation/GetAllActivityLocations"),
        ]);

        // Koppla ihop bokningar med slot-data
        const mergeWithSlots = (bookings) =>
          bookings.map((b) => {
            const slot = allSlots.find((s) => s.id === b.activitySlotId);
            const location = slot
              ? allLocations.find((loc) => loc.id === slot.activityLocationId)
              : null;
            return { ...b, activitySlot: slot, activityLocation: location };
          });

        setActiveBookings(mergeWithSlots(active));
        setCancelledBookings(mergeWithSlots(cancelled));
      } catch (error) {
        console.error("Fel vid hämtning av bokningar:", error.message);
      } finally {
        setLoading(false);
      }
    };

    fetchBookings();
  }, []);

  const handleCancel = async (id) => {
    const bookingToCancel = activeBookings.find((b) => b.id === id);
    if (!bookingToCancel) {
      return;
    }

    if (window.confirm("Vill du verkligen avboka denna bokning?")) {
      try {
        const cancelledBooking = await cancelBooking(id);
        alert("Bokning avbokad!");

        setActiveBookings((prev) => prev.filter((b) => b.id !== id));

        const slotId =
          bookingToCancel.activitySlotId || bookingToCancel.activitySlot?.id;
        if (slotId !== undefined && slotId !== null) {
          releaseBookedSlot(slotId);
        }

        const cancelledPayload =
          cancelledBooking && typeof cancelledBooking === "object"
            ? { ...bookingToCancel, ...cancelledBooking }
            : { ...bookingToCancel, status: "Cancelled" };

        setCancelledBookings((prev) => [
          ...prev.filter((b) => b.id !== cancelledPayload.id),
          cancelledPayload,
        ]);
      } catch (error) {
        alert("Kunde inte avboka: " + error.message);
      }
    }
  };

  if (loading) {
    return (
      <div className="page-container">
        <h1>Mina bokningar</h1>
        <p className="loading-text">Hämtar bokningar...</p>
      </div>
    );
  }

  return (
    <div className="page-container">
      <h1>Mina bokningar</h1>

      {/* KOMMANDE */}
      <section>
        <h2>Kommande bokningar</h2>
        {activeBookings.length === 0 ? (
          <p>Inga aktiva bokningar.</p>
        ) : (
          <div className="user-bookings-grid">
            {activeBookings.map((b) => (
              <UserBookingCard
                key={b.id}
                booking={b}
                activityLocation={b.activityLocation}
                onCancel={() => handleCancel(b.id)}
              />
            ))}
          </div>
        )}
      </section>

      {/* HISTORIK */}
      <section>
        <h2>Historik (avbokade)</h2>
        {cancelledBookings.length === 0 ? (
          <p>Inga avbokade aktiviteter.</p>
        ) : (
          <div className="user-bookings-grid">
            {cancelledBookings.map((b) => (
              <UserBookingCard
                key={b.id}
                booking={b}
                activityLocation={b.activityLocation}
                cancelled
              />
            ))}
          </div>
        )}
      </section>
    </div>
  );
}

// importera ActivitySlot.css
import "../Styles/ActivitySlot.css";
import { useContext, useState } from "react";
import { AuthContext } from "./AuthContext.jsx";
import { useNavigate } from "react-router-dom";
import createBooking from "./HelperFunctions/CreateBooking.jsx";
import { isTokenValid } from "./HelperFunctions/AuthService.js";

const ActivitySlots = ({ ActivitySlots, loading, error }) => {
  const { isAuthenticated } = useContext(AuthContext);
  const navigate = useNavigate();
  const [bookingStates, setBookingStates] = useState({});
  const handleBooking = async (slot, index) => {
    // Kontrollera om användaren är inloggad
    const tokenValid = isTokenValid();

    if (!isAuthenticated) {
      alert("Du måste logga in för att boka en aktivitet.");
      navigate("/login");
      return;
    }

    // Dubbelkolla token-validitet
    if (!tokenValid) {
      alert("Din session har gått ut. Vänligen logga in igen.");
      navigate("/login");
      return;
    }

    // Kontrollera om slot har ett ID
    if (!slot.id) {
      alert("Fel: Kunde inte hitta slot-ID för bokning.");
      return;
    }

    // Sätt loading state för denna specifika slot
    const oldState = bookingStates[index] || {};
    const newState = { loading: true, error: null };

    setBookingStates((prev) => ({
      ...prev,
      [index]: newState,
    }));

    try {
      const bookingData = {
        activitySlotId: slot.id,
      };

      const response = await createBooking(bookingData);

      // Sätt success state
      const successState = { loading: false, success: true, error: null };

      setBookingStates((prev) => ({
        ...prev,
        [index]: successState,
      }));

      alert(
        "Bokning lyckades! Du kan se dina bokningar under 'Mina bokningar'."
      );

      // Navigera till bokningssidan efter lyckad bokning
      setTimeout(() => {
        navigate("/bookings");
      }, 1000);
    } catch (error) {
      // Sätt error state
      const errorState = { loading: false, error: error.message };

      setBookingStates((prev) => ({
        ...prev,
        [index]: errorState,
      }));

      alert(`Fel vid bokning: ${error.message}`);
    }
  };

  if (loading) return <div>Laddar lediga tider...</div>;
  if (error) return <div>Fel vid laddning av tider: {error}</div>;

  if (!ActivitySlots || ActivitySlots.length === 0) {
    return <div>Inga lediga tider tillgängliga för tillfället.</div>;
  }

  return (
    <div className="activity-slots">
      {ActivitySlots.map((slot, index) => {
        const slotState = bookingStates[index] || {};

        return (
          <div key={`slot-${index}`} className="slot-item">
            <p>
              <strong>Starttid:</strong>{" "}
              {new Date(slot.startTime).toLocaleString("sv-SE")}
            </p>
            <p>
              <strong>Sluttid:</strong>{" "}
              {new Date(slot.endTime).toLocaleString("sv-SE")}
            </p>

            {slotState.success ? (
              <button className="book-slot-button booked" disabled>
                ✓ Bokad!
              </button>
            ) : (
              <button
                className="book-slot-button"
                onClick={() => handleBooking(slot, index)}
                disabled={slotState.loading}
              >
                {slotState.loading ? "Bokar..." : "Boka denna tid"}
              </button>
            )}

            {slotState.error && (
              <p className="error-message">Fel: {slotState.error}</p>
            )}
          </div>
        );
      })}
    </div>
  );
};

export default ActivitySlots;

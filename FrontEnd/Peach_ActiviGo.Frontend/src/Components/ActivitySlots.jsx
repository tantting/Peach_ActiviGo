// importera ActivitySlot.css
import "../Styles/ActivitySlot.css";
import { useContext, useState } from "react";
import { AuthContext } from "./AuthContext.jsx";
import { useNavigate } from "react-router-dom";
import createBooking from "./HelperFunctions/CreateBooking.jsx";
import { isTokenValid } from "./HelperFunctions/AuthService.js";

const ActivitySlots = ({ ActivitySlots, loading, error, onSlotBooked }) => {
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
      
      // Ta bort sloten från listan efter lyckad bokning
      if (onSlotBooked) {
        onSlotBooked(slot.id);
      }
      
      // Ändra string till den plats som bokningarna ska hamna på för en user
      alert(
        "Bokning lyckades! Du kan se dina bokningar under 'Mina bokningar'."
      );
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
        const isLoading = slotState.loading;
        const hasError = slotState.error;
        const isSuccess = slotState.success;

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

            <button
              className={`book-slot-button ${isLoading ? "loading" : ""} ${
                isSuccess ? "success" : ""
              } ${hasError ? "error" : ""}`}
              onClick={() => handleBooking(slot, index)}
              disabled={isLoading || isSuccess}
            >
              {isLoading
                ? "Bokar..."
                : isSuccess
                ? "Bokad!"
                : hasError
                ? "Försök igen"
                : "Boka denna tid"}
            </button>

            {hasError && (
              <p
                className="error-message"
                style={{ color: "red", fontSize: "0.9em" }}
              >
                {slotState.error}
              </p>
            )}
          </div>
        );
      })}
    </div>
  );
};

export default ActivitySlots;

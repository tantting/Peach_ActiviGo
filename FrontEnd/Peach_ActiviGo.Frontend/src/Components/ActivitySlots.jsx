// importera ActivitySlot.css
import "../Styles/ActivitySlot.css";
import { useContext, useState } from "react";
import { AuthContext } from "./AuthContext.jsx";
import { useNavigate } from "react-router-dom";
import createBooking from "./HelperFunctions/CreateBooking.jsx";
import { isTokenValid } from "./HelperFunctions/AuthService.js";
import { toast } from "react-toastify";

/**
 *
 *
 * @param {slot} { Array avslots }
 * @param {loading} { Bool som indikerar om data laddas }
 * @param {error} { Eventuell felinformation vid laddning av slots }
 * @param {onSlotBooked} { Callback-funktion som anropas vid lyckad bokning av slot }
 * @return {*}
 */
const ActivitySlots = ({ slots, loading, error, onSlotBooked }) => {
  const { isAuthenticated } = useContext(AuthContext);
  const [bookingStates, setBookingStates] = useState({});
  const navigate = useNavigate();

  const handleBooking = async (slot, index) => {
    // Kontrollera om användaren är inloggad
    const tokenValid = isTokenValid();

    // Om inte inloggad, omdirigera till login-sidan
    if (!isAuthenticated) {
      toast.info("Du måste logga in för att boka en aktivitet.");
      navigate("/login");
      return;
    }

    // Dubbelkolla token-validitet
    if (!tokenValid) {
      toast.warning("Din session har gått ut. Vänligen logga in igen.");
      navigate("/login");
      return;
    }

    // Kontrollera om slot har ett ID
    if (!slot.id) {
      toast.error("Fel: Kunde inte hitta slot-ID för bokning.");
      return;
    }

    // Sätt loading state för denna specifika slot
    setBookingStates((prev) => ({
      ...prev,
      [index]: { loading: true, error: null },
    }));

    try {
      const bookingData = {
        activitySlotId: slot.id,
      };

      await createBooking(bookingData);

      // Sätt success state
      setBookingStates((prev) => ({
        ...prev,
        [index]: { loading: false, success: true, error: null },
      }));

      // Ta bort sloten från listan efter lyckad bokning
      if (onSlotBooked) {
        onSlotBooked(slot.id);
      }

      // Ändra string till den plats som bokningarna ska hamna på för en user
      toast.success(
        "Bokning lyckades! Du kan se dina bokningar under 'Mina bokningar'."
      );
    } catch (error) {
      // Sätt error state
      setBookingStates((prev) => ({
        ...prev,
        [index]: { loading: false, error: error.message },
      }));

      toast.error(`Fel vid bokning: ${error.message}`);
    }
  };
  if (loading) return <div>Laddar lediga tider...</div>;
  if (error) return <div>Fel vid laddning av tider: {error}</div>;

  if (!slots || slots.length === 0) {
    return <div>Inga lediga tider tillgängliga för tillfället.</div>;
  }

  return (
    <div className="activity-slots">
      {slots.map((slot, index) => {
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

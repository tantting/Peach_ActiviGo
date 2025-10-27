import WeatherCard from "./WeatherCard";
import FetchWeather from "./HelperFunctions/FetchWeather";

export default function UserBookingCard({
  booking,
  onCancel,
  cancelled = false,
  activityLocation,
}) {
  // Grundinfo från BookingDto
  const activityName =
    booking?.activity || activityLocation?.activityName || "Okänd aktivitet";
  const locationName =
    booking?.location || activityLocation?.locationName || "Okänd plats";

  const startTime = booking?.startTime
    ? new Date(booking.startTime).toLocaleString("sv-SE")
    : "Okänt startdatum";

  const endTime = booking?.endTime
    ? new Date(booking.endTime).toLocaleString("sv-SE")
    : "Okänt slutdatum";

  const statusLabel = cancelled
    ? "Avbokad"
    : booking?.status === "Cancelled"
    ? "Avbokad"
    : "Aktiv";

  const statusIcon =
    statusLabel === "Aktiv" ? "✅" : statusLabel === "Avbokad" ? "❌" : "⚠️";

  const isIndoor =
    activityLocation?.isIndoor === true
      ? "🏠 Inomhus"
      : activityLocation?.isIndoor === false
      ? "🌤️ Utomhus"
      : "Okänt";

  // Hämta väderdata endast om aktiviteten är utomhus
  const { weather, weatherLoading } =
    activityLocation && !activityLocation.isIndoor
      ? FetchWeather({
          latitude: activityLocation.latitude,
          longitude: activityLocation.longitude,
          locationName: activityLocation.locationName,
          cacheKey: `weather_detail_${activityLocation.id}`,
        })
      : { weather: null, weatherLoading: false };

  return (
    <div
      className={`activity-detail user-booking-detail ${
        cancelled ? "cancelled" : ""
      }`}
    >
      {/* Titel & plats */}
      <h2>{activityName}</h2>
      <h3>📍 {locationName}</h3>

      {/* Info */}
      <div className="activity-info">
        <p>
          <strong>Status:</strong> {statusIcon} {statusLabel}
        </p>
        <p>
          <strong>Typ:</strong> {isIndoor}
        </p>
      </div>

      {/* Väder */}
      {!activityLocation?.isIndoor && (
        <div className="weather-section">
          <h3>🌤️ Väderprognos</h3>
          <WeatherCard
            weather={weather}
            weatherLoading={weatherLoading}
            locationName={activityLocation?.locationName}
          />
        </div>
      )}

      {/* Bokad tid */}
      <div className="activity-slots-section user-booking-slot">
        <h3>📅 Bokad tid</h3>
        <div className="user-booking-slot-card">
          <p>
            <strong>Start:</strong> {startTime}
          </p>
          <p>
            <strong>Slut:</strong> {endTime}
          </p>
          <p>
            <strong>Antal platser</strong>: {booking.numberOfParticipants}
          </p>
        </div>
      </div>

      {/* Avboka eller avbokad */}
      {!cancelled ? (
        <div className="user-booking-actions">
          <button
            type="button"
            className="cancel-booking-button"
            onClick={onCancel}
          >
            Avboka
          </button>
        </div>
      ) : (
        <p className="user-booking-cancelled-at">❌ Avbokad</p>
      )}
    </div>
  );
}

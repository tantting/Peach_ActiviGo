import { useNavigate } from "react-router-dom";
import WeatherCard from "./WeatherCard";
import FetchWeather from "./HelperFunctions/FetchWeather";
import FetchActivitySlots from "./HelperFunctions/FetchActivitySlots";
import { buildImageUrl } from "../utils/constants";
import ActivitySlots from "./ActivitySlots";

export default function ActivityDetail({ activityLocation, loading, error }) {
  const navigate = useNavigate();

  // Hämta väderdata endast för utomhusaktiviteter
  const { weather, weatherLoading } =
    activityLocation && !activityLocation.isIndoor
      ? FetchWeather({
          latitude: activityLocation.latitude,
          longitude: activityLocation.longitude,
          locationName: activityLocation.locationName,
          cacheKey: `weather_detail_${activityLocation.id}`,
        })
      : { weather: null, weatherLoading: false };

  // Hämta aktivitetsslots
  const {
    slots: activitySlots,
    loading: slotsLoading,
    error: slotsError,
    removeSlot,
  } = FetchActivitySlots(activityLocation?.id);

  if (loading) {
    return <p>Laddar aktivitet...</p>;
  }

  if (error) {
    return (
      <div>
        <h3>Fel vid laddning</h3>
        <p>Kunde inte ladda aktivitet: {error}</p>
        <button onClick={() => navigate("/activities")}>
          ← Tillbaka till aktiviteter
        </button>
      </div>
    );
  }

  if (!activityLocation) {
    return (
      <div>
        <h3>Aktivitet hittades inte</h3>
        <p>Aktiviteten kunde inte hittas.</p>
        <button onClick={() => navigate("/activities")}>
          ← Tillbaka till aktiviteter
        </button>
      </div>
    );
  }

  return (
    <div className="activity-detail">
      <h2>{activityLocation.activityName}</h2>
      <h3>📍 {activityLocation.locationName}</h3>

      <div className="activity-info">
        <p>
          <strong>Status:</strong>{" "}
          {activityLocation.isActive ? "✅ Aktiv" : "❌ Inaktiv"}
        </p>
        <p>
          <strong>Typ:</strong>{" "}
          {activityLocation.isIndoor ? "🏠 Inomhus" : "🌤️ Utomhus"}
        </p>
        {activityLocation.capacity && (
          <p>
            <strong>Kapacitet:</strong> {activityLocation.capacity} personer
          </p>
        )}
      </div>

      {activityLocation.imageUrl && (
        <div className="activity-image-container">
          <img
            src={buildImageUrl(activityLocation.imageUrl)}
            alt={activityLocation.activityName}
            className="activity-detail-image"
          />
        </div>
      )}

      {/* Back button placerad under bilden */}
      <div className="back-button-container">
        <button onClick={() => navigate("/")} className="back-button">
          ← Tillbaka till aktiviteter
        </button>
      </div>

      {/* Visa väder endast för utomhusaktiviteter */}
      {!activityLocation.isIndoor && (
        <div className="weather-section">
          <h3>🌤️ Väderprognos</h3>
          <WeatherCard
            weather={weather}
            weatherLoading={weatherLoading}
            locationName={activityLocation.locationName}
          />
        </div>
      )}

      {/* Visa aktivitetsslots */}
      <div className="activity-slots-section">
        <h3>📅 Lediga tider</h3>
        <ActivitySlots
          slots={activitySlots}
          loading={slotsLoading}
          error={slotsError}
          onSlotBooked={removeSlot}
        />
      </div>
    </div>
  );
}

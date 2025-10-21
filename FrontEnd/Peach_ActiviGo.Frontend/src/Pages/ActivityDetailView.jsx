import { useParams, useLocation, useNavigate } from "react-router-dom";
import { useState, useEffect } from "react";
import FetchPeachApi from "../Components/HelperFunctions/FetchPeachApi";
import WeatherCard from "../Components/WeatherCard";
import FetchWeather from "../Components/HelperFunctions/FetchWeather";
import { buildImageUrl } from "../utils/constants";
import "../Styles/Activity.css";

export default function ActivityDetailView() {
  const { id } = useParams();
  const location = useLocation();
  const navigate = useNavigate();

  const [activityLocation, setActivityLocation] = useState(
    location.state?.activityLocation || null
  );
  const [loading, setLoading] = useState(!activityLocation);
  const [error, setError] = useState(null);

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

  useEffect(() => {
    if (activityLocation) return; // Vi har redan data

    const fetchActivityDetail = async () => {
      try {
        setLoading(true);
        // Korrigerat endpoint - borde vara ActivityLocation istället för Activities
        const data = await FetchPeachApi(
          `/api/ActivityLocation/GetActivityLocationById/${id}`
        );
        setActivityLocation(data);
      } catch (err) {
        setError(err.message);
      } finally {
        setLoading(false);
      }
    };

    if (id) {
      fetchActivityDetail();
    } else {
      setError("Inget aktivitets-ID hittades");
    }
  }, [id, activityLocation]);

  if (loading) {
    return (
      <div className="page-container">
        <h1>Laddar aktivitet...</h1>
      </div>
    );
  }

  if (error) {
    return (
      <div className="page-container">
        <h1>Fel vid laddning</h1>
        <p>Kunde inte ladda aktivitet: {error}</p>
        <button onClick={() => navigate("/activities")}>
          ← Tillbaka till aktiviteter
        </button>
      </div>
    );
  }

  if (!activityLocation) {
    return (
      <div className="page-container">
        <h1>Aktivitet hittades inte</h1>
        <p>Aktivitet med ID {id} kunde inte hittas.</p>
        <button onClick={() => navigate("/activities")}>
          ← Tillbaka till aktiviteter
        </button>
      </div>
    );
  }

  return (
    <div className="page-container">
      <h1>Aktivitetsdetaljer</h1>
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

        <div className="action-buttons">
          <button onClick={() => navigate("/")} className="back-button">
            ← Tillbaka till aktiviteter
          </button>

          <button className="book-button">
            📅 Boka {activityLocation.activityName}
          </button>
        </div>
      </div>
    </div>
  );
}

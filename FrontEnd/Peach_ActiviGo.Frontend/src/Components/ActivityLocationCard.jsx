import { Link } from "react-router-dom";
import WeatherCard from "./WeatherCard";
import FetchWeather from "./HelperFunctions/FetchWeather";

const ActivityLocationCard = ({ activityLocation }) => {
  // Hämta väderdata endast för utomhusaktiviteter
  const { weather, weatherLoading } = activityLocation.isIndoor
    ? { weather: null, weatherLoading: false }
    : FetchWeather({
        latitude: activityLocation.latitude,
        longitude: activityLocation.longitude,
        locationName: activityLocation.locationName,
        cacheKey: `weather_${activityLocation.id}`, // Unik cache för varje aktivitet
      });

  return (
    <div className="activity-card">
      <h2>Plats: {activityLocation.locationName}</h2>
      <p>Aktivitet: {activityLocation.activityName}</p>
      <p>Status: {activityLocation.isActive ? "Aktiv" : "Inaktiv"}</p>
      <p>{activityLocation.isIndoor ? "Inomhus" : "Utomhus"}</p>
      <p>
        <img
          className="activity-image"
          src={
            activityLocation.imageUrl?.startsWith("https")
              ? activityLocation.imageUrl
              : `https://localhost:7242${activityLocation.imageUrl}`
          }
          alt={activityLocation.activityName}
          onError={(event) => {
            console.error("Bilden kunde inte laddas:", event.target.src);
            event.target.style.border = "2px solid red";
            event.target.alt = "Bilden kunde inte laddas";
          }}
        />
      </p>
      <button>
        <Link
          to={`/activity/${activityLocation.id}`}
          state={{ activityLocation }}
          className="booking-button"
        >
          Boka {activityLocation.activityName} nu!
        </Link>
      </button>
    </div>
  );
};

export default ActivityLocationCard;

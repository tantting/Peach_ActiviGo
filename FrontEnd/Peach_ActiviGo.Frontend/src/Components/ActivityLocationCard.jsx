import { Link } from "react-router-dom";
import WeatherCard from "./WeatherCard";

const ActivityLocationCard = ({
  activityLocation,
  weather,
  weatherLoading,
}) => {
  return (
    <div className="activity-card">
      <h2>Plats: {activityLocation.locationName}</h2>
      <p>Aktivitet: {activityLocation.activityName}</p>
      <p>Status: {activityLocation.isActive ? "Aktiv" : "Inaktiv"}</p>

      <WeatherCard
        weather={weather}
        weatherLoading={weatherLoading}
        locationName={activityLocation.locationName}
      />

      {/* Detta är bara ett exempel på hur man skulle kunna lägga till en bokningsknapp */}
      <Link to="/contact" className="booking-button">
        Boka {activityLocation.activityName} nu!
      </Link>
    </div>
  );
};

export default ActivityLocationCard;

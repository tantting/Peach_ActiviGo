import WeatherCard from "./WeatherCard";

const ActivityLocationCard = ({
  activityLocation,
  weather,
  weatherLoading,
}) => {
  return (
    <div className="activity-card">
      <h3>{activityLocation.activityName}</h3>
      <p>Plats: {activityLocation.locationName}</p>
      <p>Status: {activityLocation.isActive ? "Aktiv" : "Inaktiv"}</p>

      <WeatherCard weather={weather} weatherLoading={weatherLoading} />
    </div>
  );
};

export default ActivityLocationCard;

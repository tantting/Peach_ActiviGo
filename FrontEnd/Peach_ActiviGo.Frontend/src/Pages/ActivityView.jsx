import FetchActivityLocations from "../Components/FetchActivityLocations";
import FetchWeather from "../Components/FetchWeather";
import ActivityLocationCard from "../Components/ActivityLocationCard";
import "../Styles/Activity.css";

export default function Aktiviteter() {
  const { activityLocations, loading, error } = FetchActivityLocations();
  const { weather, weatherLoading } = FetchWeather();

  if (loading) {
    return (
      <div className="page-container">
        <h1>Aktiviteter</h1>
        <p>Laddar aktiviteter...</p>
      </div>
    );
  }

  if (error) {
    return (
      <div className="page-container">
        <h1>Aktiviteter</h1>
        <div className="error-message">
          <h3>Fel vid hämtning av aktiviteter:</h3>
          <p>{error}</p>
        </div>
      </div>
    );
  }

  return (
    <div className="page-container">
      <h1>Populära Aktiviteter</h1>
      <div className="activities-grid">
        {activityLocations.length > 0 ? (
          activityLocations.map((activityLocation) => (
            <ActivityLocationCard
              key={activityLocation.id}
              activityLocation={activityLocation}
              weather={weather}
              weatherLoading={weatherLoading}
            />
          ))
        ) : (
          <div className="activity-card">
            <h3>Inga aktiviteter hittades</h3>
            <p>Det finns inga aktiva aktiviteter att visa just nu.</p>
          </div>
        )}
      </div>
    </div>
  );
}

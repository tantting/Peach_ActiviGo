import FetchActivity from '../Components/FetchActivity'
import FetchWeather from '../Components/FetchWeather'
import WeatherCard from '../Components/WeatherCard'
import '../Styles/Activity.css'

export default function Aktiviteter() {
  const { activities, loading, error } = FetchActivity();
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
        {activities.length > 0 ? (
          activities.map((activity) => (
            <div key={activity.id} className="activity-card">
              <h3>{activity.activityName}</h3>
              <p>Plats: {activity.locationName}</p>
              <p>Status: {activity.isActive ? 'Aktiv' : 'Inaktiv'}</p>

              <WeatherCard weather={weather} weatherLoading={weatherLoading} />
            </div>
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
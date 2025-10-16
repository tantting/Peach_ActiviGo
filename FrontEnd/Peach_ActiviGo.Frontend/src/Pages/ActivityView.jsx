import FetchActivity from '../Components/FetchActivity'
import FetchWeather from '../Components/FetchWeather'
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

              <div className="weather-container">
                {weatherLoading ? (
                  <p>Laddar väder...</p>
                ) : weather ? (
                  <div className="weather-content">
                    <div className="weather-text">
                      <h4>Väder i {weather.name}</h4>
                      <p>Temperatur: {weather.main.temp}°C</p>
                      <p>Förhållande: {weather.weather[0].description}</p>
                      <p>Känns som: {weather.main.feels_like}°C</p>
                    </div>
                    <img
                      className="weather-image"
                      src={`http://openweathermap.org/img/wn/${weather.weather[0].icon}.png`}
                      alt={weather.weather[0].description}
                    />
                  </div>
                ) : (
                  <p>Kunde inte hämta väderdata</p>
                )}
              </div>
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
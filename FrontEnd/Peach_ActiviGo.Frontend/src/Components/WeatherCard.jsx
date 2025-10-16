import "../Styles/WeatherCard.css";

const WeatherCard = ({ weather, weatherLoading, showLocationName = true }) => {
  if (weatherLoading) {
    return (
      <div className="weather-container">
        <p>Laddar väder...</p>
      </div>
    );
  }

  if (!weather) {
    return (
      <div className="weather-container">
        <p>Kunde inte hämta väderdata</p>
      </div>
    );
  }

  return (
    <div className="weather-container">
      <div className="weather-content">
        <div className="weather-text">
          {showLocationName && <h4>Väder i {weather.name || "Okänd plats"}</h4>}
          <p>Temperatur: {Math.round(weather.main.temp)}°C</p>
          <p>Förhållande: {weather.weather[0].description}</p>
          <p>Känns som: {Math.round(weather.main.feels_like)}°C</p>
        </div>
        <img
          className="weather-image"
          src={`https://openweathermap.org/img/wn/${weather.weather[0].icon}@2x.png`}
          alt={weather.weather[0].description}
          onError={(e) => {
            e.target.style.display = "none";
            console.error("Failed to load weather icon:", e.target.src);
          }}
        />
      </div>
    </div>
  );
};

export default WeatherCard;

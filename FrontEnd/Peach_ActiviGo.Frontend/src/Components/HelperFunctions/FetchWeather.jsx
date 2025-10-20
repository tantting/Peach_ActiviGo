import { useState, useEffect } from "react";
import { saveLocalStorage, getTimedCache } from "./LocalStorage";
import FetchWeatherApi from "./FetchWeatherApi";
import {
  WEATHER_CACHE_DURATION,
  DEFAULT_COORDINATES,
  CACHE_KEYS,
} from "../../utils/constants.js";

const FetchWeather = ({ latitude, longitude, locationName, cacheKey }) => {
  const [weather, setWeather] = useState(null);
  const [weatherLoading, setWeatherLoading] = useState(true);

  // Fallback till Varbergs koordinater om inga koordinater anges
  const lat = latitude || DEFAULT_COORDINATES.latitude;
  const lon = longitude || DEFAULT_COORDINATES.longitude;

  // Skapa en unik cache-nyckel för denna plats
  const WEATHER_CACHE_KEY = cacheKey || CACHE_KEYS.weather(lat, lon);

  useEffect(() => {
    let isCancelled = false; // För att undvika state-uppdatering om komponenten avmonteras

    const fetchWeather = () => {
      FetchWeatherApi({
        latitude: lat,
        longitude: lon,
        locationName: locationName,
      })
        .then((data) => {
          if (!isCancelled) {
            console.log("Weather data received for:", data.name, data); // Debug: Visa vad vi får från API:et
            setWeather(data); // Sätt väderdata i setWeather state
            setWeatherLoading(false); // Sätt loading till false när data är hämtad
            saveLocalStorage(WEATHER_CACHE_KEY, data); // Spara i localStorage via LocalStorage.jsx
          }
        })
        .catch((error) => {
          if (!isCancelled) {
            console.error(
              "Error fetching weather for",
              locationName || "coordinates",
              error
            );
            setWeatherLoading(false);
          }
        });
    };

    // Hämtar från cache om tiden för WEATHER_CACHE_DURATION har gått ut
    const cachedWeather = getTimedCache(
      WEATHER_CACHE_KEY,
      WEATHER_CACHE_DURATION
    );

    if (cachedWeather) {
      setWeather(cachedWeather);
      setWeatherLoading(false);
      return;
    }

    fetchWeather();

    // Cleanup function för att undvika state-uppdatering om komponenten avmonteras
    // Om man till exempel navigerar bort från sidan innan fetchen är klar.
    return () => {
      isCancelled = true;
    };
  }, [lat, lon, locationName]); // Lägg till dependencies så att effekten körs igen om koordinater/plats ändras

  // Returnera state som en custom hook
  return { weather, weatherLoading };
};

export default FetchWeather;

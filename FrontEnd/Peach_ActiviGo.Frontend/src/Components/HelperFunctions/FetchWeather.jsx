import { useState, useEffect } from "react";
import { saveLocalStorage, getTimedCache } from "./LocalStorage";
import axios from "axios";

const WEATHER_API_KEY = import.meta.env.VITE_WEATHER_API_KEY;
const WEATHER_CACHE_DURATION = 10 * 60 * 1000; // 10 minuter

const FetchWeather = ({ latitude, longitude, locationName, cacheKey }) => {
  const [weather, setWeather] = useState(null);
  const [weatherLoading, setWeatherLoading] = useState(true);

  // Fallback till Varbergs koordinater om inga koordinater anges
  const lat = latitude || "57.1056";
  const lon = longitude || "12.2508";

  // Skapa en unik cache-nyckel för denna plats
  const WEATHER_CACHE_KEY = cacheKey || `weatherData_${lat}_${lon}`;

  useEffect(() => {
    let isCancelled = false; // För att undvika state-uppdatering om komponenten avmonteras

    const fetchWeather = () => {
      // Bygg URL baserat på vad som finns tillgängligt
      let url = `https://api.openweathermap.org/data/2.5/weather?appid=${WEATHER_API_KEY}&units=metric&lang=sv`;

      // Om vi har koordinater, använd dem (mer exakt)
      if (lat && lon) {
        url += `&lat=${lat}&lon=${lon}`;
      }
      // Annars försök med stadsnamn om det finns
      else if (locationName) {
        url += `&q=${encodeURIComponent(locationName)}`;
      }
      // Fallback till Varberg <3
      else {
        url += `&lat=57.1056&lon=12.2508`;
      }

      axios
        .get(url)
        .then((response) => {
          if (!isCancelled) {
            console.log(
              "Weather data received for:",
              response.data.name,
              response.data
            ); // Debug: Visa vad vi får från API:et
            setWeather(response.data); // Sätt väderdata i setWeather state
            setWeatherLoading(false); // Sätt loading till false när data är hämtad
            saveLocalStorage(WEATHER_CACHE_KEY, response.data); // Spara i localStorage via LocalStorage.jsx
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

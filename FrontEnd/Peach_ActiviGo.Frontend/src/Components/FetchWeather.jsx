import { useState, useEffect } from 'react'
import { saveLocalStorage, getTimedCache } from './LocalStorage'

const WEATHER_API_KEY = import.meta.env.VITE_WEATHER_API_KEY;
const WEATHER_CACHE_DURATION = 10 * 60 * 1000; // 10 minuter
const WEATHER_CACHE_KEY = 'weatherData';

const FetchWeather = () => {
  const [weather, setWeather] = useState(null);
  const [weatherLoading, setWeatherLoading] = useState(true);

  useEffect(() => {
    let isCancelled = false; // För att undvika state-uppdatering om komponenten avmonteras

    const fetchWeather = () => {
      fetch(`https://api.openweathermap.org/data/2.5/weather?q=Varberg,SE&appid=${WEATHER_API_KEY}&units=metric&lang=sv`)
        .then((response) => response.json())
        .then((data) => {
          if (!isCancelled) {
            setWeather(data);
            setWeatherLoading(false);

            // Spara i localStorage via LocalStorage
            saveLocalStorage(WEATHER_CACHE_KEY, data);
          }
        })
        .catch((error) => {
          if (!isCancelled) {
            console.error('Error fetching weather:', error);
            setWeatherLoading(false);
          }
        });
    };

    // Hämtar från cache om tiden för WEATHER_CACHE_DURATION har gått ut
    const cachedWeather = getTimedCache(WEATHER_CACHE_KEY, WEATHER_CACHE_DURATION);
    
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
  }, []);

  // Returnera state som en custom hook
  return { weather, weatherLoading };
}

export default FetchWeather
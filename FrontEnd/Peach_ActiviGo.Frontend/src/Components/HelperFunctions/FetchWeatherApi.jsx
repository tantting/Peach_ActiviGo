import axios from "axios";
import {
  WEATHER_API_BASE_URL,
  REQUEST_TIMEOUT,
  DEFAULT_COORDINATES,
} from "../../utils/constants.js";

// Skapa en Axios instans specifikt för OpenWeatherMap API
const weatherApiClient = axios.create({
  baseURL: WEATHER_API_BASE_URL,
  timeout: REQUEST_TIMEOUT,
  params: {
    appid: import.meta.env.VITE_WEATHER_API_KEY,
    units: "metric",
    lang: "sv",
  },
});

/**
 * Hämta väderdata från OpenWeatherMap API
 * @param {Object} params - Parametrar för väder-API:et
 * @param {string} params.latitude - Latitud
 * @param {string} params.longitude - Longitud
 * @param {string} params.locationName - Alternativt stadsnamn
 * @returns {Promise} - Promise som returnerar väderdata
 */
const FetchWeatherApi = ({ latitude, longitude, locationName }) => {
  const params = {};

  // Om vi har koordinater, använd dem
  if (latitude && longitude) {
    params.lat = latitude;
    params.lon = longitude;
  }
  // Annars försök med stadsnamn om det finns
  else if (locationName) {
    params.q = locationName;
  }
  // Fallback till Varberg <3
  else {
    params.lat = DEFAULT_COORDINATES.latitude;
    params.lon = DEFAULT_COORDINATES.longitude;
  }

  return weatherApiClient
    .get("/weather", { params })
    .then((response) => {
      console.log("Weather data received:", response.data);
      return response.data;
    })
    .catch((error) => {
      const errorMessage = error.response?.data?.message || error.message;
      console.error("Weather API Error:", errorMessage);
      throw new Error(errorMessage);
    });
};

export default FetchWeatherApi;

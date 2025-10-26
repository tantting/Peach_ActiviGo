/*https://dev.to/papybyte/async-await-vs-fetchthen-20oe*/

/*
POST, GET, PUT, DELETE requests till Peach API med Axios

POST exempel
FetchPeachApi({ method: "POST", url: "/api/ActivityLocation/", data: {
  activityName: "Ny aktivitet",
  locationName: "Ny plats"
} })

GET exempel
FetchPeachApi({ method: "GET", url: "/api/ActivityLocation/" })

PUT exempel
FetchPeachApi({ method: "PUT", url: "/api/ActivityLocation/1", data: {
  activityName: "Uppdaterad aktivitet",
  locationName: "Uppdaterad plats"
} })

DELETE exempel
FetchPeachApi({ method: "DELETE", url: "/api/ActivityLocation/1" })
*/

import axios from "axios";
import { API_BASE_URL, REQUEST_TIMEOUT } from "../../utils/constants.js";
import { getToken } from "./AuthService.js";

// Skapa en Axios instans med base URL och default konfiguration
const apiClient = axios.create({
  baseURL: API_BASE_URL,
  headers: {
    "Content-Type": "application/json", // Standard header för JSON
  },
  timeout: REQUEST_TIMEOUT, // om servern inte svarar inom 10 sekunder så skickas ett timeout error.
});

// Lägg till request interceptor för authorization
apiClient.interceptors.request.use((config) => {
  // Lägg till token automatiskt
  const token = getToken();
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

/**
 * Generisk API-funktion för Peach API med Axios
 * @param {string} endpoint - API endpoint (t.ex. "/api/ActivityLocation/GetAllActivityLocations")
 * @param {Object} options - Axios options (method, headers, data, etc.)
 * @returns {Promise} - Promise som returnerar data eller error
 */
const FetchPeachApi = (endpoint, options = {}) => {
  // Default värden för Axios
  const defaultOptions = {
    method: "GET",
    url: endpoint,
    ...options, // Skriver över default options OM något skickas in.
  };

  return apiClient(defaultOptions)
    .then((response) => {
      console.log("Fetched data:", response.data);
      return response.data;
    })
    .catch((error) => {
      const errorMessage =
        error.response?.data?.message ||
        error.response?.statusText ||
        error.message;
      console.error("API Error:", errorMessage);
      console.error("Full error:", error);
      throw new Error(errorMessage);
    });
};

export default FetchPeachApi;

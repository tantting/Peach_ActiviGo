// API Endpoints
export const API_BASE_URL = "https://localhost:7242";

// Weather API
export const WEATHER_API_BASE_URL = "https://api.openweathermap.org/data/2.5";
export const WEATHER_CACHE_DURATION = 10 * 60 * 1000; // 10 minuter

// Default coordinates (Varberg)
export const DEFAULT_COORDINATES = {
    latitude: "57.1056",
    longitude: "12.2508",
    name: "Varberg"
};

// Cache keys
export const CACHE_KEYS = {
    weather: (lat, lon) => `weatherData_${lat}_${lon}`,
    activityLocations: "activityLocations",
    bookings: "bookings"
};

// HTTP timeouts
export const REQUEST_TIMEOUT = 10000; // 10 sekunder
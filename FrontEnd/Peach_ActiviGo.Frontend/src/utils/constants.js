// This file contains constant values used throughout the application that can be used throughout the project.

// API Endpoints
export const API_BASE_URL = import.meta.env.VITE_API_BASE_URL;

// API Endpoint paths
export const API_ENDPOINTS = {
  authentication: {
    login: "/api/Authentication/login",
    register: "/api/Authentication/CreateAccount"
  },
  booking: "/api/Booking",
  activityLocation: "/api/ActivityLocation",
  activitySlots: "/api/ActivitySlots",
  activities: "/api/activities",
  locations: "/api/Location",
};


// Weather API
export const WEATHER_API_BASE_URL = "https://api.openweathermap.org/data/2.5";
export const WEATHER_CACHE_DURATION = 10 * 60 * 1000; // 10 minuter

// Default coordinates (Varberg)
export const DEFAULT_COORDINATES = {
  latitude: "57.1056",
  longitude: "12.2508",
  name: "Varberg",
};

// Cache keys
export const CACHE_KEYS = {
  weather: (lat, lon) => `weatherData_${lat}_${lon}`,
  activityLocations: "activityLocations",
  bookings: "bookings",
};

// Add Timeouts
export const REQUEST_TIMEOUT = 10000; // 10 sekunder

// Helper function to build correct image URLs
export const buildImageUrl = (imageUrl) => {
  if (!imageUrl) return null;

  // If it's already a full URL, return as is
  if (imageUrl.startsWith("https") || imageUrl.startsWith("http")) {
    return imageUrl;
  }

  // Remove any existing path segments and ensure we use /images/
  let cleanImageUrl = imageUrl;

  // Remove leading slash if present
  if (cleanImageUrl.startsWith("/")) {
    cleanImageUrl = cleanImageUrl.substring(1);
  }

  // Remove wwwroot if present in the path
  if (cleanImageUrl.includes("wwwroot/")) {
    cleanImageUrl = cleanImageUrl.split("wwwroot/")[1];
  }

  // Remove old folder name and use images
  // This handles cases where the backend still returns old paths
  const pathSegments = cleanImageUrl.split("/");
  if (pathSegments.length > 1) {
    // Keep only the filename, replace folder with 'images'
    cleanImageUrl = `images/${pathSegments[pathSegments.length - 1]}`;
  } else {
    // If it's just a filename, add images folder
    cleanImageUrl = `images/${cleanImageUrl}`;
  }

  return `${API_BASE_URL}/${cleanImageUrl}`;
};

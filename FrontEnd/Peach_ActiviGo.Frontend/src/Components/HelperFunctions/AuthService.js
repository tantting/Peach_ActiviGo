import axios from "axios";
import { saveLocalStorage, getLocalStorage } from "./LocalStorage";

const API_URL = "https://localhost:7242/api/Authentication";

// Registrera användare
export const registerUser = async (userData) => {
  try {
    const response = await axios.put(`${API_URL}/CreateAccount`, userData);
    return response.data;
  } catch (error) {
    console.error(
      "Fel vid registrering:",
      error.response?.data || error.message
    );
    throw error;
  }
};

// Logga in användare
export const loginUser = async (credentials) => {
  try {
    const response = await axios.post(`${API_URL}/login`, credentials);
    const token = response.data?.token;

    if (token) {
      saveLocalStorage("authToken", token);
    }

    return response.data;
  } catch (error) {
    console.error("Fel vid inloggning:", error.response?.data || error.message);
    throw error;
  }
};

// Hämta sparad token
export const getToken = () => {
  const stored = getLocalStorage("authToken");
  return stored?.data || null;
};

// Dekoda och inspektera JWT token
export const inspectToken = () => {
  const token = getToken();
  if (!token) {
    return null;
  }

  try {
    const payload = JSON.parse(atob(token.split('.')[1]));
    return payload;
  } catch (error) {
    console.error("Fel vid dekodning av token:", error);
    return null;
  }
};

// Kontrollera om token är giltig (enkel kontroll av format och expiration)
export const isTokenValid = () => {
  const token = getToken();
  if (!token) {
    return false;
  }

  try {
    // Dekoda JWT token för att kontrollera expiration
    const payload = JSON.parse(atob(token.split('.')[1]));
    const currentTime = Date.now() / 1000;

    // Kontrollera om token har gått ut
    const isValid = payload.exp > currentTime;

    return isValid;
  } catch (error) {
    console.error("Fel vid validering av token:", error);
    return false;
  }
};// Logga ut
export const logoutUser = () => {
  localStorage.removeItem("authToken");
};

// Axios-interceptor: lägg token automatiskt i headers
axios.interceptors.request.use((config) => {
  const token = getToken();
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

import { saveLocalStorage, getLocalStorage } from "./LocalStorage";
import FetchPeachApi from "./FetchPeachApi.jsx";
import { API_ENDPOINTS } from "../../utils/constants.js";

// Registrera användare
export const registerUser = async (userData) => {
  try {
    const response = await FetchPeachApi(API_ENDPOINTS.authentication.register, {
      method: "PUT",
      data: userData,
    });
    return response;
  } catch (error) {
    console.error("Fel vid registrering:", error.message);
    throw error;
  }
};

// Logga in användare
export const loginUser = async (credentials) => {
  try {
    const response = await FetchPeachApi(API_ENDPOINTS.authentication.login, {
      method: "POST",
      data: credentials,
    });

    const token = response?.token;
    if (token) {
      saveLocalStorage("authToken", token);
    }

    return response;
  } catch (error) {
    console.error("Fel vid inloggning:", error.message);
    throw error;
  }
};

// Hämta sparad token
export const getToken = () => {
  const stored = getLocalStorage("authToken");
  return stored?.data || null;
};

// Dekoda och inspektera JWT token (förenklad)
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
};

// Logga ut
export const logoutUser = () => {
  localStorage.removeItem("authToken");
};

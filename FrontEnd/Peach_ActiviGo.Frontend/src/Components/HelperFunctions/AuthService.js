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

// Logga ut
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

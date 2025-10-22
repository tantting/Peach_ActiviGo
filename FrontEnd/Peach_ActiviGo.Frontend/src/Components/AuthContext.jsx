import React, { createContext, useState, useEffect } from "react";
import {
  getLocalStorage,
  saveLocalStorage,
} from "./HelperFunctions/LocalStorage";
import { logoutUser, isTokenValid } from "./HelperFunctions/AuthService";

export const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  const [isAuthenticated, setIsAuthenticated] = useState(false);

  useEffect(() => {
    // Kontrollera både om token finns OCH om den är giltig
    const tokenExists = getLocalStorage("authToken");
    const tokenIsValid = isTokenValid();

    console.log("Token finns:", !!tokenExists);
    console.log("Token giltig:", tokenIsValid);

    if (tokenExists && tokenIsValid) {
      console.log("Användare autentiserad");
      setIsAuthenticated(true);
    } else if (tokenExists && !tokenIsValid) {
      // Token finns men är inte giltig längre - logga ut
      console.log("Token utgången - loggar ut användare");
      logoutUser();
      setIsAuthenticated(false);
    } else {
      console.log("Ingen giltig autentisering");
      setIsAuthenticated(false);
    }

    console.groupEnd();
  }, []);

  const login = (token) => {
    saveLocalStorage("authToken", token);
    setIsAuthenticated(true);
  };

  const logout = () => {
    logoutUser();
    setIsAuthenticated(false);
  };

  return (
    <AuthContext.Provider value={{ isAuthenticated, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
};

import React, { createContext, useState, useEffect } from "react";
import {
  getLocalStorage,
  saveLocalStorage,
} from "./HelperFunctions/LocalStorage";
import { logoutUser } from "./HelperFunctions/AuthService";

export const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  const [isAuthenticated, setIsAuthenticated] = useState(false);

  useEffect(() => {
    const token = getLocalStorage("authToken");
    setIsAuthenticated(!!token);
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

import React, { createContext, useState, useEffect } from "react";
import {
  getLocalStorage,
  saveLocalStorage,
} from "./HelperFunctions/LocalStorage";
import { logoutUser, inspectToken } from "./HelperFunctions/AuthService";

const ADMIN_ROLE = "admin";

// Normalisera rollclaim till en array av strängar
const normalizeRoles = (claim) => {
  // Filtrera bort null/undefined
  if (!claim) {
    return [];
  }
  // Hantera både array och kommaseparerad sträng
  if (Array.isArray(claim)) {
    return claim;
  }
  // Om roll är redan en array i strängformat, returnera som array
  if (typeof claim === "string") {
    return claim.split(",").map((role) => role.trim());
  }
  // Om claim är av annan typ, returnera tom array 
  return [];
};

const hasAdminRole = (payload) => {
  if (!payload) {
    return false;
  }
  // Hämtar alla möjliga rollclaims från payload
  const roleClaims = [
    payload.role,
    payload.Role,
    payload.roles,
    payload.Roles,
    payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"],
    payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/role"],
  ];
  const normalizedRoles = roleClaims
    .reduce((acc, claim) => acc.concat(normalizeRoles(claim)), [])
    .map((role) => role.toLowerCase());
  return normalizedRoles.includes(ADMIN_ROLE);
};
export const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const [isAdmin, setIsAdmin] = useState(false);
  const applyAuthStateFromStorage = () => {
    const tokenData = getLocalStorage("authToken");
    const hasToken = Boolean(tokenData?.data ?? tokenData);
    setIsAuthenticated(hasToken);
    const payload = inspectToken();
    setIsAdmin(hasAdminRole(payload));
  };

  useEffect(() => {
    applyAuthStateFromStorage();
  }, []);
  const login = (token) => {
    saveLocalStorage("authToken", token);
    applyAuthStateFromStorage();
  };
  const logout = () => {
    logoutUser();
    setIsAuthenticated(false);
    setIsAdmin(false);
  };
  return (
    <AuthContext.Provider value={{ isAuthenticated, isAdmin, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
};

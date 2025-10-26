import React, { useContext } from "react";
import { Navigate } from "react-router-dom";
import { AuthContext } from "./AuthContext.jsx";

// AdminGuardRoute: renders children only if user is authenticated and has admin role.
// Otherwise navigate to home (could be changed to /login if desired).
export default function AdminGuardRoute({ children }) {
  const { isAuthenticated, isAdmin } = useContext(AuthContext);

  if (!isAuthenticated || !isAdmin) {
    // Not allowed -> redirect to homepage
    return <Navigate to="/" replace />;
  }

  return children;
}

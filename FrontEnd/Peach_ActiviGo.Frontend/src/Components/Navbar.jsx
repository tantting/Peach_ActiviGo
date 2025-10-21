import { Link, useNavigate } from "react-router-dom";
import { useContext } from "react";
import { AuthContext } from "../Components/AuthContext.jsx";
import "../Styles/Navbar.css";

export default function Navbar() {
  const { isAuthenticated, logout } = useContext(AuthContext);
  const navigate = useNavigate();

  const handleLogout = () => {
    logout();
    navigate("/"); // Navigera till startsidan efter logout
  };

  return (
    <header className="navbar">
      <div className="navbar-content">
        <Link to="/" className="logo-link">
          <h1>ActiviGo</h1>
        </Link>

        <div className="nav-links">
          <Link to="/">Aktiviteter</Link>
          <Link to="/about">Kategorier</Link>
          <Link to="/contact">Kontakt</Link>
        </div>

        <div className="auth-buttons">
          {isAuthenticated ? (
            // Användare är inloggad, visa Logga ut
            <button onClick={handleLogout}>Logga ut</button>
          ) : (
            // Användare är inte inloggad, visa Logga in och Registrera
            <>
              <button>
                <Link to="/login">Logga in</Link>
              </button>
              <button>
                <Link to="/signup">Registrera</Link>
              </button>
            </>
          )}
        </div>
      </div>
    </header>
  );
}

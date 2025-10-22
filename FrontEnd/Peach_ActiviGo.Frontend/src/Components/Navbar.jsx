import { Link, useNavigate } from "react-router-dom";
import { useContext, useState } from "react";
import { AuthContext } from "../Components/AuthContext.jsx";
import "../Styles/Navbar.css";

export default function Navbar() {
  const { isAuthenticated, logout } = useContext(AuthContext);
  const navigate = useNavigate();
  const [isMenuOpen, setIsMenuOpen] = useState(false);

  const toggleMenu = () => {
    setIsMenuOpen(!isMenuOpen);
  };

  const closeMenu = () => {
    setIsMenuOpen(false);
  };

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
        {/* Hamburger Menu Button */}
        <button
          className={`hamburger ${isMenuOpen ? "active" : ""}`}
          onClick={toggleMenu}
        >
          <span></span>
          <span></span>
          <span></span>
        </button>

        {/* Navigation Menu */}
        <div className={`nav-menu ${isMenuOpen ? "active" : ""}`}>
          <div className="nav-links">
            <Link to="/" onClick={closeMenu}>
              Aktiviteter
            </Link>
            <Link to="/about" onClick={closeMenu}>
              Kategorier
            </Link>
            <Link to="/contact" onClick={closeMenu}>
              Kontakt
            </Link>
          </div>
          <div className="auth-buttons">
            {isAuthenticated ? (
              // Användare är inloggad, visa Logga ut
              <button onClick={handleLogout}>Logga ut</button>
            ) : (
              // Användare är inte inloggad, visa Logga in och Registrera
              <>
                <button>
                  <Link to="/login" onClick={closeMenu}>
                    Logga in
                  </Link>
                </button>
                <button>
                  <Link to="/signup" onClick={closeMenu}>
                    Registrera
                  </Link>
                </button>
              </>
            )}
          </div>
        </div>
      </div>
    </header>
  );
}

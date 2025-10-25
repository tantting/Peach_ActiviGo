import { Link, useNavigate } from "react-router-dom";
import { useContext, useState } from "react";
import { AuthContext } from "../Components/AuthContext.jsx";
import "../Styles/Navbar.css";

export default function Navbar() {
  const { isAuthenticated, isAdmin, logout } = useContext(AuthContext);
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

  const handleLogin = () => {
    closeMenu();
    navigate("/login");
  };

  const handleSignup = () => {
    closeMenu();
    navigate("/signup");
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
            {isAuthenticated && (
              <Link to="/mybookings" onClick={closeMenu}>
                Mina bokningar
              </Link>
            )}
            {isAdmin && (
              <Link to="/admin" onClick={closeMenu}>
                AdminVy
              </Link>
            )}
          </div>
          <div className="auth-buttons">
            {isAuthenticated ? (
              // Användare är inloggad, visa Logga ut
              <button onClick={handleLogout}>Logga ut</button>
            ) : (
              // Användare är inte inloggad, visa Logga in och Registrera
              <>
                <button onClick={handleLogin}>Logga in</button>
                <button onClick={handleSignup}>Registrera</button>
              </>
            )}
          </div>
        </div>
      </div>
    </header>
  );
}

import React, { useState } from "react";
import { Link } from "react-router-dom";
import "../Styles/Navbar.css";

export default function Navbar() {
  const [isMenuOpen, setIsMenuOpen] = useState(false);

  const toggleMenu = () => {
    setIsMenuOpen(!isMenuOpen);
  };

  const closeMenu = () => {
    setIsMenuOpen(false);
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
          </div>
        </div>
      </div>
    </header>
  );
}

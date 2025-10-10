import React from 'react'
import { Link } from 'react-router-dom'
import '../Styles/Navbar.css'

export default function Navbar() {
return (
    <header className="navbar">
    <div className="navbar-content">
        <Link to="/" className="logo-link"><h1>ActiviGo</h1></Link>
        <div className="nav-links">
            <Link to="/">Aktiviteter</Link>
            <Link to="/about">Kategorier</Link>
            <Link to="/contact">Kontakt</Link>
        </div>
        <div className='auth-buttons'>
            <button><Link to="/login">Logga in</Link></button>
            <button><Link to="/signup">Registrera</Link></button>
        </div>
    </div>
    </header>
)
}
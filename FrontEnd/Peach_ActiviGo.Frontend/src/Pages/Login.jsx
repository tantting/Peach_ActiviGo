import React, { useState } from 'react'

export default function Login() {
const [formData, setFormData] = useState({
    email: '',
    password: ''
})

const handleChange = (e) => {
    setFormData({
    ...formData,
    [e.target.name]: e.target.value
    })
}

const handleSubmit = (e) => {
    e.preventDefault()
    console.log('Login attempt:', formData)
    {/* Här skickar vi data till vår back-end */}
}

return (
    <div className="page-container auth-page">
    <div className="auth-form">
        <h1>Logga in</h1>
        
        <form onSubmit={handleSubmit}>
        <div className="form-group">
            <label htmlFor="email">Email:</label>
            <input
            type="email"
            id="email"
            name="email"
            value={formData.email}
            onChange={handleChange}
            required
            />
        </div>
        
        <div className="form-group">
            <label htmlFor="password">Lösenord:</label>
            <input
            type="password"
            id="password"
            name="password"
            value={formData.password}
            onChange={handleChange}
            required
            />
        </div>
        
        <button type="submit" className="auth-button">Logga in</button>
        </form>
        
        <p className="auth-link">
        Har du inget konto? <a href="/signup">Registrera dig här</a>
        </p>
    </div>
    </div>
)
}
import React, { useState } from 'react'

export default function Registrera() {
  const [formData, setFormData] = useState({
    name: '',
    email: '',
    password: '',
    confirmPassword: ''
  })

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value
    })
  }

  const handleSubmit = (e) => {
    e.preventDefault()
    
    if (formData.password !== formData.confirmPassword) {
      alert('Lösenorden matchar inte!')
      return
    }
    
    console.log('Registration attempt:', formData)
    // Här skulle du skicka data till backend
  }

  return (
    <div className="page-container auth-page">
      <div className="auth-form">
        <h1>Registrera dig</h1>
        <p>Gå med i ActiviGo och upptäck nya aktiviteter!</p>
        
        <form onSubmit={handleSubmit}>
          <div className="form-group">
            <label htmlFor="name">Namn:</label>
            <input
              type="text"
              id="name"
              name="name"
              value={formData.name}
              onChange={handleChange}
              required
            />
          </div>
          
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
          
          <div className="form-group">
            <label htmlFor="confirmPassword">Bekräfta lösenord:</label>
            <input
              type="password"
              id="confirmPassword"
              name="confirmPassword"
              value={formData.confirmPassword}
              onChange={handleChange}
              required
            />
          </div>
          
          <button type="submit" className="auth-button">Registrera</button>
        </form>
        
        <p className="auth-link">
          Har du redan ett konto? <a href="/login">Logga in här</a>
        </p>
      </div>
    </div>
  )
}
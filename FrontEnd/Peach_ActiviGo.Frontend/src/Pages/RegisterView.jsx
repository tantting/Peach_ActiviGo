import React, { useState } from "react";
import { useNavigate } from "react-router-dom"; // Import useNavigate To navigate after registration
import { registerUser } from "../Components/HelperFunctions/AuthService";

export default function RegisterView() {
  const [formData, setFormData] = useState({
    name: "",
    email: "",
    password: "",
    confirmPassword: "",
  });

  const navigate = useNavigate(); // Initialize useNavigate

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    if (formData.password !== formData.confirmPassword) {
      alert("Lösenorden matchar inte!");
      return;
    }

    try {
      await registerUser({
        name: formData.name,
        email: formData.email,
        password: formData.password,
      });
      alert("Registrering lyckades! Du kan nu logga in.");
      navigate("/login"); // Navigate to login page after successful registration
    } catch (error) {
      alert("Något gick fel vid registrering.");
    }
    {
      /*Skicka formdatan till backend här!*/
    }
  };

  return (
    <div className="page-container auth-page">
      <div className="auth-form">
        <h1>Registrera dig</h1>

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
              autoComplete="on"
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
              autoComplete="on"
            />
          </div>

          <button type="submit" className="auth-button">
            Registrera
          </button>
        </form>

        <p className="auth-link">
          Har du redan ett konto? <a href="/login">Logga in här</a>
        </p>
      </div>
    </div>
  );
}

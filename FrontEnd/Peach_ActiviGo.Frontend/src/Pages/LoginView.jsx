import React, { useState, useContext } from "react";
import { useNavigate } from "react-router-dom"; // Import useNavigate
import { loginUser } from "../Components/HelperFunctions/AuthService"; // Import loginUser
import { AuthContext } from "../Components/AuthContext"; // Import AuthContext

export default function LoginView() {
  const [formData, setFormData] = useState({
    email: "",
    password: "",
  });

  const { login } = useContext(AuthContext); // Get login from AuthContext
  const navigate = useNavigate(); // Initialize useNavigate

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const result = await loginUser(formData);
      const token = result?.token;
      if (token) {
        login(token); // Call login from AuthContext with the token
      }
      alert("Inloggning lyckades!");
      navigate("/");
    } catch (error) {
      alert("Fel vid inloggning, kontrollera email/lösenord.");
    }
  };

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

          <button type="submit" className="auth-button">
            Logga in
          </button>
        </form>

        <p className="auth-link">
          Har du inget konto? <a href="/signup">Registrera dig här</a>
        </p>
      </div>
    </div>
  );
}

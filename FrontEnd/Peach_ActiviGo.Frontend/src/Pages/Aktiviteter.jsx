import React from 'react'
import FetchWeather from '../Components/FetchWeather'
import { useState } from 'react'


export default function Aktiviteter() {
  const [showWeather, setShowWeather] = useState(false)

  const handleFetchWeather = () => {
    // Visa väderkomponenten
    setShowWeather(true)
  }

  return (
    <div className="page-container">
      <h1>Aktiviteter</h1>
      <p>Här kan du hitta alla tillgängliga aktiviteter!</p>
      
      <div className="activities-grid">
        <div className="activity-card">
        
        {/* Lägg in data ifrån Aktiviteter här */}
        {/* Nedan divvar är bara exempeldata */}
        




          <h3>Fotboll</h3>
          <p>Träna fotboll med andra entusiaster</p>
          <button className="WeatherButton" onClick={handleFetchWeather}>Hämta väder</button>
          {/* Visa väderdata när man trycker på knappen */}
          {showWeather && (
            <div>
              <FetchWeather />
            </div>
          )}
        </div>
        <div className="activity-card">
          <h3>Löpning</h3>
          <p>Gå med i våra löpgrupper</p>
        </div>
        <div className="activity-card">
          <h3>Yoga</h3>
          <p>Avslappnande yogasessioner</p>
        </div>
      </div>
    </div>
  )
}
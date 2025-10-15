import React from 'react'

export default function CategoryView() {
  return (
    <div className="page-container">
      <h1>Kategorier</h1>
      <p>Utforska olika kategorier av aktiviteter</p>
      
      <div className="categories-list">
        <div className="category-item">

        {/* Lägg in data ifrån Kategorier här */}
        {/* Nedan divvar är bara exempeldata */}
        




          <h3>🏃‍♂️ Kondition</h3>
          <p>Löpning, cykling, simning och andra konditionsaktiviteter</p>
        </div>
        <div className="category-item">
          <h3>⚽ Lagsporter</h3>
          <p>Fotboll, basket, volleyboll och andra lagsporter</p>
        </div>
        <div className="category-item">
          <h3>🧘‍♀️ Välmående</h3>
          <p>Yoga, pilates, meditation och avslappning</p>
        </div>
        <div className="category-item">
          <h3>🏋️‍♂️ Styrketräning</h3>
          <p>Gym, crossfit och viktlyftning</p>
        </div>
      </div>
    </div>
  )
}
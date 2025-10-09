import React from 'react'

export default function Kontakt() {
  return (
    <div className="page-container">
      <h1>Kontakt</h1>
      <p>Hör av dig till oss!</p>
      
      <div className="contact-info">
        <div className="contact-section">
          <h3>📧 Email</h3>
          <p>info@activigo.se</p>
        </div>
        
        <div className="contact-section">
          <h3>📞 Telefon</h3>
          <p>08-123 456 78</p>
        </div>
        
        <div className="contact-section">
          <h3>📍 Adress</h3>
          <p>ActiviGo AB<br/>
          Sportgatan 123<br/>
          123 45 Stockholm</p>
        </div>
      </div>
      
      <div className="contact-form">
        <h3>Skicka meddelande</h3>
        <form>
          <input type="text" placeholder="Ditt namn" />
          <input type="email" placeholder="Din email" />
          <textarea placeholder="Ditt meddelande" rows="5"></textarea>
          <button type="submit">Skicka</button>
        </form>
      </div>
    </div>
  )
}
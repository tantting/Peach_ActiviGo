import React from 'react'

export default function ContactView() {
  return (
    <div className="page-container">
      <h1>Kontakt</h1>
      <p>Hör av dig till oss!</p>
      
      <div className="contact-info">
        <div className="contact-section">
            
        {/* Detta kanske vi kan ha som exta, inget som egentligen behövs */}
        {/* Nedan divvar är bara exempeldata */}
        {/* Har vi tid över kanske vi kan kan fixa en email-funktion */}
        




          <h3>📧 Email</h3>
          <p>info@activigo.se</p>
        </div>
        
        <div className="contact-section">
          <h3>📞 Telefon</h3>
          <p>08-702 00 90</p>
        </div>
        
        <div className="contact-section">
          <h3>📍 Adress</h3>
          <p>ActiviGo AB<br/>
          Otto Torells gata 20<br/>
          432 44 Varberg</p>
        </div>
      </div>
      
      <div className="contact-form">
        <h3>Skicka meddelande</h3>
        <form>
          <input type="text" placeholder="Ditt namn" />
          <input type="email" placeholder="Din email" />
          <textarea placeholder="Ditt meddelande" rows="6" style={{ resize: "none" }}></textarea>
          <button type="submit">Skicka</button>
        </form>
      </div>
    </div>
  )
}
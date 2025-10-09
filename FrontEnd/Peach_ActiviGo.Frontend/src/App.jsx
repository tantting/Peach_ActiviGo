import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'
import Navbar from './Components/Navbar.jsx'
import Aktiviteter from './Pages/Aktiviteter.jsx'
import Kategorier from './Pages/Kategorier.jsx'
import Kontakt from './Pages/Kontakt.jsx'
import Login from './Pages/Login.jsx'
import Registrera from './Pages/Registrera.jsx'
// CSS
import './Styles/App.css'
import './Styles/Navbar.css'

function App() {
  return (
    <Router>
      <Navbar />
      <Routes>
        <Route path="/" element={<Aktiviteter />} />
        <Route path="/about" element={<Kategorier />} />
        <Route path="/contact" element={<Kontakt />} />
        <Route path="/login" element={<Login />} />
        <Route path="/signup" element={<Registrera />} />
      </Routes>
    </Router>
  )
}

export default App

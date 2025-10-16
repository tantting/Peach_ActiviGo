import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'
import Navbar from './Components/Navbar.jsx'
import ActivityView from './Pages/ActivityView.jsx'
import CategoryView from './Pages/CategoryView.jsx'
import ContactView from './Pages/ContactView.jsx'
import LoginView from './Pages/LoginView.jsx'
import RegisterView from './Pages/RegisterView.jsx'
// CSS
import './Styles/App.css'
import './Styles/Navbar.css'

function App() {
  return (
    <Router>
      <Navbar />
      <Routes>
        <Route path="/" element={<ActivityView />} />
        <Route path="/about" element={<CategoryView />} />
        <Route path="/contact" element={<ContactView />} />
        <Route path="/login" element={<LoginView />} />
        <Route path="/signup" element={<RegisterView />} />
      </Routes>
    </Router>
  )
}

export default App

import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Navbar from "./Components/Navbar.jsx";
import ActivityView from "./Pages/ActivityView.jsx";
import BookingsView from "./Pages/BookingsView.jsx";
import CategoryView from "./Pages/CategoryView.jsx";
import ContactView from "./Pages/ContactView.jsx";
import LoginView from "./Pages/LoginView.jsx";
import RegisterView from "./Pages/RegisterView.jsx";
import ActivityDetailView from "./Pages/ActivityDetailView.jsx";
// CSS
import "./Styles/Global.css";
import "./Styles/Navbar.css";

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
        <Route path="/bookings" element={<BookingsView />} />
        <Route path="/activity/:id" element={<ActivityDetailView />} />
      </Routes>
    </Router>
  );
}

export default App;

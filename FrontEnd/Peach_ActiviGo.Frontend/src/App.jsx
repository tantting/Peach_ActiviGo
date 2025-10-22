import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Navbar from "./Components/Navbar.jsx";
import ActivityView from "./Pages/ActivityView.jsx";
import BookingsView from "./Pages/BookingsView.jsx";
import CategoryView from "./Pages/CategoryView.jsx";
import ContactView from "./Pages/ContactView.jsx";
import LoginView from "./Pages/LoginView.jsx";
import RegisterView from "./Pages/RegisterView.jsx";
import ActivityDetailView from "./Pages/ActivityDetailView.jsx";
import Footer from "./Components/Footer.jsx";
import { AuthProvider } from "./Components/AuthContext.jsx";
// CSS
import "./Styles/Global.css";
import "./Styles/Navbar.css";
import "./Styles/Footer.css";

function App() {
  return (
    <AuthProvider>
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
        <Footer />
      </Router>
    </AuthProvider>
  );
}

export default App;

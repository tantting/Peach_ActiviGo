import {
  BrowserRouter as Router,
  Routes,
  Route,
  Navigate,
} from "react-router-dom";
import Navbar from "./Components/Navbar.jsx";
import ActivityView from "./Pages/ActivityView.jsx";
import BookingsView from "./Pages/BookingsView.jsx";
import CategoryView from "./Pages/CategoryView.jsx";
import ContactView from "./Pages/ContactView.jsx";
import LoginView from "./Pages/LoginView.jsx";
import RegisterView from "./Pages/RegisterView.jsx";
import ActivityDetailView from "./Pages/ActivityDetailView.jsx";
import Footer from "./Components/Footer.jsx";
import UserBookingsView from "./Pages/UserBookingsView.jsx";
import AdminView from "./Pages/AdminView/AdminView.jsx";
import AdminGuardRoute from "./Components/AdminGuardRoute.jsx";
import { AuthProvider } from "./Components/AuthContext.jsx";
import BookingStatisticsView from "./Pages/AdminView/BookingStatisticsView.jsx";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

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
          <Route
            path="/admin"
            element={
              <AdminGuardRoute>
                <AdminView />
              </AdminGuardRoute>
            }
          />
          <Route path="/about" element={<CategoryView />} />
          <Route path="/contact" element={<ContactView />} />
          <Route path="/login" element={<LoginView />} />
          <Route path="/signup" element={<RegisterView />} />
          <Route path="/bookings" element={<BookingsView />} />
          <Route path="/activity/:id" element={<ActivityDetailView />} />
          <Route path="/mybookings" element={<UserBookingsView />} />
          <Route
            path="/bookingStatistics"
            element={
              <AdminGuardRoute>
                <BookingStatisticsView />
              </AdminGuardRoute>
            }
          />
          {/* Catch-all: redirect unknown routes to home */}
          <Route path="*" element={<Navigate to="/" replace />} />
        </Routes>
        <ToastContainer
          position="top-right"
          autoClose={3000}
          hideProgressBar={false}
          newestOnTop
          closeOnClick
          pauseOnHover
        />
        <Footer />
      </Router>
    </AuthProvider>
  );
}

export default App;

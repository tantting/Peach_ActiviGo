import FetchBookings from "../Components/HelperFunctions/FetchBookings";
import BookingCard from "../Components/BookingCard";
import "../Styles/Bookings.css";

export default function BookingsView() {
  const { bookings, loading, error } = FetchBookings();

  if (loading) {
    return (
      <div className="page-container">
        <h1>Bokningar</h1>
        <p>Laddar bokningar...</p>
      </div>
    );
  }

  if (error) {
    return (
      <div className="page-container">
        <h1>Bokningar</h1>
        <div className="error-message">
          <h3>Fel vid hämtning av bokningar:</h3>
          <p>{error}</p>
        </div>
      </div>
    );
  }

  return (
    <div className="page-container">
      <h1>Bokningar</h1>
      <div className="bookings-grid">
        {bookings.length > 0 ? (
          bookings.map((booking) => (
            <BookingCard key={booking.id} booking={booking} />
          ))
        ) : (
          <div className="no-bookings">
            <h3>Inga bokningar hittades</h3>
            <p>Finns inga aktiva bokningar just nu.</p>
          </div>
        )}
      </div>
    </div>
  );
}

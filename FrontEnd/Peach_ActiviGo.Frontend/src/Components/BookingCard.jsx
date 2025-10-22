const BookingCard = ({ booking }) => {
  return (
    <div className="booking-card">
      <h3>Bokning #{booking.id}</h3>
      {/* <div className="booking-details"></div> */}
      <div className="booking-overview">
        <h2>Översikt</h2>
        <p>Boknings-ID: {booking.id}</p>
        <p>Kundens e-post: {booking.customerEmail}</p>
        <p>Aktivitet: {booking.activity}</p>
        <p>Plats: {booking.location}</p>
        <p>Bokningsdatum: {booking.bookingDate}</p>
        <p>Kund-ID: {booking.customerId}</p>
        <p>Starttid: {booking.startTime}</p>
        <p>Sluttid: {booking.endTime}</p>
        <p>Kommande: {booking.isUpcoming ? "Ja" : "Nej"}</p>
        <p>Avbokad: {booking.cancelledAt ? "Ja" : "Nej"}</p>
      </div>
    </div>
  );
};

export default BookingCard;

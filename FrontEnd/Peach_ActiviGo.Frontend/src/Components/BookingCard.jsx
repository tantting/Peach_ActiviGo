const BookingCard = ({ booking }) => {
  return (
    <div className="booking-card">
      <h3>Bokning #{booking.id}</h3>
      <div className="booking-details">
        <p>{JSON.stringify(booking, null, 2)}</p>
        {/* Visar all bokningsdata som JSON för felsökning */}

        {/* <p>{booking.activity}</p>
        <p>{booking.bookingDate}</p>
        <p>{booking.cancelledAt}</p>
        <p>{booking.customerEmail}</p>
        <p>{booking.customerId}</p>
        <p>{booking.endTime}</p>
        <p>{booking.id}</p>
        <p>{booking.isUpcoming ? "Ja" : "Nej"}</p>
        <p>{booking.location}</p>
        <p>{booking.startTime}</p>
        <p>{booking.id}</p>
        <p>{booking.endTime}</p> */}
      </div>
    </div>
  );
};

export default BookingCard;

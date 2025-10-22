// importera ActivitySlot.css
import "../Styles/ActivitySlot.css";

const ActivitySlots = ({ ActivitySlots, loading, error }) => {
  if (loading) return <div>Laddar lediga tider...</div>;
  if (error) return <div>Fel vid laddning av tider: {error}</div>;

  if (!ActivitySlots || ActivitySlots.length === 0) {
    return <div>Inga lediga tider tillgängliga för tillfället.</div>;
  }

  return (
    <div className="activity-slots">
      {ActivitySlots.map((slot, index) => (
        <div key={`slot-${index}`} className="slot-item">
          <p>
            <strong>Starttid:</strong>{" "}
            {new Date(slot.startTime).toLocaleString("sv-SE")}
          </p>
          <p>
            <strong>Sluttid:</strong>{" "}
            {new Date(slot.endTime).toLocaleString("sv-SE")}
          </p>
          <button className="book-slot-button">Boka denna tid</button>
        </div>
      ))}
    </div>
  );
};

export default ActivitySlots;

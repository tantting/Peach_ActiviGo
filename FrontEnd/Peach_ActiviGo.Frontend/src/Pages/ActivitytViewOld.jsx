import ActivityLocationCard from "../Components/ActivityLocationCard";
import "../Styles/Activity.css";
import FilterSearchForm from "../Components/FilterSearchForm";

export default function ActivityView() {
  const { activityLocations, loading, error } = FetchActivityLocations();

  if (loading) {
    return (
      <div className="page-container">
        <h1>Aktiviteter</h1>
        <p>Laddar aktiviteter...</p>
      </div>
    );
  }

  if (error) {
    return (
      <div className="page-container">
        <h1>Aktiviteter</h1>
        <div className="error-message">
          <h3>Fel vid hämtning av aktiviteter:</h3>
          <p>{error}</p>
        </div>
      </div>
    );
  }

  return (
    <div className="page-container">
      <h1>Våra Aktivitetsplatser</h1>
      <FilterSearchForm />
      <div className="activities-grid">
        {activityLocations.length > 0 ? (
          activityLocations.map((activityLocation) => (
            <ActivityLocationCard
              key={activityLocation.id}
              activityLocation={activityLocation}
            />
          ))
        ) : (
          <div className="activity-card">
            <h3>Inga aktiviteter hittades</h3>
            <p>Det finns inga aktiva aktiviteter att visa just nu.</p>
          </div>
        )}
      </div>
    </div>
  );
}

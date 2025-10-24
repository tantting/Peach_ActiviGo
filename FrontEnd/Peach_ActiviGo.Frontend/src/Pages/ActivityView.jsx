import ActivityLocationCard from "../Components/ActivityLocationCard";
import "../Styles/Activity.css";
import FilterSearchForm from "../Components/FilterSearchForm";
import { useState, useEffect } from "react";
import FetchContent from "../Components/HelperFunctions/FetchContent";

export default function ActivityView() {
  const [activityLocations, setActivityLocations] = useState([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);

  // Fetch all activities as an intital start
  useEffect(() => {
    const fetchInitial = async () => {
      setLoading(true);
      try {
        const data = await FetchContent(
          "/api/ActivityLocation/FilterActivityLocations",
          {}
        );
        setActivityLocations(data || []);
      } catch (err) {
        setError("Kunde inte hämta aktiviteter vid start");
      } finally {
        setLoading(false);
      }
    };

    fetchInitial();
  }, []);

  return (
    <div className="page-container">
      <h1>Våra Aktivitetsplatser</h1>

      <FilterSearchForm
        setActivityLocations={setActivityLocations}
        setLoading={setLoading}
        setError={setError}
      />

      {loading && <p>Laddar aktiviteter...</p>}
      {error && <p className="error-message">{error}</p>}

      <div className="activities-grid">
        {activityLocations.length > 0
          ? activityLocations.map((activityLocation) => (
              <ActivityLocationCard
                key={activityLocation.id}
                activityLocation={activityLocation}
              />
            ))
          : !loading && (
              <div className="activity-card">
                <h3>Inga aktiviteter hittades</h3>
                <p>Det finns inga aktiva aktiviteter att visa just nu.</p>
              </div>
            )}
      </div>
    </div>
  );
}

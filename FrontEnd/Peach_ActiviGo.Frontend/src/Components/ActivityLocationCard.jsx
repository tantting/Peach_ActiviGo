import { Link, useNavigate } from "react-router-dom";
import { buildImageUrl } from "../utils/constants";

const ActivityLocationCard = ({ activityLocation }) => {
  const navigate = useNavigate();

  return (
    <div className="activity-card">
      <h2>Plats: {activityLocation.locationName}</h2>
      <p>Aktivitet: {activityLocation.activityName}</p>
      <p>Status: {activityLocation.isActive ? "Aktiv" : "Inaktiv"}</p>
      <p>{activityLocation.isIndoor ? "Inomhus" : "Utomhus"}</p>
      <p>
        <img
          className="activity-image"
          src={buildImageUrl(activityLocation.imageUrl)}
          alt={activityLocation.activityName}
          onError={(event) => {
            console.warn("Image failed to load:", event.target.src);
            event.target.src = "/images/placeholder-activity.jpg"; // Fallback image
          }}
        />
      </p>
      <button
        type="button"
        onClick={() =>
          navigate(`/activity/${activityLocation.id}`, {
            state: { activityLocation },
          })
        }
      >
        <Link
          to={`/activity/${activityLocation.id}`}
          state={{ activityLocation }}
          className="booking-button"
        >
          Boka {activityLocation.activityName} nu!
        </Link>
      </button>
    </div>
  );
};

export default ActivityLocationCard;

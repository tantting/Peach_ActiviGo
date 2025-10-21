import { useParams, useLocation } from "react-router-dom";
import FetchActivityDetail from "../Components/HelperFunctions/FetchActivityDetail";
import ActivityDetail from "../Components/ActivityDetail";
import "../Styles/Activity.css";

export default function ActivityDetailView() {
  const { id } = useParams();
  const location = useLocation();

  // Använd data från location.state om tillgängligt, annars hämta från API
  const initialActivityLocation = location.state?.activityLocation || null;
  const { activityLocation, loading, error } = FetchActivityDetail(
    id,
    initialActivityLocation
  );

  return (
    <div className="page-container">
      <h1>Aktivitetsdetaljer</h1>
      <ActivityDetail
        activityLocation={activityLocation}
        loading={loading}
        error={error}
      />
    </div>
  );
}

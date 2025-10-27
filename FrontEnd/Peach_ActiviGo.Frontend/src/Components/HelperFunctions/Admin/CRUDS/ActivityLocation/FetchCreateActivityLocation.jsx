import { useState } from "react";
import FetchPeachApi from "../../../FetchPeachApi.jsx";
import { API_ENDPOINTS } from "../../../../../utils/constants.js";

const ACTIVITYLOCATION_ENDPOINT = API_ENDPOINTS.activityLocation;
// Specific create route on the backend
const ACTIVITYLOCATION_CREATE_ENDPOINT = `${ACTIVITYLOCATION_ENDPOINT}/CreateActivityLocation`;

export default function FetchCreateActivityLocation() {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState("");
  const [okMessage, setOkMessage] = useState("");

  const createActivityLocation = async (payload) => {
    setLoading(true);
    setError("");
    setOkMessage("");
    try {
      // POST to the backend's CreateActivityLocation action
      await FetchPeachApi(ACTIVITYLOCATION_CREATE_ENDPOINT, {
        method: "POST",
        data: payload,
      });
      // Message in Swedish: activity and location linked
      setOkMessage("Aktivitet och plats kopplade!");
    } catch (e) {
      setError(e.message || "Kunde inte skapa ActivityLocation.");
      throw e;
    } finally {
      setLoading(false);
    }
  };

  return { createActivityLocation, loading, error, okMessage };
}

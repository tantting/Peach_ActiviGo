import { useState } from "react";
import FetchPeachApi from "../../../FetchPeachApi.jsx";
import { API_ENDPOINTS } from "../../../../../utils/constants.js";

const LOCATION_ENDPOINT = API_ENDPOINTS.locations;

export default function FetchDeleteLocation() {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState("");
  const [okMessage, setOkMessage] = useState("");

  const deleteLocation = async (id) => {
    setLoading(true);
    setError("");
    setOkMessage("");
    try {
      await FetchPeachApi(`${LOCATION_ENDPOINT}/${id}`, {
        method: "DELETE",
      });
      setOkMessage("Plats raderad!");
    } catch (e) {
      setError(e.message || "Kunde inte radera platsen.");
      throw e;
    } finally {
      setLoading(false);
    }
  };

  return { deleteLocation, loading, error, okMessage };
}

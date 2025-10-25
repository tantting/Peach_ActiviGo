import { useState } from "react";
import FetchPeachApi from "../../../FetchPeachApi.jsx";
import { API_ENDPOINTS } from "../../../../../utils/constants.js";

const LOCATION_ENDPOINT = API_ENDPOINTS.locations;

export default function FetchCreateLocation() {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState("");
  const [okMessage, setOkMessage] = useState("");

  const createLocation = async (payload) => {
    setLoading(true);
    setError("");
    setOkMessage("");
    try {
      await FetchPeachApi(LOCATION_ENDPOINT, {
        method: "POST",
        data: payload,
      });
      setOkMessage("Plats skapad!");
    } catch (e) {
      setError(e.message || "Kunde inte skapa platsen.");
      throw e;
    } finally {
      setLoading(false);
    }
  };

  return { createLocation, loading, error, okMessage };
}

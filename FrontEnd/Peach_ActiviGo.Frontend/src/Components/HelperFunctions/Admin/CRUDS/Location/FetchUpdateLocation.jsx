import { useState } from "react";
import FetchPeachApi from "../../../FetchPeachApi.jsx";
import { API_ENDPOINTS } from "../../../../../utils/constants.js";

const LOCATION_ENDPOINT = API_ENDPOINTS.locations;

export default function FetchUpdateLocation() {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState("");
  const [okMessage, setOkMessage] = useState("");
  const [data, setData] = useState(null); // senast hämtad plats

  const reset = () => {
    setError("");
    setOkMessage("");
  };

  // GET /api/Location/{id}
  const fetchById = async (id) => {
    setLoading(true);
    reset();
    try {
      const res = await FetchPeachApi(`${LOCATION_ENDPOINT}/${id}`, {
        method: "GET",
      });
      setData(res);
      return res;
    } catch (e) {
      setError(e.message || "Kunde inte hämta plats.");
      setData(null);
      throw e;
    } finally {
      setLoading(false);
    }
  };

  // PUT /api/Location/{id}
  const updateLocation = async (id, payload) => {
    setLoading(true);
    reset();
    try {
      await FetchPeachApi(`${LOCATION_ENDPOINT}/${id}`, {
        method: "PUT",
        data: payload,
      });
      setOkMessage("Plats uppdaterad!");
    } catch (e) {
      setError(e.message || "Kunde inte uppdatera platsen.");
      throw e;
    } finally {
      setLoading(false);
    }
  };

  return { fetchById, updateLocation, loading, error, okMessage, data, reset };
}

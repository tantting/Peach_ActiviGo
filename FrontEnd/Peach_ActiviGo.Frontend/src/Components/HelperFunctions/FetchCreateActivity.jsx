import { useState } from "react";
import FetchPeachApi from "./FetchPeachApi.jsx";

const ACTIVITY_ENDPOINT = "/api/activities";

export default function FetchCreateActivity() {
  const [loading, setLoading] = useState(false);
  const [error, setError]   = useState("");
  const [ok, setOk]         = useState("");

  const createActivity = async (payload) => {
    setLoading(true);
    setError("");
    setOk("");
    try {
      await FetchPeachApi(ACTIVITY_ENDPOINT, {
        method: "POST",
        data: payload,
      });
      setOk("Aktivitet skapad!");
    } catch (e) {
      setError(e.message || "Kunde inte skapa aktiviteten.");
      throw e;
    } finally {
      setLoading(false);
    }
  };

  return { createActivity, loading, error, ok };
}

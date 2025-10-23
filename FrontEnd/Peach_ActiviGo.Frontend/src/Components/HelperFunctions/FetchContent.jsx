import React from "react";
import { API_BASE_URL } from "../../utils/constants";

const FetchContent = async (payload, UrlAddOn) => {
  try {
    const response = await fetch(`${API_BASE_URL}${UrlAddOn}`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(payload),
    });
    const data = await response.json();
    console.log("Resultatet från API: ", data);
    return data;
  } catch (err) {
    console.error("Fel vid hämtning av aktiviteter:", err);
    return null;
  }
};

export default FetchContent;

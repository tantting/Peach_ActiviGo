import React from "react";
import { API_BASE_URL } from "../../utils/constants";
import { getToken } from "./AuthService";

const FetchContent = async (UrlAddOn, payload = null, method = null) => {
  try {
    // Om method inte anges, använd POST om payload finns, annars GET
    const httpMethod = method || (payload ? "POST" : "GET");

    const options = {
      method: httpMethod,
      headers: {
        "Content-Type": "application/json",
      },
    };

    // Lägg till Authorization-header om token finns
    try {
      const token = getToken();
      if (token) {
        options.headers["Authorization"] = `Bearer ${token}`;
      }
    } catch (err) {
      console.warn("Kunde inte hämta token för Authorization-header:", err);
    }

    // Lägg till body bara om payload finns och det inte är GET
    if (payload && httpMethod !== "GET") {
      options.body = JSON.stringify(payload);
    }

    const response = await fetch(`${API_BASE_URL}${UrlAddOn}`, options);

    if (!response.ok) {
      throw new Error(`Http error! status: ${response.status} `);
    }

    const data = await response.json();
    console.log("Resultatet från API:", data);
    return data;
  } catch (err) {
    console.error("Fel vid hämtning:", err);
    return null;
  }
};

export default FetchContent;

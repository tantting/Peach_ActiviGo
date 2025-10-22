import FetchPeachApi from "./FetchPeachApi.jsx";

/**
 * Skapa en ny bokning
 * @param {Object} bookingData - Bokningsdata
 * @param {number} bookingData.activitySlotId - ID för aktivitetsslot
 * @returns {Promise} - Promise som returnerar bokningsdata eller error
 */
export const createBooking = async (bookingData) => {
  try {
    const response = await FetchPeachApi("/api/Booking", {
      method: "POST",
      data: bookingData,
    });

    console.log("Bokning skapad:", response);
    return response;
  } catch (error) {
    // Kontrollera om det är ett känt backend-fel
    if (
      error.message.includes("Request failed with status code 500") &&
      error.response?.data?.includes("User already has an active booking")
    ) {
      throw new Error("Du har redan en aktiv bokning för denna aktivitetstid.");
    } else if (error.message.includes("Request failed with status code 401")) {
      throw new Error("Du måste logga in för att göra en bokning.");
    } else if (error.message.includes("Request failed with status code 400")) {
      throw new Error("Felaktig bokningsdata skickades till servern.");
    }

    console.error("Fel vid skapande av bokning:", error);
    throw error;
  }
};

export default createBooking;

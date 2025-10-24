import FetchPeachApi from "./FetchPeachApi.jsx";
import { inspectToken } from "./AuthService.js";

export const getUserBookings = async (status) => {
  const tokenData = inspectToken();
  const userId =
    tokenData?.userId ||
    tokenData?.[
      "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"
    ];

  if (!userId) {
    throw new Error("User not logged in.");
  }

  const response = await FetchPeachApi(
    `/api/Booking/member/${userId}/status/${status}`
  );
  return response;
};
export const cancelBooking = async (bookingId) => {
  try {
    const response = await FetchPeachApi(`/api/Booking/${bookingId}`, {
      method: "PUT",
    });
    return response;
  } catch (error) {
    console.error(error.response?.data || "Kunde inte avboka bokningen.");
    throw error;
  }
};

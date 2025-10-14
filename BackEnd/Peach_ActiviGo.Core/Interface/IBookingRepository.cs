using Peach_ActiviGo.Core.Models;

namespace Peach_ActiviGo.Core.Interface;

public interface IBookingRepository
{
    Task<IEnumerable<Booking>> GetAllBookingsAsync(CancellationToken ct);
    Task<Booking> GetBookingByIdAsync(int id, CancellationToken ct);
    void AddBooking(Booking booking);
    void UpdateBooking(Booking booking);
    void DeleteBooking(Booking booking);    
}
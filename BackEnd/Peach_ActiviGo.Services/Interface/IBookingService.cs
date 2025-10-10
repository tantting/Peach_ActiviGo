using Peach_ActiviGo.Core.Models;

namespace Peach_ActiviGo.Services.Interface;

public interface IBookingService
{
    Task<IEnumerable<Booking>> GetAllBookingsAsync(CancellationToken ct);
    Task<Booking> GetBookingByIdAsync(int id, CancellationToken ct);
    Task AddBookingAsync(Booking booking, CancellationToken ct);
    Task UpdateBookingAsync(Booking booking, CancellationToken ct);
    Task DeleteBookingAsync(int id, CancellationToken ct);
}
using Peach_ActiviGo.Core.Models;
using Peach_ActiviGo.Services.DTOs.BookingDtos;

namespace Peach_ActiviGo.Services.Interface;

public interface IBookingService
{
    Task<IEnumerable<BookingDto>> GetAllBookingsAsync(CancellationToken ct);
    Task<BookingDto> GetBookingByIdAsync(int id, CancellationToken ct);
    Task AddBookingAsync(BookingCreateDto booking, CancellationToken ct);
    Task UpdateBookingAsync(BookingUpdateDto booking, CancellationToken ct);
    Task DeleteBookingAsync(int id, CancellationToken ct);
}
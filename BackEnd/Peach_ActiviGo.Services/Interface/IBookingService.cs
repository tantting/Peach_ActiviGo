using Peach_ActiviGo.Core.Enums;
using Peach_ActiviGo.Core.Models;
using Peach_ActiviGo.Services.DTOs.BookingDtos;

namespace Peach_ActiviGo.Services.Interface;

public interface IBookingService
{
    Task<IEnumerable<BookingDto>> GetAllBookingsAsync(CancellationToken ct);
    Task<BookingDto> GetBookingByIdAsync(int id, CancellationToken ct);
    Task<IEnumerable<BookingDto>> GetAllByMemberIdAndStatusAsync(
        string memberId, BookingStatus? status, CancellationToken ct);
    Task<BookingDto> AddBookingAsync(BookingCreateDto booking, string userId, CancellationToken ct);
    Task CancelBookingBeforeCutOffAsync(int id, CancellationToken ct);
    Task DeleteBookingAsync(int id, CancellationToken ct);
}
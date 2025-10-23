using Peach_ActiviGo.Core.Enums;
using Peach_ActiviGo.Core.Filter;
using Peach_ActiviGo.Core.Models;

namespace Peach_ActiviGo.Core.Interface;

public interface IBookingRepository
{
    Task<IEnumerable<Booking>> GetAllBookingsAsync(CancellationToken ct);
    Task<Booking> GetBookingByIdAsync(int id, CancellationToken ct);
    Task<IEnumerable<Booking>> GetByMemberAndStatusAsync(string memberId, BookingStatus? status, CancellationToken ct);
    void AddBooking(Booking booking);
    void UpdateBooking(Booking booking);
    void DeleteBooking(Booking booking);
    Task<bool> UserHasActiveBookingAsync(string userId, int activitySlotId, CancellationToken ct);
    Task<StatisticFilter> GetBookingStatisticsAsync(CancellationToken ct);
}
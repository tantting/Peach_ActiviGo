using Microsoft.EntityFrameworkCore;
using Peach_ActiviGo.Core.Enums;
using Peach_ActiviGo.Core.Filter;
using Peach_ActiviGo.Core.Interface;
using Peach_ActiviGo.Core.Models;
using Peach_ActiviGo.Infrastructure.Data;
using System.Globalization;

namespace Peach_ActiviGo.Infrastructure.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly AppDbContext _context; 
    
    public BookingRepository(AppDbContext context)
    {
        _context = context; 
    }
    // GetAll Bookings
    public async Task<IEnumerable<Booking>> GetAllBookingsAsync(CancellationToken ct)
    {
        return await _context.Bookings
            .AsNoTracking()
            .Include(b => b.ActivitySlot)
            .ThenInclude(s => s.ActivityLocation)
            .ThenInclude(al => al.Activity)
            .Include(b =>b.Customer)
            .Include(b => b.ActivitySlot)
            .ThenInclude(s => s.ActivityLocation)
            .ThenInclude(al => al.Location)
            .OrderBy(b => b.ActivitySlot.StartTime)
            .ToListAsync(ct);
    }
    
    //Get Booking by Id
    public async Task<Booking?> GetBookingByIdAsync(int id, CancellationToken ct)
    {
        return await _context.Bookings
            .AsNoTracking()
            .Include(b => b.ActivitySlot)
            .ThenInclude(s => s.ActivityLocation)
            .ThenInclude(al => al.Activity)
            .Include(b =>b.Customer)
            .Include(b => b.ActivitySlot)
            .ThenInclude(s => s.ActivityLocation)
            .ThenInclude(al => al.Location)
            .FirstOrDefaultAsync(b => b.Id == id, ct);
    }

    public async Task<IEnumerable<Booking>> GetByMemberAndStatusAsync(
    string memberId, BookingStatus? status, CancellationToken ct)
    {
        var query = _context.Bookings
            .AsNoTracking()
            .Include(b => b.ActivitySlot)
            .ThenInclude(s => s.ActivityLocation)
            .ThenInclude(al => al.Activity)
            .Include(b => b.ActivitySlot)
            .ThenInclude(s => s.ActivityLocation)
            .ThenInclude(al => al.Location)
            .Where(b => b.CustomerId == memberId);

        if (status.HasValue)
            query = query.Where(b => b.Status == status.Value);

        return await query
            .OrderBy(b => b.ActivitySlot.StartTime)
            .ToListAsync(ct);}


    public void AddBooking(Booking booking)
    {
        _context.Bookings.Add(booking);
    }
    // Update Booking (Avbokad f�r cut-off)
    public void UpdateBooking(Booking booking)
    {
        _context.Bookings.Update(booking);
    }

    public void DeleteBooking(Booking booking)
    {
        _context.Bookings.Remove(booking);
    }
    
    public async Task<bool> UserHasActiveBookingAsync(string userId, int activitySlotId, CancellationToken ct)
    {
        return await _context.Bookings
            .AsNoTracking()
            .AnyAsync(b => b.CustomerId == userId 
                           && b.ActivitySlotId == activitySlotId 
                           && b.Status == BookingStatus.Active, ct);
    }

    public async Task<StatisticFilter> GetBookingStatisticsAsync(CancellationToken ct)
    {
        var nowUtc = DateTime.UtcNow;

        // Calculate week range (Monday as first day)
        var diff = ((int)nowUtc.DayOfWeek - (int)DayOfWeek.Monday + 7) % 7; // Adjust so that Monday is first day
        var startOfWeek = nowUtc.Date.AddDays(-diff); // Start of the week (Monday)
        var endOfWeek = startOfWeek.AddDays(7); // End of the week (next Monday)

        // Active bookings count
        var activeCount = await _context.Bookings
            .AsNoTracking()
            .CountAsync(b => b.Status == BookingStatus.Active, ct);

        // Cancelled bookings count
        var cancelledCount = await _context.Bookings
            .AsNoTracking()
            .CountAsync(b => b.Status == BookingStatus.Cancelled, ct);

        // Total revenue from active bookings
        var totalRevenueNullable = await _context.Bookings
            .AsNoTracking()
            .Where(b => b.Status == BookingStatus.Active)
            .Select(b => (decimal?)b.ActivitySlot.ActivityLocation.Activity.Price)
            .SumAsync(ct);
        var totalRevenue = totalRevenueNullable ?? 0m;

        // Bookings per activity
        var perActivityList = await _context.Bookings
            .AsNoTracking()
            .GroupBy(b => b.ActivitySlot.ActivityLocation.Activity.Name)
            .Select(g => new { ActivityName = g.Key, Count = g.Count() })
            .ToListAsync(ct);

        // Most popular activity
        var mostPopularEntry = perActivityList
            .OrderByDescending(x => x.Count)
            .FirstOrDefault();

        // Top customer by number of bookings
        var topCustomerEntry = await _context.Bookings
            .AsNoTracking()
            .GroupBy(b => b.Customer.UserName)
            .Select(g => new { CustomerName = g.Key, Count = g.Count() })
            .OrderByDescending(g => g.Count)
            .FirstOrDefaultAsync(ct);

        // Bookings this month (current year & month)
        var bookingsThisMonth = await _context.Bookings
            .AsNoTracking()
            .CountAsync(b => b.BookingDate.Year == nowUtc.Year && b.BookingDate.Month == nowUtc.Month, ct);

        // Bookings this week (startOfWeek .. endOfWeek)
        var bookingsThisWeek = await _context.Bookings
            .AsNoTracking()
            .CountAsync(b => b.BookingDate >= startOfWeek && b.BookingDate < endOfWeek, ct);

        // Convert per-activity list to dictionary
        var perActivityDict = perActivityList
            .ToDictionary(x => x.ActivityName ?? "Unknown", x => x.Count);

        return new StatisticFilter
        {
            ActiveBookings = activeCount,
            CanceledBookings = cancelledCount,
            TotalRevenue = totalRevenue,
            TotalBookingsPerActivity = perActivityDict,
            TotalBookingsThisMonth = bookingsThisMonth,
            TotalBookingsThisWeek = bookingsThisWeek,
            MostPopularActivity = mostPopularEntry != null
                ? $"{mostPopularEntry.ActivityName} ({mostPopularEntry.Count} bookings)"
                : "N/A",
            TopCustomer = topCustomerEntry != null
                ? $"{topCustomerEntry.CustomerName} ({topCustomerEntry.Count} bookings)"
                : "N/A"
        };
    }
}
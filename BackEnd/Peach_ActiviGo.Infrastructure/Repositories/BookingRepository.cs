using Microsoft.EntityFrameworkCore;
using Peach_ActiviGo.Core.Interface;
using Peach_ActiviGo.Core.Models;
using Peach_ActiviGo.Infrastructure.Data;

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
        //return await _context.Bookings
        //    .Include(b=>b.ActivitySlot)
        //    .ToListAsync(ct);

        return await _context.Bookings
        .AsNoTracking()
        .Include(b => b.ActivitySlot)
            .ThenInclude(s => s.ActivityLocation)
                .ThenInclude(al => al.Activity)
        .Include(b => b.ActivitySlot)
            .ThenInclude(s => s.ActivityLocation)
                .ThenInclude(al => al.Location)
        //.Include(b => b.Customer) // l�gg till om du beh�ver kundens Email i DTO
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
            .Include(b => b.ActivitySlot)
                .ThenInclude(s => s.ActivityLocation)
                    .ThenInclude(al => al.Location)
            // .Include(b => b.Customer) // om DTO ska visa kunddata
            .FirstOrDefaultAsync(b => b.Id == id, ct);
    }


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
}
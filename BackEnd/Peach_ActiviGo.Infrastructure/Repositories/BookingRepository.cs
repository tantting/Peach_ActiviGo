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
        return await _context.Bookings
            .Include(b=>b.ActivitySlot)
            .ToListAsync(ct);
    }
    //Get Booking by Id
    public async Task<Booking> GetBookingByIdAsync(int id, CancellationToken ct)
    {
        return await _context.Bookings
            .Include(b=>b.ActivitySlot)
            .FirstOrDefaultAsync(b=>b.Id == id, ct);
    }

    public void AddBooking(Booking booking)
    {
        throw new NotImplementedException();
    }

    public void UpdateBooking(Booking booking)
    {
        throw new NotImplementedException();
    }

    public void DeleteBooking(Booking booking)
    {
        throw new NotImplementedException();
    }
}
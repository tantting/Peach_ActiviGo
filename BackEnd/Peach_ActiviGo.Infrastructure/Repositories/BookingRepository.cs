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

    public Task<IEnumerable<Booking>> GetAllBookingsAsync(CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<Booking> GetBookingByIdAsync(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
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
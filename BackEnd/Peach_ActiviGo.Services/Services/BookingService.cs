using AutoMapper;
using Peach_ActiviGo.Core.Interface;
using Peach_ActiviGo.Core.Models;
using Peach_ActiviGo.Services.Interface;

namespace Peach_ActiviGo.Services.Services;

public class BookingService : IBookingService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public BookingService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<IEnumerable<Booking>> GetAllBookingsAsync(CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<Booking> GetBookingByIdAsync(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task AddBookingAsync(Booking booking, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task UpdateBookingAsync(Booking booking, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task DeleteBookingAsync(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}   
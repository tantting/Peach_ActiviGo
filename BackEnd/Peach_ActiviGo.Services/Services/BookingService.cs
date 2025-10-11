using AutoMapper;
using Peach_ActiviGo.Core.Interface;
using Peach_ActiviGo.Core.Models;
using Peach_ActiviGo.Infrastructure.Data;
using Peach_ActiviGo.Services.DTOs.BookingDtos;
using Peach_ActiviGo.Services.Interface;

namespace Peach_ActiviGo.Services.Services;

public class BookingService : IBookingService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;

    public BookingService(IUnitOfWork unitOfWork, IMapper mapper, AppDbContext context)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _context = context;
    }

    public async Task<IEnumerable<BookingDto>> GetAllBookingsAsync(CancellationToken ct)
    {
        var entities = await _unitOfWork.Bookings.GetAllBookingsAsync(ct);
        return _mapper.Map<IEnumerable<BookingDto>>(entities);
    }

    public async Task<BookingDto?> GetBookingByIdAsync(int id, CancellationToken ct)
    {
        var entity = await _unitOfWork.Bookings.GetBookingByIdAsync(id, ct);
        return entity is null ? null : _mapper.Map<BookingDto>(entity);
    }

    public Task AddBookingAsync(BookingDto booking, CancellationToken ct)
    {
        
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
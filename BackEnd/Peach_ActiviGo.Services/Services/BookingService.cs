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

    public async Task<BookingDto> GetBookingByIdAsync(int id, CancellationToken ct)
    {
        var entity = await _unitOfWork.Bookings.GetBookingByIdAsync(id, ct);
        if (entity is null) throw new InvalidOperationException("Booking not found.");
        return _mapper.Map<BookingDto>(entity);
    }

    public async Task<BookingDto> AddBookingAsync(BookingCreateDto dto, string userId, CancellationToken ct)
    {
        var booking = new Booking
        {
            CustomerId = userId,
            ActivitySlotId = dto.ActivitySlotId,
            Status = Core.Enums.BookingStatus.Active,
            CancelledAt = null,
        };
        _unitOfWork.Bookings.AddBooking(booking);
        await _unitOfWork.SaveChangesAsync(ct);
        return _mapper.Map<BookingDto>(booking);

    }

    public async Task UpdateBookingAsync(BookingUpdateDto booking, CancellationToken ct)
    {
        var existingBooking = await _unitOfWork.Bookings.GetBookingByIdAsync(booking.Id, ct);
        if (existingBooking == null)
        {
            throw new InvalidOperationException("Booking not found.");
        }

        // slotens tider för cutoff
        await _context.Entry(existingBooking).Reference(b => b.ActivitySlot).LoadAsync(ct);

        // endpointen stödjer bara avbokning
        if (booking.Status != Core.Enums.BookingStatus.Cancelled)
            return;

        // cutoff: 24h före start
        var cutoff = TimeSpan.FromHours(24);
        var nowUtc = DateTime.UtcNow;
        var cutoffTime = existingBooking.ActivitySlot.StartTime - cutoff;

        if (nowUtc > cutoffTime)
            throw new InvalidOperationException("Cannot cancel booking after the cut-off time.");

        // sätt status
        existingBooking.Status = Core.Enums.BookingStatus.Cancelled;
        existingBooking.CancelledAt = nowUtc;

        _unitOfWork.Bookings.UpdateBooking(existingBooking);
        await _unitOfWork.SaveChangesAsync(ct);
    }
    

    public async Task DeleteBookingAsync(int id, CancellationToken ct)
    {
        var entity = await _unitOfWork.Bookings.GetBookingByIdAsync(id, ct);
        if (entity is null) return;

        _unitOfWork.Bookings.DeleteBooking(entity);
        await _unitOfWork.SaveChangesAsync(ct);
    }

}   
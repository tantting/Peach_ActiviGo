using AutoMapper;
using Peach_ActiviGo.Core.Enums;
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

    public async Task<IEnumerable<BookingDto>> GetAllByMemberIdAndStatusAsync(
    string memberId, BookingStatus? status, CancellationToken ct)
    {
        var entities = await _unitOfWork.Bookings.GetByMemberAndStatusAsync(memberId, status, ct);
        return _mapper.Map<IEnumerable<BookingDto>>(entities);
    }

    public async Task<BookingDto> CreateBookingAsync(BookingCreateDto dto, string userId, CancellationToken ct)
    {
        bool alreadyBooked = await _unitOfWork.Bookings
            .UserHasActiveBookingAsync(userId, dto.ActivitySlotId, ct);
      
        if (alreadyBooked)
        {
            throw new InvalidOperationException("User already has an active booking for this activity slot.");
        }

        var booking = new Booking
        {
            CustomerId = userId,
            ActivitySlotId = dto.ActivitySlotId,
            Status = Core.Enums.BookingStatus.Active,
            CancelledAt = null,
            BookingDate = DateTime.UtcNow
        };

        _unitOfWork.Bookings.AddBooking(booking);
        await _unitOfWork.SaveChangesAsync(ct);

        // Ladda om med samma Includes som i GetById/GetAll
        var saved = await _unitOfWork.Bookings.GetBookingByIdAsync(booking.Id, ct);
        if (saved is null) throw new InvalidOperationException("Failed to reload created booking.");

        return _mapper.Map<BookingDto>(saved);

    }

    public async Task CancelBookingBeforeCutOffAsync(int id, CancellationToken ct)
    {
        var existingBooking = await _unitOfWork.Bookings.GetBookingByIdAsync(id, ct);
        if (existingBooking == null)
        {
            throw new InvalidOperationException("Booking not found.");
        }

        // slotens tider f�r cutoff
        await _context.Entry(existingBooking).Reference(b => b.ActivitySlot).LoadAsync(ct);

        // endpointen st�djer bara avbokning
        if (existingBooking.Status == BookingStatus.Cancelled)
            throw new InvalidOperationException("Booking is already cancelled.");

        // cutoff: 24h f�re start
        var cutoff = TimeSpan.FromHours(24);
        var nowUtc = DateTime.UtcNow;
        var cutoffTime = existingBooking.ActivitySlot.StartTime - cutoff;

        if (nowUtc > cutoffTime)
            throw new InvalidOperationException("Cannot cancel booking after the cut-off time.");

        // s�tt status
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

    public async Task<BookingStatisticsDto> GetBookingStatisticsAsync(CancellationToken ct)
    {
        var stats = await _unitOfWork.Bookings.GetBookingStatisticsAsync(ct);
        return _mapper.Map<BookingStatisticsDto>(stats);
    }
}
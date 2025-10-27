using Microsoft.EntityFrameworkCore;
using Peach_ActiviGo.Core.Enums;
using Peach_ActiviGo.Core.Models;

namespace Peach_ActiviGo.Infrastructure.Data;

public class BookingSeed
{
    public static async Task InitializeAsync(AppDbContext context)
    {
        // ✅ Se till att DB är migrerad
        await context.Database.MigrateAsync();

        // 🚫 Undvik duplicering
        if (context.Bookings.Any()) return;

        // Hämta existerande användare (från IdentitySeed)
        var users = await context.Users
            .Where(u => u.Email.StartsWith("user"))
            .ToListAsync();

        if (!users.Any())
        {
            Console.WriteLine("⚠️ Inga användare hittades – kör IdentitySeed först.");
            return;
        }

        // Hämta alla slots och filtrera på StartTime >= 2025-10-27 12:00 (eftermiddagar)
        DateTime minAllowedSlot = new DateTime(2025, 10, 27, 12, 0, 0);
        var futureSlots = await context.ActivitySlots
            .Where(s => s.StartTime >= minAllowedSlot)
            .OrderBy(s => s.StartTime)
            .ToListAsync();

        if (!futureSlots.Any())
        {
            Console.WriteLine("⚠️ Inga ActivitySlots med StartTime >= 2025-10-27 12:00 hittades. Seed avbryts.");
            return;
        }

        var rnd = new Random();
        var bookings = new List<Booking>();

        int totalBookings = 30; // fler bokningar som du bad om

        // skapa bookingar; vi kör genom futureSlots slumpmässigt
        for (int i = 1; i <= totalBookings; i++)
        {
            var user = users[rnd.Next(users.Count)];
            var slot = futureSlots[rnd.Next(futureSlots.Count)];

            var status = rnd.NextDouble() < 0.8 ? BookingStatus.Active : BookingStatus.Cancelled;

            bookings.Add(new Booking
            {
                // Låt EF sätta Id automatiskt (ta bort om du vill hårdkoda Id)
                CustomerId = user.Id,
                ActivitySlotId = slot.Id,
                BookingDate = slot.StartTime, // här matchar bokningsdatum slotens starttid
                Status = status,
                CancelledAt = status == BookingStatus.Cancelled ? (DateTime?)slot.StartTime.AddHours(-1) : null
            });
        }

        await context.Bookings.AddRangeAsync(bookings);
        await context.SaveChangesAsync();

        Console.WriteLine($"✅ {totalBookings} bokningar skapade (kopplade till slots med start >= {minAllowedSlot:yyyy-MM-dd HH:mm}).");
    }
}
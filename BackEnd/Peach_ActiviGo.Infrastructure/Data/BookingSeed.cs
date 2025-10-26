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

        var slots = await context.ActivitySlots.ToListAsync();
        if (!slots.Any())
        {
            Console.WriteLine("⚠️ Inga ActivitySlots hittades – kör AppDbContext-seed först.");
            return;
        }

        var random = new Random();
        var bookings = new List<Booking>();

        for (int i = 0; i < 20; i++)
        {
            var user = users[random.Next(users.Count)];
            var slot = slots[random.Next(slots.Count)];

            var status = random.NextDouble() < 0.8 ? BookingStatus.Active : BookingStatus.Cancelled;

            var bookingDate = (i == 0)
                ? new DateTime(2025, 10, 28, 15, 0, 0) // Bokning 1: tisdag 28 okt kl 15–17
                : new DateTime(2025, 10, 31).AddDays(random.Next(0, 7)).AddHours(random.Next(9, 18));

            bookings.Add(new Booking
            {
                CustomerId = user.Id,
                ActivitySlotId = slot.Id,
                BookingDate = bookingDate,
                Status = status,
                CancelledAt = status == BookingStatus.Cancelled ? bookingDate.AddDays(random.Next(0, 2)) : null
            });
        }

        await context.Bookings.AddRangeAsync(bookings);
        await context.SaveChangesAsync();

        Console.WriteLine("✅ 20 bokningar seedade! (inkl. 1 specialbokning 28 okt)");
    }
}
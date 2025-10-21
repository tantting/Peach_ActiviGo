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

        // Hämta ActivitySlots
        var slots = await context.ActivitySlots.ToListAsync();

        if (!slots.Any())
        {
            Console.WriteLine("⚠️ Inga ActivitySlots hittades – kontrollera att du seedat dem.");
            return;
        }

        var random = new Random();
        var bookings = new List<Booking>();

        for (int i = 0; i < 20; i++)
        {
            var user = users[random.Next(users.Count)];
            var slot = slots[random.Next(slots.Count)];

            // Slumpa status: 80% Active, 20% Cancelled
            var status = random.NextDouble() < 0.8 ? BookingStatus.Active : BookingStatus.Cancelled;

            bookings.Add(new Booking
            {
                CustomerId = user.Id,
                ActivitySlotId = slot.Id,
                BookingDate = DateTime.Now.AddDays(-random.Next(0, 14)), // Bokningsdatum inom senaste 2 veckor
                Status = status,
                CancelledAt = status == BookingStatus.Cancelled ? DateTime.Now.AddDays(-random.Next(0, 7)) : null
            });
        }

        await context.Bookings.AddRangeAsync(bookings);
        await context.SaveChangesAsync();

        Console.WriteLine("✅ 20 bokningar seedade!");
    }
}
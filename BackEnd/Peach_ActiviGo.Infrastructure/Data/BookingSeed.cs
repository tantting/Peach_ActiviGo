using Microsoft.EntityFrameworkCore;
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
        var user1 = await context.Users.FirstOrDefaultAsync(u => u.Email == "user1@example.com");
        var user2 = await context.Users.FirstOrDefaultAsync(u => u.Email == "user2@example.com");
        var user3 = await context.Users.FirstOrDefaultAsync(u => u.Email == "user3@example.com");

        if (user1 == null || user2 == null || user3 == null)
        {
            Console.WriteLine("⚠️ Användare saknas – kan inte seeda bokningar ännu.");
            return;
        }

        // Hämta några ActivitySlots
        var slots = await context.ActivitySlots.Take(3).ToListAsync();

        if (!slots.Any())
        {
            Console.WriteLine("⚠️ Inga ActivitySlots hittades – kontrollera att du har seedat dem.");
            return;
        }

        // Lägg till några bokningar
        var bookings = new List<Booking>
        {
            new Booking { CustomerId = user1.Id, ActivitySlotId = slots[0].Id, BookingDate = DateTime.Now.AddDays(-2) },
            new Booking { CustomerId = user2.Id, ActivitySlotId = slots[1].Id, BookingDate = DateTime.Now.AddDays(-1) },
            new Booking { CustomerId = user3.Id, ActivitySlotId = slots[2].Id, BookingDate = DateTime.Now }
        };

        await context.Bookings.AddRangeAsync(bookings);
        await context.SaveChangesAsync();

        Console.WriteLine("✅ Bokningar seedade!");
    }
}
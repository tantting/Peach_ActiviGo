using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Peach_ActiviGo.Core.Models;

namespace Peach_ActiviGo.Infrastructure.Data;

public class AppDbContext : IdentityDbContext<IdentityUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Activity> Activities { get; set; }
    public DbSet<ActivityLocation> ActivityLocations { get; set; }
    public DbSet<ActivitySlot> ActivitySlots { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Location> Locations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // -------- RELATIONER --------

        //Location
        modelBuilder.Entity<Location>()
            .Property(l => l.Latitude)
            .HasColumnType("decimal(9,6)");

        modelBuilder.Entity<Location>()
            .Property(l => l.Longitude)
            .HasColumnType("decimal(9,6)");

        // Category 1 - * Activity
        modelBuilder.Entity<Activity>()
            .HasOne(a => a.Category)
            .WithMany()
            .HasForeignKey(a => a.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        // ActivityLocation (många-till-många brygga)
        modelBuilder.Entity<ActivityLocation>()
            .HasOne(al => al.Activity)
            .WithMany()
            .HasForeignKey(al => al.ActivityId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ActivityLocation>()
            .HasOne(al => al.Location)
            .WithMany(l => l.ActivityLocations)
            .HasForeignKey(al => al.LocationId)
            .OnDelete(DeleteBehavior.Restrict);

        // ActivitySlot 1 - * Booking
        modelBuilder.Entity<Booking>()
            .HasOne(b => b.ActivitySlot)
            .WithMany()
            .HasForeignKey(b => b.ActivitySlotId)
            .OnDelete(DeleteBehavior.Restrict);

        // Unik kombination (Activity + Location + IsIndoor)
        modelBuilder.Entity<ActivityLocation>()
            .HasIndex(al => new { al.ActivityId, al.LocationId, al.IsIndoor })
            .IsUnique();

        //modelBuilder.Entity<Booking>()
        //    .HasOne<IdentityUser>()
        //    .WithMany()
        //    .HasForeignKey(b => b.CustomerId)
        //    .OnDelete(DeleteBehavior.Restrict);

        // KNYT navigationen 'Customer' till FK 'CustomerId' så EF inte skapar CustomerId1
        modelBuilder.Entity<Booking>()
            .HasOne(b => b.Customer)
            .WithMany()
            .HasForeignKey(b => b.CustomerId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<ActivitySlot>()
            .HasOne(s => s.ActivityLocation)
            .WithMany()
            .HasForeignKey(s => s.ActivityLocationId)
            .OnDelete(DeleteBehavior.Restrict);

        // -------- SEED DATA --------

        // 🏷️ Kategorier
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Träning" },
            new Category { Id = 2, Name = "Spel" },
            new Category { Id = 3, Name = "Kondition" }
        );

        // 📍 Platser
        modelBuilder.Entity<Location>().HasData(
            new Location
            {
                Id = 1,
                Name = "Sportcenter X",
                Address = "Huvudgatan 1",
                Latitude = 59.330000m,
                Longitude = 18.060000m
            },
            new Location
            {
                Id = 2,
                Name = "Utomhusarenan",
                Address = "Parkvägen 5",
                Latitude = 59.320000m,
                Longitude = 18.040000m
            },
            new Location
            {
                Id = 3,
                Name = "City Gym",
                Address = "Centrumtorget 2",
                Latitude = 59.340000m,
                Longitude = 18.050000m
            }
        );

        // 🏐 Aktiviteter
        modelBuilder.Entity<Activity>().HasData(
            new Activity { Id = 1, Name = "Padel", Description = "Racketsport i par", Price = 120, ImageUrl = "/img/padel.jpg", CategoryId = 2 },
            new Activity { Id = 2, Name = "Pingis", Description = "Inomhus pingis", Price = 80, ImageUrl = "/img/pingis.jpg", CategoryId = 2 },
            new Activity { Id = 3, Name = "Klättring", Description = "Inomhusklättring", Price = 150, ImageUrl = "/img/climb.jpg", CategoryId = 1 },
            new Activity { Id = 4, Name = "Utegym", Description = "Träning i utegym", Price = 0, ImageUrl = "/img/utegym.jpg", CategoryId = 1 },
            new Activity { Id = 5, Name = "Yoga", Description = "Lugn och fokuserad träning", Price = 100, ImageUrl = "/img/yoga.jpg", CategoryId = 1 },
            new Activity { Id = 6, Name = "Bootcamp", Description = "Högintensiv utomhusträning", Price = 120, ImageUrl = "/img/bootcamp.jpg", CategoryId = 3 },
            new Activity { Id = 7, Name = "Löpning", Description = "Gruppträning löpning", Price = 60, ImageUrl = "/img/run.jpg", CategoryId = 3 },
            new Activity { Id = 8, Name = "Crossfit", Description = "Kondition och styrka", Price = 140, ImageUrl = "/img/crossfit.jpg", CategoryId = 1 }
        );

        // 📍 ActivityLocations (koppling aktivitet-plats)
        modelBuilder.Entity<ActivityLocation>().HasData(
            new ActivityLocation { Id = 1, ActivityId = 1, LocationId = 1, Capacity = 4, IsIndoor = true },
            new ActivityLocation { Id = 2, ActivityId = 1, LocationId = 2, Capacity = 4, IsIndoor = false },
            new ActivityLocation { Id = 3, ActivityId = 2, LocationId = 1, Capacity = 2, IsIndoor = true },
            new ActivityLocation { Id = 4, ActivityId = 3, LocationId = 1, Capacity = 8, IsIndoor = true },
            new ActivityLocation { Id = 5, ActivityId = 4, LocationId = 2, Capacity = 10, IsIndoor = false },
            new ActivityLocation { Id = 6, ActivityId = 5, LocationId = 3, Capacity = 12, IsIndoor = true },
            new ActivityLocation { Id = 7, ActivityId = 6, LocationId = 2, Capacity = 15, IsIndoor = false },
            new ActivityLocation { Id = 8, ActivityId = 7, LocationId = 2, Capacity = 20, IsIndoor = false }
        );

        // 🕒 ActivitySlots (20+ tillfällen kommande veckor)
        var slots = new List<ActivitySlot>();
        var idCounter = 1;
        var startDate = DateTime.Today.AddDays(1);
        var rand = new Random();

        for (int locId = 1; locId <= 8; locId++)
        {
            for (int i = 0; i < 3; i++)
            {
                var day = startDate.AddDays(i * 3 + locId);
                slots.Add(new ActivitySlot
                {
                    Id = idCounter++,
                    ActivityLocationId = locId,
                    StartTime = day.AddHours(17),
                    EndTime = day.AddHours(18),
                });
            }
        }

        // >>> NEW: Lägg till några HISTORISKA slots (i dåtid) innan vi ropar HasData(slots).
        var histDates = new[]
        {
            DateTime.Today.AddDays(-10),
            DateTime.Today.AddDays(-7),
            DateTime.Today.AddDays(-4),
            DateTime.Today.AddDays(-2)
        };
        var histLocs = new[] { 1, 3, 5, 7 }; // välj valfria ActivityLocationId som finns
        var histIds = new List<int>();

        for (int i = 0; i < histDates.Length; i++)
        {
            slots.Add(new ActivitySlot
            {
                Id = idCounter,
                ActivityLocationId = histLocs[i],
                StartTime = histDates[i].AddHours(17),
                EndTime = histDates[i].AddHours(18),
            });
            histIds.Add(idCounter++);
        }
        // <<< NEW (slut historiska slots)

        modelBuilder.Entity<ActivitySlot>().HasData(slots);

        // ===== ADD 2: BOOKINGS för DINA BEFINTLIGA ANVÄNDARE =====
        // 1) Klistra in EXAKTA Id-strängar från din tabell dbo.AspNetUsers (kolumnen "Id").
        //    Titta i din bild/tabell och mappa rätt e-post → rätt variabel här nedan.

        var USER3_ID = "1f9ede01-aff8-4803-910c-24e78bc7fb8a";  // user3@example.com (markerad rad på din bild)
        var ADMIN_ID = "2786eacf-fda5-4772-9336-5cb72ccce08b";   // exempel@live.com
        var USER4_ID = "3217607b-81cc-4fdd-a16f-00e186e2d74f";   // user4@example.com
        var TEST_ID = "8a54eb5f-01bc-4055-a6bf-be2048462451";   // test@mail.com
        var USER2_ID = "aa2c47dc-15f2-4e15-b409-7f94b48e554c";   // user2@example.com
        var USER1_ID = "cce4e116-f149-4d7a-9094-e3cfc2a62229";   // user1@example.com

        // 2) Skapa bokningar. Använd fasta datum (inte DateTime.Now) i HasData.
        //    * Om du gjorde ADD 1 ovan kan du använda histIds[0..3] för "gamla bokningar".
        //    * Dina befintliga (kommande) slots börjar normalt på Id = 1 och uppåt (från din egen slots-loop).

        var bookingSeed = new List<Booking>
{
    // —— Historiska bokningar (kräver ADD 1) ——
    new Booking { Id = 1001, CustomerId = USER1_ID, ActivitySlotId = histIds[0], BookingDate = histDates[0].AddDays(-1) },
    new Booking { Id = 1002, CustomerId = USER2_ID, ActivitySlotId = histIds[1], BookingDate = histDates[1].AddDays(-1) },
    new Booking { Id = 1003, CustomerId = USER3_ID, ActivitySlotId = histIds[2], BookingDate = histDates[2].AddDays(-1) },
    new Booking { Id = 1004, CustomerId = TEST_ID,  ActivitySlotId = histIds[3], BookingDate = histDates[3].AddDays(-1) },

    // —— Kommande bokningar (pekar på dina redan seedade framtida slots) ——
    new Booking { Id = 1005, CustomerId = USER1_ID, ActivitySlotId = 1, BookingDate = new DateTime(2025, 01, 10, 12, 00, 00) },
    new Booking { Id = 1006, CustomerId = USER2_ID, ActivitySlotId = 2, BookingDate = new DateTime(2025, 01, 11, 12, 00, 00) },
    new Booking { Id = 1007, CustomerId = USER3_ID, ActivitySlotId = 3, BookingDate = new DateTime(2025, 01, 12, 12, 00, 00) },
    new Booking { Id = 1008, CustomerId = USER4_ID, ActivitySlotId = 4, BookingDate = new DateTime(2025, 01, 13, 12, 00, 00) },
    new Booking { Id = 1009, CustomerId = ADMIN_ID, ActivitySlotId = 5, BookingDate = new DateTime(2025, 01, 14, 12, 00, 00) }
};

        modelBuilder.Entity<Booking>().HasData(bookingSeed);

    }
}
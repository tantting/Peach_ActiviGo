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

        // --- Categories ---
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Äventyr", Description = "Spännande utomhusaktiviteter" },
            new Category { Id = 2, Name = "Vatten", Description = "Aktiviteter vid havet och sjöar" },
            new Category { Id = 3, Name = "Träning", Description = "Inomhus- och utomhusträning" },
            new Category { Id = 4, Name = "Avkoppling", Description = "Lugna aktiviteter för kropp och själ" }
        );

        // --- Locations ---
        modelBuilder.Entity<Location>().HasData(
            new Location { Id = 1, Name = "Varberg", Address = "Varberg centrum", Latitude = 57.1056m, Longitude = 12.2508m },
            new Location { Id = 2, Name = "Göteborg", Address = "Göteborg centrum", Latitude = 57.7089m, Longitude = 11.9746m },
            new Location { Id = 3, Name = "Stockholm", Address = "Stockholm centrum", Latitude = 59.3293m, Longitude = 18.0686m },
            new Location { Id = 4, Name = "Malmö", Address = "Malmö centrum", Latitude = 55.6050m, Longitude = 13.0038m },
            new Location { Id = 5, Name = "Umeå", Address = "Umeå centrum", Latitude = 63.8258m, Longitude = 20.2630m }
        );

        // --- Activities ---
        modelBuilder.Entity<Activity>().HasData(
            new Activity { Id = 1, Name = "Surfkurs", Description = "Lär dig surfa i havet", Price = 899, ImageUrl = "images/surf.jpg", CategoryId = 2 },
            new Activity { Id = 2, Name = "Yogapass", Description = "Avkopplande yoga inomhus", Price = 299, ImageUrl = "images/yoga.jpg", CategoryId = 4 },
            new Activity { Id = 3, Name = "Klättring", Description = "Klättra på olika nivåer", Price = 499, ImageUrl = "images/climb.jpg", CategoryId = 1 },
            new Activity { Id = 4, Name = "Mountainbike", Description = "Cykla i skog och mark", Price = 699, ImageUrl = "images/mtb.jpg", CategoryId = 3 },
            new Activity { Id = 5, Name = "Stand Up Paddle", Description = "Paddla i lugnt vatten", Price = 599, ImageUrl = "images/sup.jpg", CategoryId = 2 },
            new Activity { Id = 6, Name = "Spinning", Description = "Intensiv cykelträning inomhus", Price = 249, ImageUrl = "images/spinning.jpg", CategoryId = 3 },
            new Activity { Id = 7, Name = "Saunagus", Description = "Bastuupplevelse med dofter", Price = 350, ImageUrl = "images/sauna.jpg", CategoryId = 4 },
            new Activity { Id = 8, Name = "Paintball", Description = "Actionfyllt lagspel utomhus", Price = 550, ImageUrl = "images/paintball.jpg", CategoryId = 1 }
        );

        // --- ActivityLocations ---
        modelBuilder.Entity<ActivityLocation>().HasData(
            new ActivityLocation { Id = 1, ActivityId = 1, LocationId = 1, Capacity = 15, IsIndoor = false, isActive = true },
            new ActivityLocation { Id = 2, ActivityId = 1, LocationId = 2, Capacity = 12, IsIndoor = false, isActive = true },
            new ActivityLocation { Id = 3, ActivityId = 2, LocationId = 3, Capacity = 10, IsIndoor = true, isActive = true },
            new ActivityLocation { Id = 4, ActivityId = 2, LocationId = 4, Capacity = 8, IsIndoor = true, isActive = true },
            new ActivityLocation { Id = 5, ActivityId = 3, LocationId = 5, Capacity = 18, IsIndoor = false, isActive = true },
            new ActivityLocation { Id = 6, ActivityId = 4, LocationId = 1, Capacity = 14, IsIndoor = false, isActive = true },
            new ActivityLocation { Id = 7, ActivityId = 5, LocationId = 2, Capacity = 16, IsIndoor = false, isActive = true },
            new ActivityLocation { Id = 8, ActivityId = 6, LocationId = 3, Capacity = 12, IsIndoor = true, isActive = true },
            new ActivityLocation { Id = 9, ActivityId = 7, LocationId = 4, Capacity = 10, IsIndoor = true, isActive = true },
            new ActivityLocation { Id = 10, ActivityId = 8, LocationId = 5, Capacity = 20, IsIndoor = false, isActive = true }
        );

        modelBuilder.Entity<ActivitySlot>().HasData(
    // ActivityLocationId = 1 → 2025-10-27
    new ActivitySlot { Id = 1,  ActivityLocationId = 1, StartTime = new DateTime(2025,10,27,14,00,0), EndTime = new DateTime(2025,10,27,15,30,0), SlotCapacity = 15 },
    new ActivitySlot { Id = 2,  ActivityLocationId = 1, StartTime = new DateTime(2025,10,27,16,00,0), EndTime = new DateTime(2025,10,27,17,30,0), SlotCapacity = 15 },
    new ActivitySlot { Id = 3,  ActivityLocationId = 1, StartTime = new DateTime(2025,10,27,18,00,0), EndTime = new DateTime(2025,10,27,19,30,0), SlotCapacity = 15 },
    new ActivitySlot { Id = 4,  ActivityLocationId = 1, StartTime = new DateTime(2025,10,27,20,00,0), EndTime = new DateTime(2025,10,27,21,30,0), SlotCapacity = 15 },

    // ActivityLocationId = 2 → 2025-10-28
    new ActivitySlot { Id = 5,  ActivityLocationId = 2, StartTime = new DateTime(2025,10,28,14,00,0), EndTime = new DateTime(2025,10,28,15,30,0), SlotCapacity = 12 },
    new ActivitySlot { Id = 6,  ActivityLocationId = 2, StartTime = new DateTime(2025,10,28,16,00,0), EndTime = new DateTime(2025,10,28,17,30,0), SlotCapacity = 12 },
    new ActivitySlot { Id = 7,  ActivityLocationId = 2, StartTime = new DateTime(2025,10,28,18,00,0), EndTime = new DateTime(2025,10,28,19,30,0), SlotCapacity = 12 },
    new ActivitySlot { Id = 8,  ActivityLocationId = 2, StartTime = new DateTime(2025,10,28,20,00,0), EndTime = new DateTime(2025,10,28,21,30,0), SlotCapacity = 12 },

    // ActivityLocationId = 3 → 2025-10-29
    new ActivitySlot { Id = 9,  ActivityLocationId = 3, StartTime = new DateTime(2025,10,29,14,00,0), EndTime = new DateTime(2025,10,29,15,30,0), SlotCapacity = 10 },
    new ActivitySlot { Id = 10, ActivityLocationId = 3, StartTime = new DateTime(2025,10,29,16,00,0), EndTime = new DateTime(2025,10,29,17,30,0), SlotCapacity = 10 },
    new ActivitySlot { Id = 11, ActivityLocationId = 3, StartTime = new DateTime(2025,10,29,18,00,0), EndTime = new DateTime(2025,10,29,19,30,0), SlotCapacity = 10 },
    new ActivitySlot { Id = 12, ActivityLocationId = 3, StartTime = new DateTime(2025,10,29,20,00,0), EndTime = new DateTime(2025,10,29,21,30,0), SlotCapacity = 10 },

    // ActivityLocationId = 4 → 2025-10-30
    new ActivitySlot { Id = 13, ActivityLocationId = 4, StartTime = new DateTime(2025,10,30,14,00,0), EndTime = new DateTime(2025,10,30,15,30,0), SlotCapacity = 8 },
    new ActivitySlot { Id = 14, ActivityLocationId = 4, StartTime = new DateTime(2025,10,30,16,00,0), EndTime = new DateTime(2025,10,30,17,30,0), SlotCapacity = 8 },
    new ActivitySlot { Id = 15, ActivityLocationId = 4, StartTime = new DateTime(2025,10,30,18,00,0), EndTime = new DateTime(2025,10,30,19,30,0), SlotCapacity = 8 },
    new ActivitySlot { Id = 16, ActivityLocationId = 4, StartTime = new DateTime(2025,10,30,20,00,0), EndTime = new DateTime(2025,10,30,21,30,0), SlotCapacity = 8 },

    // ActivityLocationId = 5 → 2025-10-31
    new ActivitySlot { Id = 17, ActivityLocationId = 5, StartTime = new DateTime(2025,10,31,14,00,0), EndTime = new DateTime(2025,10,31,15,30,0), SlotCapacity = 18 },
    new ActivitySlot { Id = 18, ActivityLocationId = 5, StartTime = new DateTime(2025,10,31,16,00,0), EndTime = new DateTime(2025,10,31,17,30,0), SlotCapacity = 18 },
    new ActivitySlot { Id = 19, ActivityLocationId = 5, StartTime = new DateTime(2025,10,31,18,00,0), EndTime = new DateTime(2025,10,31,19,30,0), SlotCapacity = 18 },
    new ActivitySlot { Id = 20, ActivityLocationId = 5, StartTime = new DateTime(2025,10,31,20,00,0), EndTime = new DateTime(2025,10,31,21,30,0), SlotCapacity = 18 },

    // ActivityLocationId = 6 → 2025-11-01
    new ActivitySlot { Id = 21, ActivityLocationId = 6, StartTime = new DateTime(2025,11,1,14,00,0), EndTime = new DateTime(2025,11,1,15,30,0), SlotCapacity = 14 },
    new ActivitySlot { Id = 22, ActivityLocationId = 6, StartTime = new DateTime(2025,11,1,16,00,0), EndTime = new DateTime(2025,11,1,17,30,0), SlotCapacity = 14 },
    new ActivitySlot { Id = 23, ActivityLocationId = 6, StartTime = new DateTime(2025,11,1,18,00,0), EndTime = new DateTime(2025,11,1,19,30,0), SlotCapacity = 14 },
    new ActivitySlot { Id = 24, ActivityLocationId = 6, StartTime = new DateTime(2025,11,1,20,00,0), EndTime = new DateTime(2025,11,1,21,30,0), SlotCapacity = 14 },

    // ActivityLocationId = 7 → 2025-11-02
    new ActivitySlot { Id = 25, ActivityLocationId = 7, StartTime = new DateTime(2025,11,2,14,00,0), EndTime = new DateTime(2025,11,2,15,30,0), SlotCapacity = 16 },
    new ActivitySlot { Id = 26, ActivityLocationId = 7, StartTime = new DateTime(2025,11,2,16,00,0), EndTime = new DateTime(2025,11,2,17,30,0), SlotCapacity = 16 },
    new ActivitySlot { Id = 27, ActivityLocationId = 7, StartTime = new DateTime(2025,11,2,18,00,0), EndTime = new DateTime(2025,11,2,19,30,0), SlotCapacity = 16 },
    new ActivitySlot { Id = 28, ActivityLocationId = 7, StartTime = new DateTime(2025,11,2,20,00,0), EndTime = new DateTime(2025,11,2,21,30,0), SlotCapacity = 16 },

    // ActivityLocationId = 8 → 2025-11-03
    new ActivitySlot { Id = 29, ActivityLocationId = 8, StartTime = new DateTime(2025,11,3,14,00,0), EndTime = new DateTime(2025,11,3,15,30,0), SlotCapacity = 12 },
    new ActivitySlot { Id = 30, ActivityLocationId = 8, StartTime = new DateTime(2025,11,3,16,00,0), EndTime = new DateTime(2025,11,3,17,30,0), SlotCapacity = 12 },
    new ActivitySlot { Id = 31, ActivityLocationId = 8, StartTime = new DateTime(2025,11,3,18,00,0), EndTime = new DateTime(2025,11,3,19,30,0), SlotCapacity = 12 },
    new ActivitySlot { Id = 32, ActivityLocationId = 8, StartTime = new DateTime(2025,11,3,20,00,0), EndTime = new DateTime(2025,11,3,21,30,0), SlotCapacity = 12 },

    // ActivityLocationId = 9 → 2025-11-04
    new ActivitySlot { Id = 33, ActivityLocationId = 9, StartTime = new DateTime(2025,11,4,14,00,0), EndTime = new DateTime(2025,11,4,15,30,0), SlotCapacity = 10 },
    new ActivitySlot { Id = 34, ActivityLocationId = 9, StartTime = new DateTime(2025,11,4,16,00,0), EndTime = new DateTime(2025,11,4,17,30,0), SlotCapacity = 10 },
    new ActivitySlot { Id = 35, ActivityLocationId = 9, StartTime = new DateTime(2025,11,4,18,00,0), EndTime = new DateTime(2025,11,4,19,30,0), SlotCapacity = 10 },
    new ActivitySlot { Id = 36, ActivityLocationId = 9, StartTime = new DateTime(2025,11,4,20,00,0), EndTime = new DateTime(2025,11,4,21,30,0), SlotCapacity = 10 },

    // ActivityLocationId = 10 → 2025-11-05
    new ActivitySlot { Id = 37, ActivityLocationId = 10, StartTime = new DateTime(2025,11,5,14,00,0), EndTime = new DateTime(2025,11,5,15,30,0), SlotCapacity = 20 },
    new ActivitySlot { Id = 38, ActivityLocationId = 10, StartTime = new DateTime(2025,11,5,16,00,0), EndTime = new DateTime(2025,11,5,17,30,0), SlotCapacity = 20 },
    new ActivitySlot { Id = 39, ActivityLocationId = 10, StartTime = new DateTime(2025,11,5,18,00,0), EndTime = new DateTime(2025,11,5,19,30,0), SlotCapacity = 20 },
    new ActivitySlot { Id = 40, ActivityLocationId = 10, StartTime = new DateTime(2025,11,5,20,00,0), EndTime = new DateTime(2025,11,5,21,30,0), SlotCapacity = 20 }
);
    }
}
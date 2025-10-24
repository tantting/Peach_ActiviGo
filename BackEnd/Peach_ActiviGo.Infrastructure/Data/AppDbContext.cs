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

        // Categories
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Äventyr", Description = "Spännande utomhusaktiviteter" },
            new Category { Id = 2, Name = "Vatten", Description = "Aktiviteter vid havet och sjöar" },
            new Category { Id = 3, Name = "Träning", Description = "Inomhus- och utomhusträning" },
            new Category { Id = 4, Name = "Avkoppling", Description = "Lugna aktiviteter för kropp och själ" }
        );

        // Locations
        modelBuilder.Entity<Location>().HasData(
            new Location
                { Id = 1, Name = "Varberg", Address = "Varberg centrum", Latitude = 57.1056m, Longitude = 12.2508m },
            new Location
                { Id = 2, Name = "Falkenberg", Address = "Falkenberg centrum", Latitude = 56.9055m, Longitude = 12.4912m },
            new Location
                { Id = 3, Name = "Halmstad", Address = "Halmstad centrum", Latitude = 56.6745m, Longitude = 12.8570m },
            new Location
                { Id = 4, Name = "Veddige", Address = "Veddige centrum", Latitude = 57.2297m, Longitude = 12.3836m },
            new Location
                { Id = 5, Name = "Slöinge", Address = "Slöinge centrum", Latitude = 56.8358m, Longitude = 12.7135m }
        );

        // Activities
        modelBuilder.Entity<Activity>().HasData(
            new Activity
            {
                Id = 1, Name = "Surfkurs", Description = "Lär dig surfa i havet", Price = 899,
                ImageUrl = "images/surf.jpg", CategoryId = 2
            },
            new Activity
            {
                Id = 2, Name = "Yogapass", Description = "Avkopplande yoga inomhus", Price = 299,
                ImageUrl = "images/yoga.jpg", CategoryId = 4
            },
            new Activity
            {
                Id = 3, Name = "Klattring", Description = "Klattra på olika nivåer", Price = 499,
                ImageUrl = "images/climb.jpg", CategoryId = 1
            },
            new Activity
            {
                Id = 4, Name = "Mountainbike", Description = "Cykla i skog och mark", Price = 699,
                ImageUrl = "images/mtb.jpg", CategoryId = 3
            },
            new Activity
            {
                Id = 5, Name = "Stand Up Paddle", Description = "Paddla i lugnt vatten", Price = 599,
                ImageUrl = "images/sup.jpg", CategoryId = 2
            },
            new Activity
            {
                Id = 6, Name = "Spinning", Description = "Intensiv cykelträning inomhus", Price = 249,
                ImageUrl = "images/spinning.jpg", CategoryId = 3
            },
            new Activity
            {
                Id = 7, Name = "Saunagus", Description = "Bastuupplevelse med dofter", Price = 350,
                ImageUrl = "images/sauna.jpg", CategoryId = 4
            },
            new Activity
            {
                Id = 8, Name = "Paintball", Description = "Actionfyllt lagspel utomhus", Price = 550,
                ImageUrl = "images/paintball.jpg", CategoryId = 1
            }
        );

        // --- ActivityLocations (Hårdkodad) ---
        modelBuilder.Entity<ActivityLocation>().HasData(
            new ActivityLocation
                { Id = 1, ActivityId = 1, LocationId = 1, Capacity = 15, IsIndoor = false, isActive = true },
            new ActivityLocation
                { Id = 2, ActivityId = 1, LocationId = 2, Capacity = 12, IsIndoor = false, isActive = true },
            new ActivityLocation
                { Id = 3, ActivityId = 2, LocationId = 3, Capacity = 10, IsIndoor = true, isActive = true },
            new ActivityLocation
                { Id = 4, ActivityId = 2, LocationId = 4, Capacity = 8, IsIndoor = true, isActive = true },
            new ActivityLocation
                { Id = 5, ActivityId = 3, LocationId = 5, Capacity = 18, IsIndoor = false, isActive = true },
            new ActivityLocation
                { Id = 6, ActivityId = 4, LocationId = 1, Capacity = 14, IsIndoor = false, isActive = true },
            new ActivityLocation
                { Id = 7, ActivityId = 5, LocationId = 2, Capacity = 16, IsIndoor = false, isActive = true },
            new ActivityLocation
                { Id = 8, ActivityId = 6, LocationId = 3, Capacity = 12, IsIndoor = true, isActive = true },
            new ActivityLocation
                { Id = 9, ActivityId = 7, LocationId = 4, Capacity = 10, IsIndoor = true, isActive = true },
            new ActivityLocation
                { Id = 10, ActivityId = 8, LocationId = 5, Capacity = 20, IsIndoor = false, isActive = true }
        );

        // --- ActivitySlots (2 per ActivityLocation) ---
        modelBuilder.Entity<ActivitySlot>().HasData(
            // ActivityLocationId = 1
            new ActivitySlot
            {
                Id = 1, ActivityLocationId = 1, StartTime = new DateTime(2025, 10, 25, 10, 0, 0),
                EndTime = new DateTime(2025, 10, 25, 12, 0, 0), SlotCapacity = 12, IsCancelled = false
            },
            new ActivitySlot
            {
                Id = 2, ActivityLocationId = 1, StartTime = new DateTime(2025, 10, 25, 14, 0, 0),
                EndTime = new DateTime(2025, 10, 25, 16, 0, 0), SlotCapacity = 12, IsCancelled = false
            },

            // ActivityLocationId = 2
            new ActivitySlot
            {
                Id = 3, ActivityLocationId = 2, StartTime = new DateTime(2025, 10, 26, 10, 0, 0),
                EndTime = new DateTime(2025, 10, 26, 12, 0, 0), SlotCapacity = 10, IsCancelled = false
            },
            new ActivitySlot
            {
                Id = 4, ActivityLocationId = 2, StartTime = new DateTime(2025, 10, 26, 14, 0, 0),
                EndTime = new DateTime(2025, 10, 26, 16, 0, 0), SlotCapacity = 10, IsCancelled = false
            },

            // ActivityLocationId = 3
            new ActivitySlot
            {
                Id = 5, ActivityLocationId = 3, StartTime = new DateTime(2025, 10, 27, 09, 0, 0),
                EndTime = new DateTime(2025, 10, 27, 11, 0, 0), SlotCapacity = 8, IsCancelled = false
            },
            new ActivitySlot
            {
                Id = 6, ActivityLocationId = 3, StartTime = new DateTime(2025, 10, 27, 12, 0, 0),
                EndTime = new DateTime(2025, 10, 27, 14, 0, 0), SlotCapacity = 8, IsCancelled = false
            },

            // ActivityLocationId = 4
            new ActivitySlot
            {
                Id = 7, ActivityLocationId = 4, StartTime = new DateTime(2025, 10, 28, 10, 0, 0),
                EndTime = new DateTime(2025, 10, 28, 12, 0, 0), SlotCapacity = 8, IsCancelled = false
            },
            new ActivitySlot
            {
                Id = 8, ActivityLocationId = 4, StartTime = new DateTime(2025, 10, 28, 14, 0, 0),
                EndTime = new DateTime(2025, 10, 28, 16, 0, 0), SlotCapacity = 8, IsCancelled = false
            },

            // ActivityLocationId = 5
            new ActivitySlot
            {
                Id = 9, ActivityLocationId = 5, StartTime = new DateTime(2025, 10, 29, 10, 0, 0),
                EndTime = new DateTime(2025, 10, 29, 12, 0, 0), SlotCapacity = 18, IsCancelled = false
            },
            new ActivitySlot
            {
                Id = 10, ActivityLocationId = 5, StartTime = new DateTime(2025, 10, 29, 14, 0, 0),
                EndTime = new DateTime(2025, 10, 29, 16, 0, 0), SlotCapacity = 18, IsCancelled = false
            },

            // ActivityLocationId = 6
            new ActivitySlot
            {
                Id = 11, ActivityLocationId = 6, StartTime = new DateTime(2025, 10, 30, 10, 0, 0),
                EndTime = new DateTime(2025, 10, 30, 12, 0, 0), SlotCapacity = 14, IsCancelled = false
            },
            new ActivitySlot
            {
                Id = 12, ActivityLocationId = 6, StartTime = new DateTime(2025, 10, 30, 14, 0, 0),
                EndTime = new DateTime(2025, 10, 30, 16, 0, 0), SlotCapacity = 14, IsCancelled = false
            },

            // ActivityLocationId = 7
            new ActivitySlot
            {
                Id = 13, ActivityLocationId = 7, StartTime = new DateTime(2025, 10, 31, 10, 0, 0),
                EndTime = new DateTime(2025, 10, 31, 12, 0, 0), SlotCapacity = 16, IsCancelled = false
            },
            new ActivitySlot
            {
                Id = 14, ActivityLocationId = 7, StartTime = new DateTime(2025, 10, 31, 14, 0, 0),
                EndTime = new DateTime(2025, 10, 31, 16, 0, 0), SlotCapacity = 16, IsCancelled = false
            },

            // ActivityLocationId = 8
            new ActivitySlot
            {
                Id = 15, ActivityLocationId = 8, StartTime = new DateTime(2025, 11, 1, 10, 0, 0),
                EndTime = new DateTime(2025, 11, 1, 12, 0, 0), SlotCapacity = 12, IsCancelled = false
            },
            new ActivitySlot
            {
                Id = 16, ActivityLocationId = 8, StartTime = new DateTime(2025, 11, 1, 14, 0, 0),
                EndTime = new DateTime(2025, 11, 1, 16, 0, 0), SlotCapacity = 12, IsCancelled = false
            },

            // ActivityLocationId = 9
            new ActivitySlot
            {
                Id = 17, ActivityLocationId = 9, StartTime = new DateTime(2025, 11, 2, 10, 0, 0),
                EndTime = new DateTime(2025, 11, 2, 12, 0, 0), SlotCapacity = 10, IsCancelled = false
            },
            new ActivitySlot
            {
                Id = 18, ActivityLocationId = 9, StartTime = new DateTime(2025, 11, 2, 14, 0, 0),
                EndTime = new DateTime(2025, 11, 2, 16, 0, 0), SlotCapacity = 10, IsCancelled = false
            },

            // ActivityLocationId = 10
            new ActivitySlot
            {
                Id = 19, ActivityLocationId = 10, StartTime = new DateTime(2025, 11, 3, 10, 0, 0),
                EndTime = new DateTime(2025, 11, 3, 12, 0, 0), SlotCapacity = 20, IsCancelled = false
            },
            new ActivitySlot
            {
                Id = 20, ActivityLocationId = 10, StartTime = new DateTime(2025, 11, 3, 14, 0, 0),
                EndTime = new DateTime(2025, 11, 3, 16, 0, 0), SlotCapacity = 20, IsCancelled = false
            }
        );
    }
}
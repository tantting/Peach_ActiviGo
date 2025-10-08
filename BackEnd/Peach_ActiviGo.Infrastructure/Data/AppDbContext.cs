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
            
            modelBuilder.Entity<Booking>()
                .HasOne<IdentityUser>()
                .WithMany()
                .HasForeignKey(b => b.CustomerId)
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

            modelBuilder.Entity<ActivitySlot>().HasData(slots);
        }
}
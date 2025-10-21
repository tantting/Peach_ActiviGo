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

        // --- Categories ---
            var categories = new List<Category>
            {
                new() { Id = 1, Name = "Äventyr", Description = "Spännande utomhusaktiviteter" },
                new() { Id = 2, Name = "Vatten", Description = "Aktiviteter vid havet och sjöar" },
                new() { Id = 3, Name = "Träning", Description = "Inomhus- och utomhusträning" },
                new() { Id = 4, Name = "Avkoppling", Description = "Lugna aktiviteter för kropp och själ" }
            };
            modelBuilder.Entity<Category>().HasData(categories);

            // --- Locations ---
            var locations = new List<Location>
            {
                new() { Id = 1, Name = "Varberg", Address = "Varberg centrum", Latitude = 57.1056m, Longitude = 12.2508m },
                new() { Id = 2, Name = "Falkenberg", Address = "Falkenberg centrum", Latitude = 56.9055m, Longitude = 12.4912m },
                new() { Id = 3, Name = "Halmstad", Address = "Halmstad centrum", Latitude = 56.6745m, Longitude = 12.8570m },
                new() { Id = 4, Name = "Veddige", Address = "Veddige centrum", Latitude = 57.2297m, Longitude = 12.3836m },
                new() { Id = 5, Name = "Slöinge", Address = "Slöinge centrum", Latitude = 56.8358m, Longitude = 12.7135m }
            };
            modelBuilder.Entity<Location>().HasData(locations);

            // --- Activities ---
            var activities = new List<Activity>
            {
                new() { Id = 1, Name = "Surfkurs", Description = "Lär dig surfa i havet", Price = 899, ImageUrl = "images/surf.jpg", CategoryId = 2 },
                new() { Id = 2, Name = "Yogapass", Description = "Avkopplande yoga inomhus", Price = 299, ImageUrl = "images/yoga.jpg", CategoryId = 4 },
                new() { Id = 3, Name = "Klattring", Description = "Klattra på olika nivåer", Price = 499, ImageUrl = "images/climb.jpg", CategoryId = 1 },
                new() { Id = 4, Name = "Mountainbike", Description = "Cykla i skog och mark", Price = 699, ImageUrl = "images/mtb.jpg", CategoryId = 3 },
                new() { Id = 5, Name = "Stand Up Paddle", Description = "Paddla i lugnt vatten", Price = 599, ImageUrl = "images/sup.jpg", CategoryId = 2 },
                new() { Id = 6, Name = "Spinning", Description = "Intensiv cykelträning inomhus", Price = 249, ImageUrl = "images/spinning.jpg", CategoryId = 3 },
                new() { Id = 7, Name = "Saunagus", Description = "Bastuupplevelse med dofter", Price = 350, ImageUrl = "images/sauna.jpg", CategoryId = 4 },
                new() { Id = 8, Name = "Paintball", Description = "Actionfyllt lagspel utomhus", Price = 550, ImageUrl = "images/paintball.jpg", CategoryId = 1 }
            };
            modelBuilder.Entity<Activity>().HasData(activities);

            // --- ActivityLocations ---
            var activityLocations = new List<ActivityLocation>();
            int alId = 1;
            var random = new Random();

            foreach (var activity in activities)
            {
                // välj tre slumpade orter per aktivitet
                var locs = new List<int> { 1, 2, 3, 4, 5 };
                for (int i = 0; i < 3; i++)
                {
                    int idx = random.Next(locs.Count);
                    int locId = locs[idx];
                    locs.RemoveAt(idx);

                    activityLocations.Add(new ActivityLocation
                    {
                        Id = alId++,
                        ActivityId = activity.Id,
                        LocationId = locId,
                        Capacity = random.Next(8, 20),
                        IsIndoor = (activity.Name == "Yogapass" || activity.Name == "Spinning" || activity.Name == "Saunagus"),
                        isActive = true
                    });
                }
            }
            modelBuilder.Entity<ActivityLocation>().HasData(activityLocations);

            // --- ActivitySlots ---
            var slots = new List<ActivitySlot>();
            int slotId = 1;
            var now = DateTime.Now.Date;

            foreach (var al in activityLocations)
            {
                int slotCount = random.Next(2, 5); // 2-4 slots per location
                for (int i = 0; i < slotCount; i++)
                {
                    var start = now.AddDays(random.Next(1, 21)).AddHours(9 + random.Next(0, 6));
                    slots.Add(new ActivitySlot
                    {
                        Id = slotId++,
                        ActivityLocationId = al.Id,
                        StartTime = start,
                        EndTime = start.AddHours(2),
                        SlotCapacity = al.Capacity - random.Next(0, 5),
                        IsCancelled = false
                    });
                }
            }
            modelBuilder.Entity<ActivitySlot>().HasData(slots);

    }
}
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Peach_ActiviGo.Core.Models;

namespace Peach_ActiviGo.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<ActivityLocation> ActivityLocations { get; set; }
        public DbSet<ActivitySlot> ActivitySlots { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Activity configuration
            modelBuilder.Entity<Activity>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Name).IsRequired().HasMaxLength(200);
                entity.Property(a => a.Description).HasMaxLength(1000);
                entity.Property(a => a.Environment).HasMaxLength(100);
                entity.Property(a => a.Price).HasColumnType("decimal(18,2)");
                entity.Property(a => a.ImageUrl).HasMaxLength(500);

                entity.HasOne(a => a.Category)
                    .WithMany(c => c.Activities)
                    .HasForeignKey(a => a.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Category configuration
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name).IsRequired().HasMaxLength(100);
                entity.Property(c => c.Description).HasMaxLength(500);
            });

            // Location configuration
            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(l => l.Id);
                entity.Property(l => l.Name).IsRequired().HasMaxLength(200);
                entity.Property(l => l.Address).IsRequired().HasMaxLength(300);
                entity.Property(l => l.LatLong).HasMaxLength(100);
            });

            // ActivityLocation configuration
            modelBuilder.Entity<ActivityLocation>(entity =>
            {
                entity.HasKey(al => al.Id);

                entity.HasOne(al => al.Activity)
                    .WithMany()
                    .HasForeignKey(al => al.ActivityId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(al => al.Location)
                    .WithMany(l => l.ActivityLocations)
                    .HasForeignKey(al => al.LocationId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // ActivitySlot configuration
            modelBuilder.Entity<ActivitySlot>(entity =>
            {
                entity.HasKey(s => s.Id);

                entity.HasOne(s => s.ActivityLocation)
                    .WithMany()
                    .HasForeignKey(s => s.ActivityLocationId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Booking configuration
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(b => b.Id);

                entity.HasOne(b => b.ActivityLocation)
                    .WithMany()
                    .HasForeignKey(b => b.ActivityLocationId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(b => b.ActivitySlot)
                    .WithMany()
                    .HasForeignKey(b => b.ActivitySlotId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}

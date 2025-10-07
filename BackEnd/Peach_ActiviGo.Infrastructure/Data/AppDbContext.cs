using System.Data.Entity;
using Peach_ActiviGo.Core.Models;
using Activity = System.Diagnostics.Activity;

namespace Peach_ActiviGo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
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
    }

}
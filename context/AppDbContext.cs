using Microsoft.EntityFrameworkCore;
using my_appApi.models;

namespace my_appApi.context
{
    public class AppDbContext : DbContext
    {
        internal object flights;

        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {
           
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Flight>Flights { get; set; }

        public DbSet<FlightBooking> FlightsBooking { get; set; }

        public DbSet<booking> Bookings { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Flight>().ToTable("flights");
            modelBuilder.Entity<FlightBooking>().ToTable("flightsBooking");
            modelBuilder.Entity<booking>().ToTable("bookingForm");
            modelBuilder.Entity<Admin>().ToTable("admins");
        }
    }
}

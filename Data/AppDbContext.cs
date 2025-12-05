using Microsoft.EntityFrameworkCore;
using RotasyonWebAPI.Models;

namespace RotasyonWebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Container> Containers { get; set; }
        public DbSet<ForecastData> Forecasts { get; set; }

    }
}

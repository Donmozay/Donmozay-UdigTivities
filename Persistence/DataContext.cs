using Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions options) : base (options)
        {
        }

        public DbSet<WeatherForcast> WeatherForcasts { get; set; }

        protected override void OnModelCreating (ModelBuilder builder)
        {
            builder.Entity<WeatherForcast>()
                .HasData(
                new WeatherForcast { Id = 1, Name = "Value 101"},
                new WeatherForcast { Id = 2, Name = "Value 102"},
                new WeatherForcast { Id = 3, Name = "Value 103"}
                
                );
        }
    }
}

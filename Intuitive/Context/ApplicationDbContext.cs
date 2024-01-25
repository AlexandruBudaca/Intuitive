using Intuitive.Models;
using Microsoft.EntityFrameworkCore;

namespace Intuitive.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

            //Database.EnsureCreated();
        }

        public DbSet<Airport> Airports => Set<Airport>();
        public DbSet<GeographyLevel1> GeographyLevel1 => Set<GeographyLevel1>();
        public DbSet<RouteAirports> Route => Set<RouteAirports>();
        public DbSet<AirportGroups> AirportGroups => Set<AirportGroups>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

             modelBuilder.Entity<Airport>()
                .HasOne(n => n.GeographyLevels)
                .WithMany(n => n.Airports)
                .HasForeignKey(n => n.GeographyLevel1Id)
                .HasConstraintName("FK_Aiport_GeographyLevel");
  
            modelBuilder.Entity<GeographyLevel1>()
                 .HasKey(n => n.GeographyLevel1Id);
    
            modelBuilder.Entity<RouteAirports>()
              .HasKey(i => i.RouteId);
            modelBuilder.Entity<AirportGroups>()
             .HasKey(i => i.AirportGroupID);

           

            base.OnModelCreating(modelBuilder);
        }
    }
}


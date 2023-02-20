using _05_EF_example.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_EF_example
{
    public class AirplanesDbContext : DbContext
    {
        public AirplanesDbContext()
        {
            //this.Database.EnsureDeleted();
            //this.Database.EnsureCreated();
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airplane> Airpleins { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-3HG9UVT\SQLEXPRESS;
            Initial Catalog = SuperAirplanesDbWithMigration;
            Integrated Security=True;Connect Timeout=30;
            Encrypt=False;TrustServerCertificate=False;
            ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Initialization - Seed
          modelBuilder.Entity<Airplane>().HasData(new Airplane[]
          {
                new Airplane()
                {
                    Id = 1,
                    Model = "Boeing 765",
                    MaxPassangers = 1200
                },
                 new Airplane()
                {
                    Id = 2,
                    Model = "Boeing 352",
                    MaxPassangers = 1000
                }
          });
            modelBuilder.Entity<Flight>().HasData(new Flight[]
            {
                new Flight()
                {
                    Number = 1,
                    AirplaneId = 1,
                    DepartureCity = "Kyiv",
                    ArrivalCity = "Lviv",
                    DepartureTime = new DateTime(2023,5,15),
                    ArrivalTime = new DateTime(2023,5,16)
                },
                 new Flight()
                {
                    Number = 2,
                    AirplaneId = 2,
                    DepartureCity = "Warsaw",
                    ArrivalCity = "Lviv",
                    DepartureTime = new DateTime(2023,5,15),
                    ArrivalTime = new DateTime(2023,5,16)
                }
            });
        }
    }

}

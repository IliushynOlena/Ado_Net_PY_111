using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
            Initial Catalog = SuperAirplanesDb;
            Integrated Security=True;Connect Timeout=30;
            Encrypt=False;TrustServerCertificate=False;
            ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Initialization
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
    //Collections
    //Entities
    //Airplanes
    //Flights
    //Clients
    [Table("Passengers")]
    public class Client
    {
        public int Id { get; set; }
        [Required]//not null
        [MaxLength(100)]//nvarchar(100)
        [Column("FirstName")]//set name column
        public string  Name { get; set; }
        [Required, MaxLength(50)]
        public string  Email { get; set; }
        public DateTime Birthdate { get; set; }
        public ICollection<Flight> Flights { get; set; }
    }
    public class Flight
    {
        //Primary key : Id/id/ID/ EntityName+Id
        [Key]//set primary key
        public int Number { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        [Required, MaxLength(100)]
        public string DepartureCity { get; set; }
        [Required, MaxLength(100)]
        public string ArrivalCity { get; set; }
        //Relational Type : 
        //Foreign key : RelatedEntityName +  RelatedEntityPrimaryKeyName
        public int AirplaneId { get; set; }
        public Airplane Airplane { get; set; }

        public ICollection<Client> Clients { get; set; }
    }
    public class Airplane
    {
        public int Id { get; set; }
        [Required , MaxLength(100)]
        public string Model { get; set; }
        public int MaxPassangers { get; set; }
        public ICollection< Flight> Flights { get; set; }
    }

}

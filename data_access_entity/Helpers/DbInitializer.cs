using _05_EF_example.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace _05_EF_example.Helpers
{
    internal static class DbInitializer
    {
        public static void SeedAirplanes(this ModelBuilder modelBuilder)
        {
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

        }
        public static void SeedFligths(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>().HasData(new Flight[]
          {
                new Flight()
                {
                    Number = 1,
                    AirplaneId = 1,
                    DepartureCity = "Kyiv",
                    ArrivalCity = "Lviv",
                    DepartureTime = new DateTime(2023,5,15),
                    ArrivalTime = new DateTime(2023,5,16),
                    Rating = 10
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

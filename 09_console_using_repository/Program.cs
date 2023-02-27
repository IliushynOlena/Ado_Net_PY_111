using _05_EF_example;
using _05_EF_example.Entities;
using data_access_entity.Repositories;
using System;
using System.Linq;

namespace _09_console_using_repository
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRepository<Flight> repository = new Repository<Flight>(new AirplanesDbContext());
            foreach (var f in repository.GetAll())
            {
                Console.WriteLine($"Flight {f.Number } : from {f.DepartureCity} " +
                    $"to { f.ArrivalCity}");
            }

        }
    }
}

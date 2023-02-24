using _05_EF_example.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace _05_EF_example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AirplanesDbContext context = new AirplanesDbContext();

            //var filterColl = context.Flights.Where(f => f.ArrivalCity == "Lviv").OrderBy(f => f.DepartureTime);
            var filterColl = context.Flights
                .Include(f=>f.Airplane)//Like Join to SQL
                .Include(f=>f.Clients)//Like Join to SQL
                .OrderBy(f => f.DepartureTime);
            foreach (var c in filterColl)
            {
                Console.WriteLine($"Fligth : {c.Number} : from {c.DepartureCity} to {c.ArrivalCity}" +
                    $" - aiplane {c.Airplane?.Model}" +
                    $" - with {c.Clients?.Count} passengers");
            }

            var client = context.Clients.Find(1);
            //Explicit data loading :Context.Entry(entity).Collection/Reference.Load
            context.Entry(client).Collection(c => c.Flights).Load();
            Console.WriteLine($" {client.Id}  {client.Name}  {client.Flights?.Count} flights");

            //context.Clients.Add(new Client()
            //{
            //    Name = "Volodia",
            //    Birthdate = new DateTime(2000, 10, 6),
            //    Email = "volodia@gmail.com"

            //});

            //context.SaveChanges();

            //  var c = context.Clients.Find(1);

            //  context.Entry(c).Collection(c => c.Flights).Load();

            ////  foreach (var c in res)
            //  {
            //      Console.WriteLine($"Client :{c.Id}  {c.Name}  {c.Email}  {c.Birthdate} {c.Flights?.Count()}");
            //  }

            //foreach (var c in context.Clients)
            //{
            //    Console.WriteLine($"Client :{c.Id}  {c.Name}  {c.Email}  {c.Birthdate}");
            //}

            //var obj = context.Clients.Find(1);
            //if(obj != null)
            //{
            //    context.Clients.Remove(obj);
            //    context.SaveChanges();
            //}

            //foreach (var c in context.Clients)
            //{
            //    Console.WriteLine($"Client :{c.Id}  {c.Name}  {c.Email}  {c.Birthdate}");
            //}
        }
    }
}

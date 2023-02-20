using _05_EF_example.Entities;
using System;
using System.Linq;

namespace _05_EF_example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AirplanesDbContext context = new AirplanesDbContext();

           var filterColl = context.Flights.Where(f=> f.ArrivalCity == "Lviv").OrderBy(f=>f.DepartureTime);
            foreach (var c in filterColl)
            {
                Console.WriteLine($"Fligth : {c.Number} : from {c.DepartureCity} to {c.ArrivalCity}");

            }

            context.Clients.Add(new Client()
            {
                Name = "Volodia",
                Birthdate = new DateTime(2000, 10, 6),
                Email = "volodia@gmail.com"

            });

            //context.SaveChanges();

            foreach (var c in context.Clients)
            {
                Console.WriteLine($"Client :{c.Id}  {c.Name}  {c.Email}  {c.Birthdate}");
            }

            var obj = context.Clients.Find(1);
            if(obj != null)
            {
                context.Clients.Remove(obj);
                context.SaveChanges();
            }

            foreach (var c in context.Clients)
            {
                Console.WriteLine($"Client :{c.Id}  {c.Name}  {c.Email}  {c.Birthdate}");
            }
        }
    }
}

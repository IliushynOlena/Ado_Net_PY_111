﻿using _05_EF_example.Entities;
using _05_EF_example.Helpers;
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
            modelBuilder.SeedAirplanes();
            modelBuilder.SeedFligths();

            //Fluent API configuratuins
            modelBuilder.Entity<Airplane>().Property(a => a.Model).
                HasMaxLength(100).
                IsRequired();

            modelBuilder.Entity<Client>().ToTable("Passengers");
            modelBuilder.Entity<Client>().Property(c => c.Name).
                HasMaxLength(100).
                IsRequired().
                HasColumnName("FirstName");
            modelBuilder.Entity<Client>().Property(c => c.Email).
                HasMaxLength(100).
                IsRequired();

            modelBuilder.Entity<Flight>().HasKey(f => f.Number);//set primary key
            modelBuilder.Entity<Flight>().Property(f => f.DepartureCity).
                HasMaxLength(100).
                IsRequired();
            modelBuilder.Entity<Flight>().Property(f => f.ArrivalCity).
              HasMaxLength(100).
              IsRequired();


            modelBuilder.Entity<Flight>().
                HasOne(f => f.Airplane).
                WithMany(a => a.Flights).
                HasForeignKey(f=>f.AirplaneId);

            modelBuilder.Entity<Flight>().HasMany(c => c.Clients).WithMany(c=>c.Flights);   

        }
    }

}

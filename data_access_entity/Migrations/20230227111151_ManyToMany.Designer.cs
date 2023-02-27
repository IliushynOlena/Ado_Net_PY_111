﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _05_EF_example;

namespace data_access_entity.Migrations
{
    [DbContext(typeof(AirplanesDbContext))]
    [Migration("20230227111151_ManyToMany")]
    partial class ManyToMany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("_05_EF_example.Entities.Airplane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaxPassangers")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Airpleins");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MaxPassangers = 1200,
                            Model = "Boeing 765"
                        },
                        new
                        {
                            Id = 2,
                            MaxPassangers = 1000,
                            Model = "Boeing 352"
                        });
                });

            modelBuilder.Entity("_05_EF_example.Entities.Client", b =>
                {
                    b.Property<int>("CredentialsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("FirstName");

                    b.HasKey("CredentialsId");

                    b.ToTable("Passengers");

                    b.HasData(
                        new
                        {
                            CredentialsId = 1,
                            Birthdate = new DateTime(2003, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "victor@gmail.com",
                            Name = "Victor"
                        },
                        new
                        {
                            CredentialsId = 2,
                            Birthdate = new DateTime(2000, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "olga@gmail.com",
                            Name = "Olga"
                        });
                });

            modelBuilder.Entity("_05_EF_example.Entities.Flight", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AirplaneId")
                        .HasColumnType("int");

                    b.Property<string>("ArrivalCity")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartureCity")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Number");

                    b.HasIndex("AirplaneId");

                    b.ToTable("Flights");

                    b.HasData(
                        new
                        {
                            Number = 1,
                            AirplaneId = 1,
                            ArrivalCity = "Lviv",
                            ArrivalTime = new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartureCity = "Kyiv",
                            DepartureTime = new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Rating = 10
                        },
                        new
                        {
                            Number = 2,
                            AirplaneId = 2,
                            ArrivalCity = "Lviv",
                            ArrivalTime = new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartureCity = "Warsaw",
                            DepartureTime = new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Rating = 0
                        });
                });

            modelBuilder.Entity("data_access_entity.Entities.ClientFlight", b =>
                {
                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("FlightId")
                        .HasColumnType("int");

                    b.HasKey("ClientId", "FlightId");

                    b.HasIndex("FlightId");

                    b.ToTable("ClientFlight");
                });

            modelBuilder.Entity("data_access_entity.Entities.Credentials", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique()
                        .HasFilter("[ClientId] IS NOT NULL");

                    b.ToTable("Credentials");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Login = "user1",
                            Password = "1111"
                        },
                        new
                        {
                            Id = 2,
                            Login = "user2",
                            Password = "2222"
                        });
                });

            modelBuilder.Entity("_05_EF_example.Entities.Flight", b =>
                {
                    b.HasOne("_05_EF_example.Entities.Airplane", "Airplane")
                        .WithMany("Flights")
                        .HasForeignKey("AirplaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Airplane");
                });

            modelBuilder.Entity("data_access_entity.Entities.ClientFlight", b =>
                {
                    b.HasOne("_05_EF_example.Entities.Client", "Client")
                        .WithMany("ClientFlight")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_05_EF_example.Entities.Flight", "Flight")
                        .WithMany("ClientFlight")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Flight");
                });

            modelBuilder.Entity("data_access_entity.Entities.Credentials", b =>
                {
                    b.HasOne("_05_EF_example.Entities.Client", "Client")
                        .WithOne("Credentials")
                        .HasForeignKey("data_access_entity.Entities.Credentials", "ClientId");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("_05_EF_example.Entities.Airplane", b =>
                {
                    b.Navigation("Flights");
                });

            modelBuilder.Entity("_05_EF_example.Entities.Client", b =>
                {
                    b.Navigation("ClientFlight");

                    b.Navigation("Credentials");
                });

            modelBuilder.Entity("_05_EF_example.Entities.Flight", b =>
                {
                    b.Navigation("ClientFlight");
                });
#pragma warning restore 612, 618
        }
    }
}

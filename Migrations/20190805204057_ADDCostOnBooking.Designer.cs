﻿// <auto-generated />
using System;
using Ger_Garage.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ger_Garage.Migrations
{
    [DbContext(typeof(GerGarageDbContext))]
    [Migration("20190805204057_ADDCostOnBooking")]
    partial class ADDCostOnBooking
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ger_Garage.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comments")
                        .HasMaxLength(255);

                    b.Property<float?>("Cost");

                    b.Property<int?>("CustomerId");

                    b.Property<DateTime>("DateTime");

                    b.Property<int>("Engine");

                    b.Property<int>("StatusBookingId");

                    b.Property<int>("TypeOfBookingId");

                    b.Property<int>("VehicleId");

                    b.Property<string>("VehicleLicense")
                        .HasMaxLength(25);

                    b.Property<int?>("VehicleTypeId");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StatusBookingId");

                    b.HasIndex("TypeOfBookingId");

                    b.HasIndex("VehicleId");

                    b.HasIndex("VehicleTypeId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Ger_Garage.Models.Mechanic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Mobile");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Mechanics");
                });

            modelBuilder.Entity("Ger_Garage.Models.MechanicBooking", b =>
                {
                    b.Property<int>("BookingId");

                    b.Property<int>("MechanicId");

                    b.Property<int>("Id");

                    b.HasKey("BookingId", "MechanicId");

                    b.HasIndex("MechanicId");

                    b.ToTable("MechanicBookings");
                });

            modelBuilder.Entity("Ger_Garage.Models.StatusBooking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Status")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("StatusBookings");
                });

            modelBuilder.Entity("Ger_Garage.Models.TypeOfBooking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cost");

                    b.Property<string>("Type")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("TypeOfBookings");
                });

            modelBuilder.Entity("Ger_Garage.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<int>("Level");

                    b.Property<string>("MobilePhone")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Ger_Garage.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Make");

                    b.Property<string>("Model");

                    b.Property<int>("VehicleStyle");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Ger_Garage.Models.VehiclePart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cost");

                    b.Property<string>("Part")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("VehicleParts");
                });

            modelBuilder.Entity("Ger_Garage.Models.VehiclePartBooking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookingId");

                    b.Property<int>("VehiclePartId");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.HasIndex("VehiclePartId");

                    b.ToTable("VehiclePartBookings");
                });

            modelBuilder.Entity("Ger_Garage.Models.VehicleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Model")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("VehicleTypes");
                });

            modelBuilder.Entity("Ger_Garage.Models.Booking", b =>
                {
                    b.HasOne("Ger_Garage.Models.User", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("Ger_Garage.Models.StatusBooking", "StatusBooking")
                        .WithMany("Bookings")
                        .HasForeignKey("StatusBookingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Ger_Garage.Models.TypeOfBooking", "TypeOfBooking")
                        .WithMany("Bookings")
                        .HasForeignKey("TypeOfBookingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Ger_Garage.Models.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Ger_Garage.Models.VehicleType")
                        .WithMany("Bookings")
                        .HasForeignKey("VehicleTypeId");
                });

            modelBuilder.Entity("Ger_Garage.Models.MechanicBooking", b =>
                {
                    b.HasOne("Ger_Garage.Models.Booking", "Booking")
                        .WithMany("Mechanics")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Ger_Garage.Models.Mechanic", "Mechanic")
                        .WithMany("Bookings")
                        .HasForeignKey("MechanicId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Ger_Garage.Models.VehiclePartBooking", b =>
                {
                    b.HasOne("Ger_Garage.Models.Booking", "Booking")
                        .WithMany("VehicleParts")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Ger_Garage.Models.VehiclePart", "VehiclePart")
                        .WithMany()
                        .HasForeignKey("VehiclePartId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
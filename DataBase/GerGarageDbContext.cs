using Ger_Garage.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ger_Garage.DataBase
{
    public class GerGarageDbContext : DbContext

    {
        public GerGarageDbContext(DbContextOptions<GerGarageDbContext> options) : base(options)
        {
			
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
        public DbSet<MechanicBooking> MechanicBookings { get; set; }
        public DbSet<StatusBooking> StatusBookings { get; set; }
        //public DbSet<StatusBookingBooking> StatusBookingBookings { get; set; }
        public DbSet<TypeOfBooking> TypeOfBookings { get; set; }
        //public DbSet<TypeOfBookingBooking> TypeOfBookingBookings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<VehiclePart> VehicleParts { get; set; }
        public DbSet<VehiclePartBooking> VehiclePartBookings { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
		public DbSet<Vehicle> Vehicles { get; set; }
		//public DbSet<VehicleTypeBooking> VehicleTypeBookings { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<MechanicBooking>()
				.HasKey(bc => new { bc.BookingId, bc.MechanicId });
			modelBuilder.Entity<MechanicBooking>()
				.HasOne(bc => bc.Booking)
				.WithMany(b => b.Mechanics)
				.HasForeignKey(bc => bc.BookingId);
			modelBuilder.Entity<MechanicBooking>()
				.HasOne(bc => bc.Mechanic)
				.WithMany(c => c.Bookings)
				.HasForeignKey(bc => bc.MechanicId);
		}

		/*  protected override void OnModelCreating(ModelBuilder modelBuilder)
          {
              base.OnModelCreating(ModelBuilder)

              ModelBuilder.Entity<TypeOfBooking>()
                  .HasData(
                  new TypeOfBooking()
                  {
                      Id = 1,
                      Type = "Major Repair",
                      Cost = "200,00"

                  }

                  );*/



	}

}

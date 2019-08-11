using Ger_Garage.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ger_Garage.Models
{
	public class Booking
	{

		public int Id { get; set; }
		[Display(Name = "Customer Name")]
		public User Customer { get; set; }

		//public int VehicleTypeId { get; set; }
		//public VehicleType VehicleType { get; set; }
		[Display(Name = "Type of Booking")]
		public TypeOfBooking TypeOfBooking { get; set; }
		public int TypeOfBookingId { get; set; }
		[Display(Name = "Status")]
		public StatusBooking StatusBooking { get; set; }
		public int StatusBookingId { get; set; }
		//public ICollection<VehicleTypeBooking> Vehicles { get; set; }
		[Display(Name = "Vehicle License")]
		[StringLength(25, MinimumLength = 3)]
		public string VehicleLicense { get; set; }
		public Vehicle Vehicle { get; set; }
		public int VehicleId { get; set; }
		[NotMapped]
		[DataType(DataType.Currency)]
		[Display(Name = "Cost of Service")]
		public float Cost { get; set; }
		public Engine Engine { get; set; }
		//[StringLength(25, MinimumLength = 3)]
		//public string VehicleEngine { get; set; }

		//public ICollection<TypeOfBookingBooking> TypeOfBookings { get; set; }
		[Display(Name = "Describe the damage:")]
		[StringLength(255, MinimumLength = 3)]
		public string Comments { get; set; }
		[Display(Name = "Select Date")]
		[DataType(DataType.DateTime)]
		public DateTime DateTime { get; set; }
		public ICollection<VehiclePartBooking> VehicleParts { get; set; }
		public ICollection<MechanicBooking> Mechanics { get; set; }
		[NotMapped]
		public ICollection<int> MechanicsIds { get; set; }
		[NotMapped]
		public ICollection<int> VehiclePartsIds { get; set; }
		[NotMapped]
		public DateTime Filter { get; set; }



	}
}

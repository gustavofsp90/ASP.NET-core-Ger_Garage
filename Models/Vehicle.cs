using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Ger_Garage.Models.Enum;

namespace Ger_Garage.Models
{
	public class Vehicle
	{
		public int Id { get; set; }
        [Display(Name = "VehicleBrand")]
        public string Make { get; set; }
        [Display(Name = "Vehicle ")]
        public string Model { get; set; }
		public VehicleStyle VehicleStyle { get; set; }
	}
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ger_Garage.Models
{
    public class VehicleType
    {

        public int Id { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Model { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
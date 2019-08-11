using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ger_Garage.Models
{
    public class StatusBooking
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string Status { get; set; }
        public ICollection<Booking> Bookings { get; set; }
}
}


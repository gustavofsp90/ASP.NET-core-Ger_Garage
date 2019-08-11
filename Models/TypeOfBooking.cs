using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ger_Garage.Models
{
    public class TypeOfBooking
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 3)]
        public string Type { get; set; }

        [DataType(DataType.Currency)]
        public string Cost { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}


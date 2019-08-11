using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ger_Garage.Models
{
    public class Mechanic
    {
        
        public int Id { get; set; }
        public string Name { get; set; }

        public int Mobile { get; set; }
        public ICollection<MechanicBooking> Bookings  { get; set; }
    }
}

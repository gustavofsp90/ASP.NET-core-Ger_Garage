namespace Ger_Garage.Models
{
    public class MechanicBooking
    {

        public int Id { get; set; }
        public int MechanicId { get; set; }
        public Mechanic Mechanic { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
    }

  
}
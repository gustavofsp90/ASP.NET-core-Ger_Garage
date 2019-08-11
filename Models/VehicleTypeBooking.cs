namespace Ger_Garage.Models
{
    public class VehicleTypeBooking
    {
        public int Id { get; set; }
        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
    }
}


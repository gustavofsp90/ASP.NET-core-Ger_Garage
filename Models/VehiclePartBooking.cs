namespace Ger_Garage.Models
{
    public class VehiclePartBooking
    {

        public int Id { get; set; }
        public int VehiclePartId { get; set; }
        public VehiclePart VehiclePart { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }

    }
}

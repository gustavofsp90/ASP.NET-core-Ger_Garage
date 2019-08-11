namespace Ger_Garage.Models
{
    public class StatusBookingBooking
    {

        public int Id { get; set; }
        public int  StatusBookingId { get; set; }
        public StatusBooking StatusBooking { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
    }
}



namespace Ger_Garage.Models
{
    public class TypeOfBookingBooking
    {

        public int Id { get; set; }
        public int TypeOfBookingId { get; set; }
        public TypeOfBooking TypeOfBooking { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }

    }
}



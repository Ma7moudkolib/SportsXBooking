namespace Domain.Exceptions.Booking
{
    public class BookingNotFoundException : NotFoundException
    {
        public BookingNotFoundException(string message) : base(message)
        {
        }
    }
}

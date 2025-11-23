using Application.DataTransferObjects.Booking;

namespace Application.ServiceInterfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<GetBookingDto>> GetAllBookingAsync(bool trackChanges);
        Task<GetBookingDto> GetBookingByIdAsync(int id, bool trackChanges);
        Task<GetBookingDto> CreateBookingAsync(CreateBooking createBooking);
        Task CancelBookingAsync(int id,bool trackChanges);
    }
}

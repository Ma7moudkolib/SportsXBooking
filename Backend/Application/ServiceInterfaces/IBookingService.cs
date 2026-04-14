using Application.DataTransferObjects;
using Application.DataTransferObjects.Booking;

namespace Application.ServiceInterfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<GetBookingDto>> GetAllBookingAsync(bool trackChanges);
        Task<GetBookingDto> GetBookingByIdAsync(int id, bool trackChanges);
        Task<ServiceResponse> CreateBookingAsync(CreateBooking createBooking);
        Task<ServiceResponse> CancelBookingAsync(int id,bool trackChanges);
    }
}

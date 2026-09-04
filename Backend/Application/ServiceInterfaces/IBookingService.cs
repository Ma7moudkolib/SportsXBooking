using Application.DataTransferObjects;
using Application.DataTransferObjects.Booking;
using Application.DataTransferObjects.Playground;

namespace Application.ServiceInterfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<GetBookingDto>> GetAllBookingAsync(bool trackChanges);
        Task<GetBookingDto> GetBookingByIdAsync(int id, bool trackChanges);
        Task<ServiceResponse> CreateBookingAsync(CreateBooking createBooking);
        Task<ServiceResponse> CancelBookingAsync(int id,bool trackChanges);

        Task<IEnumerable<GetOwnerBookingDto>> GetOwnerBookingsAsync(int ownerId, OwnerBookingQueryParams filters, bool trackChanges);
        Task<GetOwnerBookingDto?> GetOwnerBookingDetailsAsync(int ownerId, int bookingId, bool trackChanges);
        Task<ServiceResponse> ConfirmBookingAsync(int ownerId, int bookingId);
        Task<OwnerPlaygroundAnalyticsDto> GetOwnerAnalyticsAsync(int ownerId);
    }
}

using Domain.Entities;

namespace Domain.RepositoryInterfaces
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetBookingsByUserAsync(int userId, bool trackChanges);
        Task<IEnumerable<Booking>> GetBookingsByPlaygroundAsync(int playgroundId, bool trackChanges);
        Task<bool> IsTimeSlotAvailable(int playgroundId, DateTime date, TimeSpan start, TimeSpan end);
        Task<IEnumerable<Booking>> GetAllBookingAsync(bool trackChanges);
        Task<Booking> GetBookingByIdAsync(int bookingId, bool trackChanges);
        void CreateBooking(Booking booking);
        void DeleteBooking(Booking booking);
        void UpdateBooking(Booking booking);
    }
}

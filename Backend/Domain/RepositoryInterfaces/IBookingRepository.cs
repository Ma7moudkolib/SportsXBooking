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

        Task<IEnumerable<Booking>> GetBookingsByOwnerAsync(int ownerId, bool trackChanges);
        Task<Booking?> GetBookingByOwnerAsync(int ownerId, int bookingId, bool trackChanges);
        Task<int> GetBookingsCountByOwnerAsync(int ownerId, string? status);
        Task<Dictionary<string, int>> GetBookingStatusCountsByOwnerAsync(int ownerId);
        Task<Dictionary<string, int>> GetBookingsByMonthAsync(int ownerId);
        Task<decimal> GetRevenueByOwnerAsync(int ownerId, bool confirmedOnly);
        Task<IEnumerable<object>> GetPlaygroundStatsByOwnerAsync(int ownerId);
    }
}

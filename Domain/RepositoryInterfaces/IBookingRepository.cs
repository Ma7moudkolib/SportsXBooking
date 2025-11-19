using Domain.Entities;

namespace Domain.RepositoryInterfaces
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetBookingsByUserAsync(int userId, bool trackChanges);
        Task<IEnumerable<Booking>> GetBookingsByPlaygroundAsync(int playgroundId, bool trackChanges);
        //Task<bool> IsTimeSlotAvailable(int playgroundId, DateTime date, TimeSpan start, TimeSpan end);
    }
}

using Domain.Entities;
using Domain.RepositoryInterfaces;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BookingRepository : RepositoryBase<Booking>, IBookingRepository
    {
        public BookingRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {
            
        }
        public async Task<IEnumerable<Booking>> GetAllBookingAsync(bool trackChanges) => await
            FindAll(trackChanges).OrderBy(b=>b.StartTime).ToListAsync();
        public async Task<Booking> GetBookingByIdAsync(int bookingId, bool trackChanges) =>
           await FindByCondition(b => b.BookingId == bookingId, trackChanges).SingleOrDefaultAsync()!;

        public async Task<IEnumerable<Booking>> GetBookingsByPlaygroundAsync(int playgroundId, bool trackChanges) =>
            await FindByCondition(b => b.PlaygroundId == playgroundId, trackChanges).ToListAsync();

        public async Task<IEnumerable<Booking>> GetBookingsByUserAsync(int userId, bool trackChanges)=>
           await FindByCondition(b => b.PlayerId == userId, trackChanges).ToListAsync();
        public void CreateBooking(Booking booking) => Create(booking);
        public void DeleteBooking(Booking booking) => Delete(booking);
        public void UpdateBooking(Booking booking) => Update(booking);

        public async Task<bool> IsTimeSlotAvailable(int playgroundId, DateTime date, TimeSpan start, TimeSpan end)
        {
            var booking = FindByCondition(b => b.PlaygroundId == playgroundId && b.BookingDate == date &&
           ((b.EndTime == end || b.StartTime == start)), false);
            return await booking.AnyAsync() ? false : true;

        }
    }
}

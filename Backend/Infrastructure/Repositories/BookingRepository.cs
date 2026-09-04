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
            var hasOverlap = await FindByCondition(
                b => b.PlaygroundId == playgroundId
                  && b.BookingDate == date
                  && b.Status != "Cancelled"
                  && start < b.EndTime
                  && end > b.StartTime,
                trackChanges: false).AnyAsync();
            return !hasOverlap;
        }

        public async Task<IEnumerable<Booking>> GetBookingsByOwnerAsync(int ownerId, bool trackChanges)
        {
            var query = RepositoryContext.Bookings
                .Include(b => b.Playground)
                .Include(b => b.Player)
                .Where(b => b.Playground.OwnerId == ownerId)
                .OrderByDescending(b => b.CreatedAt);

            return trackChanges
                ? await query.ToListAsync()
                : await query.AsNoTracking().ToListAsync();
        }

        public async Task<Booking?> GetBookingByOwnerAsync(int ownerId, int bookingId, bool trackChanges)
        {
            var query = RepositoryContext.Bookings
                .Include(b => b.Playground)
                .Include(b => b.Player)
                .Where(b => b.BookingId == bookingId && b.Playground.OwnerId == ownerId);

            return trackChanges
                ? await query.SingleOrDefaultAsync()
                : await query.AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<int> GetBookingsCountByOwnerAsync(int ownerId, string? status)
        {
            var query = RepositoryContext.Bookings
                .Where(b => b.Playground.OwnerId == ownerId);

            if (!string.IsNullOrEmpty(status))
                query = query.Where(b => b.Status == status);

            return await query.CountAsync();
        }

        public async Task<Dictionary<string, int>> GetBookingStatusCountsByOwnerAsync(int ownerId)
        {
            return await RepositoryContext.Bookings
                .Where(b => b.Playground.OwnerId == ownerId)
                .GroupBy(b => b.Status)
                .ToDictionaryAsync(g => g.Key, g => g.Count());
        }

        public async Task<Dictionary<string, int>> GetBookingsByMonthAsync(int ownerId)
        {
            var bookings = await RepositoryContext.Bookings
                .Where(b => b.Playground.OwnerId == ownerId)
                .Select(b => b.CreatedAt)
                .ToListAsync();

            return bookings
                .GroupBy(d => d.ToString("yyyy-MM"))
                .OrderBy(g => g.Key)
                .ToDictionary(g => g.Key!, g => g.Count());
        }

        public async Task<decimal> GetRevenueByOwnerAsync(int ownerId, bool confirmedOnly)
        {
            var query = RepositoryContext.Bookings
                .Where(b => b.Playground.OwnerId == ownerId);

            if (confirmedOnly)
                query = query.Where(b => b.Status == "Confirmed");

            return await query.SumAsync(b => b.TotalPrice);
        }

        public async Task<IEnumerable<object>> GetPlaygroundStatsByOwnerAsync(int ownerId)
        {
            var bookings = await RepositoryContext.Bookings
                .Include(b => b.Playground)
                .Where(b => b.Playground.OwnerId == ownerId)
                .Select(b => new
                {
                    b.PlaygroundId,
                    b.Playground.Name,
                    b.Playground.SportType,
                    b.Status,
                    b.TotalPrice
                })
                .ToListAsync();

            var result = bookings
                .GroupBy(b => new { b.PlaygroundId, b.Name, b.SportType })
                .Select(g => new
                {
                    g.Key.PlaygroundId,
                    PlaygroundName = g.Key.Name,
                    g.Key.SportType,
                    TotalBookings = g.Count(),
                    ConfirmedBookings = g.Count(b => b.Status == "Confirmed"),
                    CancelledBookings = g.Count(b => b.Status == "Cancelled"),
                    Revenue = g.Sum(b => b.TotalPrice)
                })
                .ToList();

            return result;
        }
    }
}

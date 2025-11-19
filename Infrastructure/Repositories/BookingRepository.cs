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
        public async Task<IEnumerable<Booking>> GetBookingsByPlaygroundAsync(int playgroundId, bool trackChanges) =>
            await FindByCondition(b => b.PlaygroundId == playgroundId, trackChanges).ToListAsync();

        public async Task<IEnumerable<Booking>> GetBookingsByUserAsync(int userId, bool trackChanges)=>
           await FindByCondition(b => b.PlayerId == userId, trackChanges).ToListAsync();
    }
}

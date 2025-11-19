using Domain.Entities;
using Domain.RepositoryInterfaces;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ReviewRepository : RepositoryBase<Review>, IReviewRepository
    {
        public ReviewRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task<IEnumerable<Review>> GetReviewsForPlaygroundAsync(int playgroundId, bool trackChanges) =>
           await FindByCondition(r => r.PlaygroundId == playgroundId, trackChanges).ToListAsync();
       
    }
}

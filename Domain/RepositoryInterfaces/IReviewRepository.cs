using Domain.Entities;

namespace Domain.RepositoryInterfaces
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetReviewsForPlaygroundAsync(int playgroundId, bool trackChanges);
        
    }
}

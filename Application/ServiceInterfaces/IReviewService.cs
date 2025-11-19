using Application.DataTransferObjects.Review;

namespace Application.ServiceInterfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewDto>> GetForPlaygroundAsync(int playgroundId, bool trackChanges);
        Task<ReviewDto> AddReviewAsync(ReviewDto review);
    }
}

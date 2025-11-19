using Application.DataTransferObjects.Review;
using Application.ServiceInterfaces;
using AutoMapper;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public ReviewService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<ReviewDto> AddReviewAsync(ReviewDto review)
        {
            var reviewEntity = _mapper.Map<Domain.Entities.Review>(review);
            _repositoryManager.Review.AddReviewForPlayground(reviewEntity);
            await _repositoryManager.SaveAsync();
            var reviewDto = _mapper.Map<ReviewDto>(reviewEntity);
            return reviewDto;
        }

        public async Task<IEnumerable<ReviewDto>> GetForPlaygroundAsync(int playgroundId, bool trackChanges)
        {
            var reviews =await _repositoryManager.Review
                .GetReviewsForPlaygroundAsync(playgroundId, trackChanges);
      
            var reviewsDto = _mapper.Map<IEnumerable<ReviewDto>>(reviews);
            return reviewsDto;
        }
    }
}

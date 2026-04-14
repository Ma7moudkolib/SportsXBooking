using Application.DataTransferObjects;
using Application.DataTransferObjects.Review;
using Application.Services;
using AutoFixture;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories;
using Moq;
using Xunit;

namespace Application.Tests.Services
{
    public class ReviewServiceTests
    {
        private readonly Mock<IRepositoryManager> _repositoryManagerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly IFixture _fixture;
        private readonly ReviewService _sut;

        public ReviewServiceTests()
        {
            _repositoryManagerMock = new Mock<IRepositoryManager>();
            _mapperMock = new Mock<IMapper>();
            _fixture = new Fixture();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());          
            
            _sut = new ReviewService(
                _repositoryManagerMock.Object,
                _mapperMock.Object);
        }

        #region AddReviewAsync Tests

        [Fact]
        public async Task AddReviewAsync_WithValidReview_ShouldAddReview()
        {
            // Arrange
            var reviewDto = _fixture.Create<ReviewDto>();
            var reviewEntity = _fixture.Create<Review>();

            _mapperMock.Setup(m => m.Map<Review>(reviewDto))
                .Returns(reviewEntity);

            _repositoryManagerMock.Setup(r => r.SaveAsync())
                .Returns(Task.CompletedTask);

            // Act
            var result = await _sut.AddReviewAsync(reviewDto);

            // Assert
            Assert.True(result.Success);
            Assert.Equal("Review added successfully", result.Message);
            _repositoryManagerMock.Verify(r => r.Review.AddReviewForPlayground(reviewEntity), Times.Once);
            _repositoryManagerMock.Verify(r => r.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task AddReviewAsync_WithMultipleReviews_ShouldAddAllReviews()
        {
            // Arrange
            var reviewDtos = _fixture.CreateMany<ReviewDto>(3).ToList();
            var reviewEntities = _fixture.CreateMany<Review>(3).ToList();

            for (int i = 0; i < reviewDtos.Count; i++)
            {
                _mapperMock.Setup(m => m.Map<Review>(reviewDtos[i]))
                    .Returns(reviewEntities[i]);
            }

            _repositoryManagerMock.Setup(r => r.SaveAsync())
                .Returns(Task.CompletedTask);

            // Act
            var results = new List<ServiceResponse>();
            foreach (var reviewDto in reviewDtos)
            {
                var result = await _sut.AddReviewAsync(reviewDto);
                results.Add(result);
            }

            // Assert
            Assert.Equal(3, results.Count);
            Assert.All(results, r => Assert.True(r.Success));
            _repositoryManagerMock.Verify(r => r.Review.AddReviewForPlayground(It.IsAny<Review>()), Times.Exactly(3));
            _repositoryManagerMock.Verify(r => r.SaveAsync(), Times.Exactly(3));
        }

        #endregion

        #region GetForPlaygroundAsync Tests

        [Fact]
        public async Task GetForPlaygroundAsync_WithValidPlaygroundId_ShouldReturnReviews()
        {
            // Arrange
            int playgroundId = 1;
            var reviews = _fixture.CreateMany<Review>(3).ToList();
            var reviewDtos = _fixture.CreateMany<ReviewDto>(3);

            _repositoryManagerMock.Setup(r => r.Review.GetReviewsForPlaygroundAsync(playgroundId, false))
                .ReturnsAsync(reviews);

            _mapperMock.Setup(m => m.Map<IEnumerable<ReviewDto>>(reviews))
                .Returns(reviewDtos);

            // Act
            var result = await _sut.GetForPlaygroundAsync(playgroundId, false);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public async Task GetForPlaygroundAsync_WithNoReviews_ShouldReturnEmptyList()
        {
            // Arrange
            int playgroundId = 1;
            var reviews = new List<Review>();

            _repositoryManagerMock.Setup(r => r.Review.GetReviewsForPlaygroundAsync(playgroundId, false))
                .ReturnsAsync(reviews);

            _mapperMock.Setup(m => m.Map<IEnumerable<ReviewDto>>(reviews))
                .Returns(new List<ReviewDto>());

            // Act
            var result = await _sut.GetForPlaygroundAsync(playgroundId, false);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetForPlaygroundAsync_WithTrackChangesTrue_ShouldUseTrackChanges()
        {
            // Arrange
            int playgroundId = 1;
            var reviews = _fixture.CreateMany<Review>(2).ToList();
            var reviewDtos = _fixture.CreateMany<ReviewDto>(2);

            _repositoryManagerMock.Setup(r => r.Review.GetReviewsForPlaygroundAsync(playgroundId, true))
                .ReturnsAsync(reviews);

            _mapperMock.Setup(m => m.Map<IEnumerable<ReviewDto>>(reviews))
                .Returns(reviewDtos);

            // Act
            var result = await _sut.GetForPlaygroundAsync(playgroundId, true);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            _repositoryManagerMock.Verify(r => r.Review.GetReviewsForPlaygroundAsync(playgroundId, true), Times.Once);
        }

        [Fact]
        public async Task GetForPlaygroundAsync_ShouldMapReviewsCorrectly()
        {
            // Arrange
            int playgroundId = 1;
            var reviews = new List<Review>
            {
                new Review {  PlaygroundId = playgroundId, Rating = 5, Comment = "Great place!" },
                new Review {  PlaygroundId = playgroundId, Rating = 4, Comment = "Good quality" }
            };

            var expectedDtos = new List<ReviewDto>
            {
                new ReviewDto { Rating = 5, Comment = "Great place!" },
                new ReviewDto { Rating = 4, Comment = "Good quality" }
            };

            _repositoryManagerMock.Setup(r => r.Review.GetReviewsForPlaygroundAsync(playgroundId, false))
                .ReturnsAsync(reviews);

            _mapperMock.Setup(m => m.Map<IEnumerable<ReviewDto>>(reviews))
                .Returns(expectedDtos);

            // Act
            var result = await _sut.GetForPlaygroundAsync(playgroundId, false);

            // Assert
            Assert.Equal(2, result.Count());
            _mapperMock.Verify(m => m.Map<IEnumerable<ReviewDto>>(reviews), Times.Once);
        }

        #endregion
    }
}
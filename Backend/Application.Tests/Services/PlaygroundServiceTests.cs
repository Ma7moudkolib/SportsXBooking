using Application.DataTransferObjects.Playground;
using Application.Services;
using AutoFixture;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.RepositoryInterfaces;
using Infrastructure.Repositories;
using Moq;
using Xunit;

namespace Application.Tests.Services
{
    public class PlaygroundServiceTests
    {
        private readonly Mock<IRepositoryManager> _repositoryManagerMock;
        private readonly Mock<IUserRepository> _userRepositoryMock;        // ← NEW
        private readonly Mock<IPlaygroundRepository> _playgroundRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly IFixture _fixture;
        private readonly PlaygroundService _sut;

        public PlaygroundServiceTests()
        {
            _repositoryManagerMock = new Mock<IRepositoryManager>();
            _userRepositoryMock = new Mock<IUserRepository>();            // ← NEW
            _playgroundRepositoryMock = new Mock<IPlaygroundRepository>();
            _mapperMock = new Mock<IMapper>();
            _fixture = new Fixture();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _repositoryManagerMock.Setup(r => r.User)
            .Returns(_userRepositoryMock.Object);
            _repositoryManagerMock.Setup(r => r.Playground)
            .Returns(_playgroundRepositoryMock.Object);
            _sut = new PlaygroundService(
                _repositoryManagerMock.Object,
                _mapperMock.Object);
        }

        // #region CreatePlaygroundAsync Tests

        // [Fact]
        // public async Task CreatePlaygroundAsync_WithValidData_ShouldCreatePlayground()
        // {
        //     // Arrange
        //     var createPlaygroundDto = _fixture.Create<CreatePlaygroundDto>();
        //     var playgroundEntity = _fixture.Create<Playground>();

        //     _mapperMock.Setup(m => m.Map<Playground>(createPlaygroundDto))
        //         .Returns(playgroundEntity);

        //     _repositoryManagerMock.Setup(r => r.SaveAsync())
        //         .Returns(Task.CompletedTask);

        //     // Act
        //     var result = await _sut.CreatePlaygroundAsync(createPlaygroundDto);

        //     // Assert
        //     Assert.True(result.Success);
        //     Assert.Equal("Playground created successfully", result.Message);
        //     _repositoryManagerMock.Verify(r => r.Playground.CreatePlayground(playgroundEntity), Times.Once);
        //     _repositoryManagerMock.Verify(r => r.SaveAsync(), Times.Once);
        // }

        // #endregion

        #region CreatePlaygroundAsync Tests
 
        [Fact]
        public async Task CreatePlaygroundAsync_WithValidData_ShouldCreatePlayground()
        {
            // Arrange
            var createPlaygroundDto = new CreatePlaygroundDto
            {
                Name = "Central Park Court",
                Location = "Downtown",
                SportType = "Basketball",
                OwnerId = 1
            };
 
            var playgroundEntity = new Playground
            {
                PlaygroundId = 1,
                Name = createPlaygroundDto.Name,
                Location = createPlaygroundDto.Location,
                SportType = createPlaygroundDto.SportType,
                OwnerId = createPlaygroundDto.OwnerId
            };
 
            _mapperMock.Setup(m => m.Map<Playground>(createPlaygroundDto))
                .Returns(playgroundEntity);
            _repositoryManagerMock.Setup(r => r.SaveAsync())
                .Returns(Task.CompletedTask);
 
            // Act
            var result = await _sut.CreatePlaygroundAsync(createPlaygroundDto);
 
            // Assert
            Assert.True(result.Success);
            Assert.Equal("Playground created successfully", result.Message);
            _repositoryManagerMock.Verify(r => r.Playground.CreatePlayground(playgroundEntity), Times.Once);
            _repositoryManagerMock.Verify(r => r.SaveAsync(), Times.Once);
        }
 
        #endregion
        #region DeletePlaygroundAsync Tests

        [Fact]
        public async Task DeletePlaygroundAsync_WithValidId_ShouldDeletePlayground()
        {
            // Arrange
            int playgroundId = 1;
            var playground = _fixture.Create<Playground>();

            _repositoryManagerMock.Setup(r => r.Playground.GetPlaygroundByIdAsync(playgroundId, true))
                .ReturnsAsync(playground);

            _repositoryManagerMock.Setup(r => r.SaveAsync())
                .Returns(Task.CompletedTask);

            // Act
            var result = await _sut.DeletePlaygroundAsync(playgroundId, true);

            // Assert
            Assert.True(result.Success);
            Assert.Equal("Playground deleted successfully", result.Message);
            _repositoryManagerMock.Verify(r => r.Playground.DeletePlayground(playground), Times.Once);
            _repositoryManagerMock.Verify(r => r.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task DeletePlaygroundAsync_WithInvalidId_ShouldReturnFailure()
        {
            // Arrange
            int playgroundId = 999;

            _repositoryManagerMock.Setup(r => r.Playground.GetPlaygroundByIdAsync(playgroundId, true))
                .ReturnsAsync((Playground)null);

            // Act
            var result = await _sut.DeletePlaygroundAsync(playgroundId, true);

            // Assert
            Assert.False(result.Success);
            Assert.Equal($"Playground with id {playgroundId} not found.", result.Message);
            _repositoryManagerMock.Verify(r => r.Playground.DeletePlayground(It.IsAny<Playground>()), Times.Never);
        }

        #endregion

        #region GetAllPlaygroundAsync Tests

        [Fact]
        public async Task GetAllPlaygroundAsync_ShouldReturnAllPlaygrounds()
        {
            // Arrange
            var playgrounds = _fixture.CreateMany<Playground>(5).ToList();
            var playgroundDtos = _fixture.CreateMany<GetPlaygroundDto>(5);

            _repositoryManagerMock.Setup(r => r.Playground.GetAllPlaygroundAsync(false))
                .ReturnsAsync(playgrounds);

            _mapperMock.Setup(m => m.Map<IEnumerable<GetPlaygroundDto>>(playgrounds))
                .Returns(playgroundDtos);

            // Act
            var result = await _sut.GetAllPlaygroundAsync(false);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(5, result.Count());
        }

        [Fact]
        public async Task GetAllPlaygroundAsync_WithEmptyDatabase_ShouldReturnEmptyList()
        {
            // Arrange
            var playgrounds = new List<Playground>();

            _repositoryManagerMock.Setup(r => r.Playground.GetAllPlaygroundAsync(false))
                .ReturnsAsync(playgrounds);

            _mapperMock.Setup(m => m.Map<IEnumerable<GetPlaygroundDto>>(playgrounds))
                .Returns(new List<GetPlaygroundDto>());

            // Act
            var result = await _sut.GetAllPlaygroundAsync(false);

            // Assert
            Assert.Empty(result);
        }

        #endregion

        #region GetPlaygroundByIdAsync Tests

        [Fact]
        public async Task GetPlaygroundByIdAsync_WithValidId_ShouldReturnPlayground()
        {
            // Arrange
            int playgroundId = 1;
            var playground = _fixture.Create<Playground>();
            var playgroundDto = _fixture.Create<GetPlaygroundDto>();

            _repositoryManagerMock.Setup(r => r.Playground.GetPlaygroundByIdAsync(playgroundId, false))
                .ReturnsAsync(playground);

            _mapperMock.Setup(m => m.Map<GetPlaygroundDto>(playground))
                .Returns(playgroundDto);

            // Act
            var result = await _sut.GetPlaygroundByIdAsync(playgroundId, false);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(playgroundDto, result);
        }

        [Fact]
        public async Task GetPlaygroundByIdAsync_WithInvalidId_ShouldThrowNotFoundException()
        {
            // Arrange
            int playgroundId = 999;

            _repositoryManagerMock.Setup(r => r.Playground.GetPlaygroundByIdAsync(playgroundId, false))
                .ReturnsAsync((Playground)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _sut.GetPlaygroundByIdAsync(playgroundId, false));
        }

        #endregion

        #region GetPlaygroundsByOwnerAsync Tests

        [Fact]
        public async Task GetPlaygroundsByOwnerAsync_WithValidOwnerId_ShouldReturnPlaygrounds()
        {
            // Arrange
            int ownerId = 1;
            var playgrounds = _fixture.CreateMany<Playground>(3).ToList();
            var playgroundDtos = _fixture.CreateMany<GetPlaygroundDto>(3);

            _repositoryManagerMock.Setup(r => r.Playground.GetPlaygroundsByOwnerAsync(ownerId, false))
                .ReturnsAsync(playgrounds);

            _mapperMock.Setup(m => m.Map<IEnumerable<GetPlaygroundDto>>(playgrounds))
                .Returns(playgroundDtos);

            // Act
            var result = await _sut.GetPlaygroundsByOwnerAsync(ownerId, false);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public async Task GetPlaygroundsByOwnerAsync_WithNoPlaygrounds_ShouldThrowNotFoundException()
        {
            // Arrange
            int ownerId = 999;
            var playgrounds = new List<Playground>();

            _repositoryManagerMock.Setup(r => r.Playground.GetPlaygroundsByOwnerAsync(ownerId, false))
                .ReturnsAsync(playgrounds);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _sut.GetPlaygroundsByOwnerAsync(ownerId, false));
        }

        #endregion

        #region SearchForPlaygroundAsync Tests

        [Fact]
        public async Task SearchForPlaygroundAsync_WithValidParameters_ShouldReturnPlaygrounds()
        {
            // Arrange
            string sportType = "Football";
            string city = "Cairo";
            var playgrounds = _fixture.CreateMany<Playground>(2).ToList();
            var playgroundDtos = _fixture.CreateMany<GetPlaygroundDto>(2);

            _repositoryManagerMock.Setup(r => r.Playground.SearchAsync(sportType, city, false))
                .ReturnsAsync(playgrounds);

            _mapperMock.Setup(m => m.Map<IEnumerable<GetPlaygroundDto>>(playgrounds))
                .Returns(playgroundDtos);

            // Act
            var result = await _sut.SearchForPlaygroundAsync(sportType, city, false);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task SearchForPlaygroundAsync_WithNoMatches_ShouldThrowNotFoundException()
        {
            // Arrange
            string sportType = "Football";
            string city = "NonExistentCity";
            var playgrounds = new List<Playground>();

            _repositoryManagerMock.Setup(r => r.Playground.SearchAsync(sportType, city, false))
                .ReturnsAsync(playgrounds);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() => 
                _sut.SearchForPlaygroundAsync(sportType, city, false));
            Assert.Contains("No playgrounds found", exception.Message);
        }

        #endregion

        #region UpdatePlaygroundAsync Tests

        [Fact]
        public async Task UpdatePlaygroundAsync_WithValidData_ShouldUpdatePlayground()
        {
            // Arrange
            int playgroundId = 1;
            var updatePlaygroundDto = _fixture.Create<UpdatePlaygroundDto>();
            var playgroundEntity = _fixture.Create<Playground>();

            _repositoryManagerMock.Setup(r => r.Playground.GetPlaygroundByIdAsync(playgroundId, true))
                .ReturnsAsync(playgroundEntity);

            _mapperMock.Setup(m => m.Map(updatePlaygroundDto, playgroundEntity))
                .Returns(playgroundEntity);

            _repositoryManagerMock.Setup(r => r.SaveAsync())
                .Returns(Task.CompletedTask);

            // Act
            var result = await _sut.UpdatePlaygroundAsync(playgroundId, updatePlaygroundDto, true);

            // Assert
            Assert.True(result.Success);
            Assert.Equal("Playground updated successfully", result.Message);
            _repositoryManagerMock.Verify(r => r.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task UpdatePlaygroundAsync_WithInvalidId_ShouldReturnFailure()
        {
            // Arrange
            int playgroundId = 999;
            var updatePlaygroundDto = _fixture.Create<UpdatePlaygroundDto>();

            _repositoryManagerMock.Setup(r => r.Playground.GetPlaygroundByIdAsync(playgroundId, true))
                .ReturnsAsync((Playground)null);

            // Act
            var result = await _sut.UpdatePlaygroundAsync(playgroundId, updatePlaygroundDto, true);

            // Assert
            Assert.False(result.Success);
            Assert.Equal($"Playground with id {playgroundId} not found.", result.Message);
            _repositoryManagerMock.Verify(r => r.SaveAsync(), Times.Never);
        }

        #endregion
    }
}
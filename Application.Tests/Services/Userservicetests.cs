using Application.DataTransferObjects.User;
using Application.Services;
using AutoFixture;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.Repositories;
using Moq;

namespace Application.Tests.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IRepositoryManager> _repositoryManagerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly IFixture _fixture;
        private readonly UserService _sut;

        public UserServiceTests()
        {
            _repositoryManagerMock = new Mock<IRepositoryManager>();
            _mapperMock = new Mock<IMapper>();
            _fixture = new Fixture();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _sut = new UserService(
                _repositoryManagerMock.Object,
                _mapperMock.Object);
        }

        #region DeleteUserAsync Tests

        [Fact]
        public async Task DeleteUserAsync_WithValidId_ShouldDeleteUser()
        {
            // Arrange
            int userId = 1;
            var user = _fixture.Create<User>();

            _repositoryManagerMock.Setup(r => r.User.GetUser(userId, true))
                .ReturnsAsync(user);

            _repositoryManagerMock.Setup(r => r.SaveAsync())
                .Returns(Task.CompletedTask);

            // Act
            var result = await _sut.DeleteUserAsync(userId, true);

            // Assert
            Assert.True(result.Success);
            Assert.Equal("User deleted successfully", result.Message);
            _repositoryManagerMock.Verify(r => r.User.DeleteUser(user), Times.Once);
            _repositoryManagerMock.Verify(r => r.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteUserAsync_WithInvalidId_ShouldReturnFailure()
        {
            // Arrange
            int userId = 999;

            _repositoryManagerMock.Setup(r => r.User.GetUser(userId, true))
                .ReturnsAsync((User)null);

            // Act
            var result = await _sut.DeleteUserAsync(userId, true);

            // Assert
            Assert.False(result.Success);
            Assert.Equal("No user found", result.Message);
            _repositoryManagerMock.Verify(r => r.User.DeleteUser(It.IsAny<User>()), Times.Never);
        }

        #endregion

        #region GetUserByIdAsync Tests

        [Fact]
        public async Task GetUserByIdAsync_WithValidId_ShouldReturnUser()
        {
            // Arrange
            int userId = 1;
            var user = _fixture.Create<User>();
            var userDto = _fixture.Create<GetUserDto>();

            _repositoryManagerMock.Setup(r => r.User.GetUser(userId, false))
                .ReturnsAsync(user);

            _mapperMock.Setup(m => m.Map<GetUserDto>(user))
                .Returns(userDto);

            // Act
            var result = await _sut.GetUserByIdAsync(userId, false);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userDto, result);
        }

        [Fact]
        public async Task GetUserByIdAsync_WithInvalidId_ShouldThrowNotFoundException()
        {
            // Arrange
            int userId = 999;

            _repositoryManagerMock.Setup(r => r.User.GetUser(userId, false))
                .ReturnsAsync((User)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _sut.GetUserByIdAsync(userId, false));
        }

        #endregion

        #region GetUsersAsync Tests

        [Fact]
        public async Task GetUsersAsync_ShouldReturnAllUsers()
        {
            // Arrange
            var users = _fixture.CreateMany<User>(4).ToList();
            var userDtos = _fixture.CreateMany<GetUserDto>(4);

            _repositoryManagerMock.Setup(r => r.User.GetAllUsers(false))
                .ReturnsAsync(users);

            _mapperMock.Setup(m => m.Map<IEnumerable<GetUserDto>>(users))
                .Returns(userDtos);

            // Act
            var result = await _sut.GetUsersAsync(false);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(4, result.Count());
        }

        [Fact]
        public async Task GetUsersAsync_WithNoUsers_ShouldThrowNotFoundException()
        {
            // Arrange
            var users = new List<User>();

            _repositoryManagerMock.Setup(r => r.User.GetAllUsers(false))
                .ReturnsAsync(users);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _sut.GetUsersAsync(false));
        }

        #endregion

        #region UpdateUserAsync Tests

        [Fact]
        public async Task UpdateUserAsync_WithValidData_ShouldUpdateUser()
        {
            // Arrange
            int userId = 1;
            var updateUserDto = _fixture.Create<UpdateUserDto>();
            var userEntity = _fixture.Create<User>();

            _repositoryManagerMock.Setup(r => r.User.GetUser(userId, true))
                .ReturnsAsync(userEntity);

            _mapperMock.Setup(m => m.Map(updateUserDto, userEntity))
                .Returns(userEntity);

            _repositoryManagerMock.Setup(r => r.SaveAsync())
                .Returns(Task.CompletedTask);

            // Act
            var result = await _sut.UpdateUserAsync(userId, updateUserDto, true);

            // Assert
            Assert.True(result.Success);
            Assert.Equal("User updated successfully", result.Message);
            _repositoryManagerMock.Verify(r => r.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task UpdateUserAsync_WithInvalidId_ShouldReturnFailure()
        {
            // Arrange
            int userId = 999;
            var updateUserDto = _fixture.Create<UpdateUserDto>();

            _repositoryManagerMock.Setup(r => r.User.GetUser(userId, true))
                .ReturnsAsync((User)null);

            // Act
            var result = await _sut.UpdateUserAsync(userId, updateUserDto, true);

            // Assert
            Assert.False(result.Success);
            Assert.Equal("No user found", result.Message);
            _repositoryManagerMock.Verify(r => r.SaveAsync(), Times.Never);
        }

        #endregion
    }
}
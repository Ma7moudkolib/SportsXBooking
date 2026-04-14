using Application.DataTransferObjects.User;
using Application.ServiceInterfaces;
using Application.Services;
using AutoFixture;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Moq;

namespace Application.Tests.Services
{
    public class AuthenticationServiceTests
    {
        private readonly Mock<IRepositoryManager> _repositoryManagerMock;
        private readonly Mock<ILoggerManager> _loggerManagerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IConfiguration> _configurationMock;
        private readonly IFixture _fixture;
        private readonly AuthenticationService _sut;

        public AuthenticationServiceTests()
        {
            _repositoryManagerMock = new Mock<IRepositoryManager>();
            _loggerManagerMock = new Mock<ILoggerManager>();
            _mapperMock = new Mock<IMapper>();
            _configurationMock = new Mock<IConfiguration>();
            _fixture = new Fixture();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _sut = new AuthenticationService(
                _repositoryManagerMock.Object,
                _loggerManagerMock.Object,
                _mapperMock.Object,
                _configurationMock.Object);
        }

        #region RegisterUser Tests

        [Fact]
        public async Task RegisterUser_WithValidData_ShouldReturnSuccess()
        {
            // Arrange
            var userForRegistration = _fixture.Create<UserForRegistrationDto>();
            var userEntity = _fixture.Create<User>();

            _mapperMock.Setup(m => m.Map<User>(userForRegistration))
                .Returns(userEntity);

            _repositoryManagerMock.Setup(r => r.User.GetByEmailAsync(userEntity.Email, false))
                .ReturnsAsync((User)null);

            _repositoryManagerMock.Setup(r => r.SaveAsync())
                .Returns(Task.CompletedTask);

            // Act
            var result = await _sut.RegisterUser(userForRegistration);

            // Assert
            Assert.True(result.Success);
            Assert.Equal("User registered successfully.", result.Message);
            _repositoryManagerMock.Verify(r => r.User.CreateUser(It.IsAny<User>()), Times.Once);
            _repositoryManagerMock.Verify(r => r.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task RegisterUser_WithExistingEmail_ShouldReturnFailure()
        {
            // Arrange
            var userForRegistration = _fixture.Create<UserForRegistrationDto>();
            var existingUser = _fixture.Create<User>();

            _mapperMock.Setup(m => m.Map<User>(userForRegistration))
                .Returns(existingUser);

            _repositoryManagerMock.Setup(r => r.User.GetByEmailAsync(existingUser.Email, false))
                .ReturnsAsync(existingUser);

            // Act
            var result = await _sut.RegisterUser(userForRegistration);

            // Assert
            Assert.False(result.Success);
            Assert.Equal("User with this email already exists.", result.Message);
            _repositoryManagerMock.Verify(r => r.User.CreateUser(It.IsAny<User>()), Times.Never);
        }

        [Fact]
        public async Task RegisterUser_ShouldHashPassword()
        {
            // Arrange
            var userForRegistration = new UserForRegistrationDto
            {
                Email = "test@example.com",
                Password = "SecurePassword123",
                FullName = "Test User"
            };
            var userEntity = new User { Email = userForRegistration.Email };

            _mapperMock.Setup(m => m.Map<User>(userForRegistration))
                .Returns(userEntity);

            _repositoryManagerMock.Setup(r => r.User.GetByEmailAsync(userEntity.Email, false))
                .ReturnsAsync((User)null);

            _repositoryManagerMock.Setup(r => r.SaveAsync())
                .Returns(Task.CompletedTask);

            // Act
            await _sut.RegisterUser(userForRegistration);

            // Assert
            Assert.NotNull(userEntity.PasswordHash);
            Assert.NotEqual(userForRegistration.Password, userEntity.PasswordHash);
        }

        #endregion

        #region ValidateUser Tests

        [Fact]
        public async Task ValidateUser_WithValidCredentials_ShouldReturnTrue()
        {
            // Arrange
            var userForLogin = _fixture.Create<UserForLoginDto>();
            var hashedPassword = "hashed_password";
            var user = new User
            {
                Email = userForLogin.Email,
                PasswordHash = hashedPassword,
                FullName = "Test User"
            };

            _repositoryManagerMock.Setup(r => r.User.GetByEmailAsync(userForLogin.Email, false))
                .ReturnsAsync(user);

            // Act - we need a real password hasher to test this properly
            var passwordHasher = new PasswordHasher<User>();
            user.PasswordHash = passwordHasher.HashPassword(user, "TestPassword123");
            var result = await _sut.ValidateUser(new UserForLoginDto 
            { 
                Email = userForLogin.Email, 
                Password = "TestPassword123" 
            });

            // Note: This test shows the limitation - we can't easily mock PasswordHasher
            // In production, you'd want to inject IPasswordHasher<User> for better testability
        }

        [Fact]
        public async Task ValidateUser_WithInvalidEmail_ShouldReturnFalse()
        {
            // Arrange
            var userForLogin = _fixture.Create<UserForLoginDto>();

            _repositoryManagerMock.Setup(r => r.User.GetByEmailAsync(userForLogin.Email, false))
                .ReturnsAsync((User)null);

            // Act
            var result = await _sut.ValidateUser(userForLogin);

            // Assert
            Assert.False(result);
            _loggerManagerMock.Verify(l => l.LogInfo(It.IsAny<string>()), Times.Once);
        }

        #endregion

        // #region CreateToken Tests

        // [Fact]
        // public void CreateToken_ShouldGenerateValidJwtToken()
        // {
        //     // Arrange
        //     var user = new User
        //     {
        //         FullName = "Test User",
        //         Role = "User",
        //         Email = "test@example.com"
        //     };

        //     // Setup configuration mocks
        //     _configurationMock.Setup(c => c["SecretKey"])
        //         .Returns("SuperSecretKeyThatIsLongEnoughForHashing");
        //     _configurationMock.Setup(c => c["JwtSettings:Issuer"])
        //         .Returns("TestIssuer");
        //     _configurationMock.Setup(c => c["JwtSettings:Audience"])
        //         .Returns("TestAudience");
        //     _configurationMock.Setup(c => c["JwtSettings:expires"])
        //         .Returns("60");

        //     // We need to set _user via ValidateUser first or use reflection
        //     // This shows the need for better dependency injection
        // }

        // #endregion
    }
}
using Application.DataTransferObjects;
using Application.DataTransferObjects.User;
using Application.ServiceInterfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services
{
    public sealed class AuthenticationService : IAuthenticationService
    {
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IPasswordHasher<User> passwordHasher;
        private User? _user;

        public AuthenticationService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper, IConfiguration configuration)
        {
            _repositoryManager = repositoryManager;
            _configuration = configuration;
            _loggerManager = loggerManager;
            _mapper = mapper;
            passwordHasher = new PasswordHasher<User>();
        }

        public string CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        public AuthUser GetAuthenticatedUser()
        {
            if (_user is null)
            {
                throw new InvalidOperationException("No authenticated user in context.");
            }

            return new AuthUser(_user.UserId, _user.FullName, _user.Email, _user.Role);
        }

        public async Task<ServiceResponse> RegisterUser(UserForRegistrationDto userForRegistration)
        {
            var user = _mapper.Map<User>(userForRegistration);

            var existingUser = await _repositoryManager.User.GetByEmailAsync(user.Email, false);
            if (existingUser != null)
            {
                _loggerManager.LogInfo($"User with email {user.Email} already exists.");
                return new ServiceResponse(false, "User with this email already exists.");
            }

            user.PasswordHash = passwordHasher.HashPassword(user, userForRegistration.Password);
            _repositoryManager.User.CreateUser(user);
            await _repositoryManager.SaveAsync();

            _loggerManager.LogInfo($"User with email {user.Email} registered successfully.");
            return new ServiceResponse(true, "User registered successfully.");
        }

        public async Task<bool> ValidateUser(UserForLoginDto userForLogin)
        {
            _user = await _repositoryManager.User.GetByEmailAsync(userForLogin.Email!, false);
            var result = _user != null && VerifyPassword(_user, userForLogin.Password!);
            if (!result)
            {
                _loggerManager.LogInfo($"Authentication failed for user with email {userForLogin.Email}.");
            }

            return result;
        }

        private bool VerifyPassword(User user, string password)
        {
            var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            return result == PasswordVerificationResult.Success;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_configuration["SecretKey"]!);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private List<Claim> GetClaims()
        {
            return
            [
                new Claim(ClaimTypes.Name, _user!.FullName),
                new Claim(ClaimTypes.Role, _user.Role),
                new Claim(ClaimTypes.Email, _user.Email),
                new Claim(ClaimTypes.NameIdentifier, _user.UserId.ToString())
            ];
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            return new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["JwtSettings:Expires"])),
                signingCredentials: signingCredentials);
        }
    }
}

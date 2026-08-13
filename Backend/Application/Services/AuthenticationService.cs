using Application.DataTransferObjects;
using Application.DataTransferObjects.User;
using Application.ServiceInterfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
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
        private readonly UserManager<User> _userManager;

        public AuthenticationService(IRepositoryManager repositoryManager,
            UserManager<User> userManager, ILoggerManager loggerManager,
            IMapper mapper, IConfiguration configuration)
        {
            _repositoryManager = repositoryManager;
            _configuration = configuration;
            _loggerManager = loggerManager;
            _mapper = mapper;
            _userManager = userManager;
        }
        // player1@sportsx.local
        public async Task<ServiceResponse> RegisterUser(UserForRegistrationDto userForRegistration)
        {

            var existingUser = await _userManager.FindByEmailAsync(userForRegistration.Email);

            if (existingUser != null)
            {
                _loggerManager.LogInfo($"User with email {userForRegistration.Email} already exists.");
                return new ServiceResponse(false, "User with this email already exists.");
            }

            var user = new User
            {
                FirstName = userForRegistration.FirstName,
                LastName = userForRegistration.LastName,
                Email = userForRegistration.Email,
                PhoneNumber = userForRegistration.Phone,
                Role = userForRegistration.Role,
                UserName = userForRegistration.FirstName
            };

            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded)
            {
                _loggerManager.LogInfo($"Failed to register user with email {user.Email}.");
                return new ServiceResponse(false, $"Failed to register user. the error is {result.Errors.All}.");
            }
            var roleResult = await _userManager.AddToRoleAsync(user, user.Role);
            if (!roleResult.Succeeded)
                throw new Exception($"Failed to assign role {user.Role} to user {user.Email}. Errors: " +
                    $"{string.Join(", ", roleResult.Errors.Select(e => e.Description))}");

            await _repositoryManager.SaveAsync();

            _loggerManager.LogInfo($"User with email {user.Email} registered successfully.");
            return new ServiceResponse(true, "User registered successfully.");
        }

        public async Task<LoginResponse> LoginUser(UserForLoginDto userLogin)
        {
            var existingUser = await _userManager.FindByEmailAsync(userLogin.Email!);
            if (existingUser is null)
                return new LoginResponse(Success: false, Message: $"Authentication failed for user with email {userLogin.Email}.");
            var result = await _userManager.CheckPasswordAsync(existingUser, userLogin.Password!);
            if (!result)
            {
                _loggerManager.LogInfo($"Authentication failed for user with email {userLogin.Email}.");
                return new LoginResponse(Success: false, Message: $"Authentication failed for user with email {userLogin.Email}.");
            }
            var token = CreateToken(existingUser);
            var userDto = new GetUserDto
            {
                UserId = existingUser.Id,
                FirstName = existingUser.FirstName,
                LastName = existingUser.LastName,
                Email = existingUser.Email!,
                PhoneNumber = existingUser.PhoneNumber!,
                Role = existingUser.Role
            };
            return new LoginResponse(Success: true, Message: $"Authentication successful for user with email {userLogin.Email}.", Token: token, user: userDto);

        }

        private string CreateToken(User user)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = GetClaims(user);
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_configuration["SecretKey"]!);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private List<Claim> GetClaims(User user)
        {
            return
            [
                new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
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

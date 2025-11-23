using Application.DataTransferObjects.User;

namespace Application.ServiceInterfaces
{
    public interface IAuthenticationService
    {
        Task<bool> RegisterUser(UserForRegistrationDto userForRegistration);
        Task<bool> ValidateUser(UserForLoginDto userForLogin );
        public string CreateToken();
    }
}

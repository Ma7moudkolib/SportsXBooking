using Application.DataTransferObjects;
using Application.DataTransferObjects.User;

namespace Application.ServiceInterfaces
{
    public interface IAuthenticationService
    {
        Task<ServiceResponse> RegisterUser(UserForRegistrationDto userForRegistration);
        Task<bool> ValidateUser(UserForLoginDto userForLogin );
        public string CreateToken();
    }
}

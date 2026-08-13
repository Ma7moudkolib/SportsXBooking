using Application.DataTransferObjects;
using Application.DataTransferObjects.User;
using Domain.Entities;

namespace Application.ServiceInterfaces
{
    public interface IAuthenticationService
    {
        Task<ServiceResponse> RegisterUser(UserForRegistrationDto userForRegistration);
        Task<LoginResponse> LoginUser(UserForLoginDto userLogin);
    }
}

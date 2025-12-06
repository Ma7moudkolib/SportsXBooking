using Application.DataTransferObjects;
using Application.DataTransferObjects.User;
using System.Numerics;

namespace Application.ServiceInterfaces
{
    public interface IUserService
    {
        Task<IEnumerable<GetUserDto>> GetUsersAsync(bool trackChanges);
        Task<GetUserDto> GetUserByIdAsync(int id, bool trackChanges);
        Task<ServiceResponse> UpdateUserAsync(int id, UpdateUserDto updateUser,bool trackChanges);
        Task<ServiceResponse> DeleteUserAsync(int id,bool trackChanges); 
    }
}

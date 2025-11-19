using Application.DataTransferObjects.User;
using System.Numerics;

namespace Application.ServiceInterfaces
{
    public interface IUserService
    {
        Task<IEnumerable<GetUserDto>> GetUsersAsync(bool trackChanges);
        Task<GetUserDto> GetUserByIdAsync(int id, bool trackChanges);
        Task UpdateUserAsync(int id, UpdateUserDto updateUser,bool trackChanges);
        Task DeleteUserAsync(int id,bool trackChanges); 
    }
}

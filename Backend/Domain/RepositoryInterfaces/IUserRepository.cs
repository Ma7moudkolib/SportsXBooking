using Domain.Entities;
namespace Domain.RepositoryInterfaces
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        Task<IEnumerable<User>> GetAllUsers(bool trackChanges);
        Task<User> GetUser(int userId,bool trackChanges);
        Task<User> GetByEmailAsync(string email,bool trackChanges);
        Task<IEnumerable<User>> GetUsersByRoleAsync(string role,bool trackChanges);
        void DeleteUser(User user);
    }


}

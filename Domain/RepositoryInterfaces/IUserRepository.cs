using Domain.Entities;
namespace Domain.RepositoryInterfaces
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task<bool> EmailExistsAsync(string email);
        Task<IEnumerable<User>> GetUsersByRoleAsync(string role);
        Task<bool> ValidateCredentialsAsync(string email, string password);
    }


}

using Domain.Entities;
using Domain.RepositoryInterfaces;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext ):base( repositoryContext ) { }

        public void CreateUser(User user)=>Create(user);

        public void DeleteUser(User user)=> Delete(user);

        public async Task<IEnumerable<User>> GetAllUsers(bool trackChanges)=>await FindAll(trackChanges).ToListAsync();

        public Task<User> GetByEmailAsync(string email, bool trackChanges)=>
            FindByCondition(u => u.Email == email, trackChanges).SingleOrDefaultAsync()!;

        public async Task<User> GetUser(int userId, bool trackChanges)=> await FindByCondition(u => u.UserId == userId, trackChanges).SingleOrDefaultAsync()!;

        public async Task<IEnumerable<User>> GetUsersByRoleAsync(string role, bool trackChanges) => await FindByCondition(u => u.Role == role, trackChanges).ToListAsync();
    }
}

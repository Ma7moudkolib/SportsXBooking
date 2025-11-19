using Domain.Entities;
using Domain.RepositoryInterfaces;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PlaygroundRepository : RepositoryBase<Playground>, IPlaygroundRepository
    {
        public PlaygroundRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public void CreatePlayground(Playground playground)=> Create(playground);

        public void DeletePlayground(Playground playground) => Delete(playground);

        public async Task<IEnumerable<Playground>> GetAllPlaygroundAsync(bool trackChanges) => await FindAll(trackChanges).OrderBy(p=>p.Name).ToListAsync();

        public async Task<Playground> GetPlaygroundByIdAsync(int id, bool trackChanges) =>
          await FindByCondition(p => p.PlaygroundId == id, trackChanges).SingleOrDefaultAsync();

        public async Task<IEnumerable<Playground>> GetPlaygroundsByOwnerAsync(int ownerId, bool trackChanges)=>
            await FindByCondition(p => p.OwnerId == ownerId, trackChanges).ToListAsync();


        public async Task<IEnumerable<Playground>> SearchAsync(string sportType, string city, bool trackChanges) =>
          await FindByCondition(p => p.SportType.Contains(sportType) && p.Equals(city), trackChanges)
            .ToListAsync();

        public void UpdatePlayground(Playground playground) => Update(playground);
    }
}

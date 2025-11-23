using Domain.Entities;

namespace Domain.RepositoryInterfaces
{
    public interface IPlaygroundRepository
    {
        Task<IEnumerable<Playground>> GetAllPlaygroundAsync(bool trackChanges);
        Task<Playground> GetPlaygroundByIdAsync(int id, bool trackChanges);
        Task<IEnumerable<Playground>> GetPlaygroundsByOwnerAsync(int ownerId, bool trackChanges);
        Task<IEnumerable<Playground>> SearchAsync(string sportType, string city, bool trackChanges);

        void CreatePlayground(Playground playground);
        void DeletePlayground(Playground playground );
        void UpdatePlayground(Playground playground);
        
    }
}

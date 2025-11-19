using Domain.Entities;

namespace Domain.RepositoryInterfaces
{
    public interface IPlaygroundRepository
    {
        Task<IEnumerable<Playground>> GetPlaygroundsByOwnerAsync(int ownerId, bool trackChanges);
        Task<IEnumerable<Playground>> SearchAsync(string sportType, string city, bool trackChanges);
    }
}

using Application.DataTransferObjects.Playground;
using Domain.Entities;

namespace Application.ServiceInterfaces
{
    public interface IPlaygroundService
    {
        Task<IEnumerable<GetPlaygroundDto>> GetAllPlaygroundAsync(bool trackChanges);
        Task<GetPlaygroundDto> GetPlaygroundByIdAsync(int id, bool trackChanges);
        Task<IEnumerable<GetPlaygroundDto>> GetPlaygroundsByOwnerAsync(int ownerId, bool trackChanges);
        Task<IEnumerable<GetPlaygroundDto>> SearchForPlaygroundAsync(string sportType, string city, bool trackChanges);
        Task<GetPlaygroundDto> CreatePlaygroundAsync(CreatePlaygroundDto createPlayground);
        Task UpdatePlaygroundAsync(int id, UpdatePlaygroundDto updatePlayground,bool trackChanges);
        Task DeletePlaygroundAsync(int id,bool trackChanges);
    }
}

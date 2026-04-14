using Application.DataTransferObjects;
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
        Task<ServiceResponse> CreatePlaygroundAsync(CreatePlaygroundDto createPlayground);
        Task<ServiceResponse> UpdatePlaygroundAsync(int id, UpdatePlaygroundDto updatePlayground,bool trackChanges);
        Task<ServiceResponse> DeletePlaygroundAsync(int id,bool trackChanges);
    }
}

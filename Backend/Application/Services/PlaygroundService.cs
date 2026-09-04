using Application.DataTransferObjects;
using Application.DataTransferObjects.Playground;
using Application.ServiceInterfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.RepositoryInterfaces;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class PlaygroundService : IPlaygroundService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly IFileStorage _fileStorage;
        public PlaygroundService(IRepositoryManager repositoryManager , IMapper mapper , IFileStorage fileStorage)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
            _fileStorage = fileStorage;
        }

        public async Task<ServiceResponse> CreatePlaygroundAsync(CreatePlaygroundDto createPlayground)
        {
            var imageUrl = await _fileStorage.SaveFileAsync(createPlayground.Image, "playgroundImages");
            var playgroundEntity = _mapper.Map<Playground>(createPlayground);
            playgroundEntity.ImageUrl = imageUrl;
            _repositoryManager.Playground.CreatePlayground(playgroundEntity);
          await  _repositoryManager.SaveAsync();
          
            return new ServiceResponse(true, "Playground created successfully");
        }

        public async Task<ServiceResponse> DeletePlaygroundAsync(int id,bool trackChanges)
        {
           var playground = await _repositoryManager.Playground.GetPlaygroundByIdAsync(id, trackChanges);
            if (playground == null)
               return new ServiceResponse(false, $"Playground with id {id} not found.");

            var imageUrl = playground.ImageUrl;
            _repositoryManager.Playground.DeletePlayground(playground);
            await _repositoryManager.SaveAsync();

            if (!string.IsNullOrEmpty(imageUrl))
            {
                _fileStorage.DeleteFile(imageUrl);
            }
            return new ServiceResponse(true, "Playground deleted successfully");
        }

        public async Task<IEnumerable<GetPlaygroundDto>> GetAllPlaygroundAsync(bool trackChanges)
        {
            var playgrounds =await _repositoryManager.Playground.GetAllPlaygroundAsync(trackChanges);
            var playgroundsDto = _mapper.Map<IEnumerable<GetPlaygroundDto>>(playgrounds);
            return playgroundsDto;
        }

        public async Task<GetPlaygroundDto> GetPlaygroundByIdAsync(int id, bool trackChanges)
        {
            var playground =await _repositoryManager.Playground.GetPlaygroundByIdAsync(id, trackChanges);
            if(playground == null)
                throw new NotFoundException($"Playground with id {id} not found.");
            var playgroundDto = _mapper.Map<GetPlaygroundDto>(playground);
            return playgroundDto;
        }

        public async Task<IEnumerable<GetPlaygroundDto>> GetPlaygroundsByOwnerAsync(int ownerId, bool trackChanges)
        {
           var playgrounds =await _repositoryManager.Playground.GetPlaygroundsByOwnerAsync(ownerId, trackChanges);
           if (!playgrounds.Any())
                return new List<GetPlaygroundDto>();
            var playgroundsDto = _mapper.Map<IEnumerable<GetPlaygroundDto>>(playgrounds);
            return playgroundsDto;
        }

        public async Task<IEnumerable<GetPlaygroundDto>> SearchForPlaygroundAsync(string sportType, string city, bool trackChanges)
        {
            var playgrounds = await _repositoryManager.Playground.SearchAsync(sportType, city, trackChanges);
            if (!playgrounds.Any())
                return new List<GetPlaygroundDto>();
            var playgroundsDto = _mapper.Map<IEnumerable<GetPlaygroundDto>>(playgrounds);
            return playgroundsDto;
        }

        public async Task<ServiceResponse> UpdatePlaygroundAsync(int id, UpdatePlaygroundDto updatePlayground , bool trackChanges)
        {
           var playgroundEntity = await _repositoryManager.Playground.GetPlaygroundByIdAsync(id, trackChanges);
            if (playgroundEntity is null)
               return new ServiceResponse(false, $"Playground with id {id} not found.");
            _mapper.Map(updatePlayground, playgroundEntity);
            await _repositoryManager.SaveAsync();
            return new ServiceResponse(true, "Playground updated successfully");
        }
    }
}

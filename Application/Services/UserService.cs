
using Application.DataTransferObjects.User;
using Application.ServiceInterfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public UserService(IRepositoryManager repositoryManager,IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task DeleteUserAsync(int id,bool trackChanges)
        {
            var user = await _repositoryManager.User.GetUser(id, trackChanges);
            if (user is null)
                throw new NotFoundException("No user found");
            _repositoryManager.User.DeleteUser(user);
            await _repositoryManager.SaveAsync();
        }

        public async Task<GetUserDto> GetUserByIdAsync(int id, bool trackChanges)
        {
            var userEntitie = await _repositoryManager.User.GetUser(id,trackChanges);

            if (userEntitie is null)
                throw new NotFoundException("No user found");
            var userDto = _mapper.Map<GetUserDto>(userEntitie);
            return userDto;
        }

        public async Task<IEnumerable<GetUserDto>> GetUsersAsync(bool trackChanges)
        {
            var usersEntities = await _repositoryManager.User.GetAllUsers(trackChanges);
            
            if (!usersEntities.Any())
                throw new NotFoundException("No users found");
            var usersDto = _mapper.Map<IEnumerable<GetUserDto>>(usersEntities);
            return usersDto;
        }

        public async Task UpdateUserAsync(int id, UpdateUserDto updateUser,bool trackChanges)
        {
            var userEntity = await _repositoryManager.User.GetUser(id, trackChanges);
            if (userEntity is null)
                throw new NotFoundException("No user found");
            _mapper.Map(updateUser, userEntity);
            await _repositoryManager.SaveAsync();
        }
    }
}

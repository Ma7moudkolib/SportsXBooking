using Application.DataTransferObjects.User;
using Application.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public UsersController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
           var users = await _serviceManager.User.GetUsersAsync(trackChanges: false);
            return Ok(users);
        }
        [HttpGet("{id}",Name = "UserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _serviceManager.User.GetUserByIdAsync(id, trackChanges: false);
            return Ok(user);
        }
       
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id) 
        {
            _serviceManager.User.DeleteUserAsync(id,trackChanges:false);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id , [FromBody] UpdateUserDto updateUser)
        {
            await _serviceManager.User.UpdateUserAsync(id ,updateUser,true);
            return NoContent();
        }


    }
}

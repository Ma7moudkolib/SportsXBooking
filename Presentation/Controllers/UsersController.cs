using Application.DataTransferObjects.User;
using Application.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
           var users = await _serviceManager.User.GetUsersAsync(trackChanges: false);
            return Ok(users);
        }
        [HttpGet("{id}",Name = "UserById")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _serviceManager.User.GetUserByIdAsync(id, trackChanges: false);
            return Ok(user);
        }
       
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeleteUser(int id) 
        {
          var result = _serviceManager.User.DeleteUserAsync(id,trackChanges:false);
            return Ok(result);
        }
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateUser(int id , [FromBody] UpdateUserDto updateUser)
        {
          var result= await _serviceManager.User.UpdateUserAsync(id ,updateUser,true);
            return Ok(result);
        }


    }
}

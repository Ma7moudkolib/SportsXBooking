using Application.DataTransferObjects.User;
using Application.ServiceInterfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public AuthenticationController(IServiceManager serviceManager )
        {
            _serviceManager = serviceManager;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegistrationDto userForRegistration)
        {
            var result = await _serviceManager.Authentication.RegisterUser(userForRegistration);
            if (!result.Success)
                return BadRequest(ModelState);
            
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForAuthentication)
        {
            var result = await _serviceManager.Authentication.ValidateUser(userForAuthentication);
            if (!result)
                return Unauthorized();

            var token = _serviceManager.Authentication.CreateToken();
            return Ok(new LoginResponse(true,"Login Successfull",token));
        }
    }
}

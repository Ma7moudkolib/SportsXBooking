using Application.DataTransferObjects.User;
using Application.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public AuthenticationController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] UserForRegistrationDto userForRegistration)
        {
            var result = await _serviceManager.Authentication.RegisterUser(userForRegistration);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] UserForLoginDto userForAuthentication)
        {
            var response = await _serviceManager.Authentication.LoginUser(userForAuthentication);
            return Ok(response);
        }
    }
}

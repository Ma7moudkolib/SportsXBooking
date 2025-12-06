using Application.DataTransferObjects.Playground;
using Application.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaygroundsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public PlaygroundsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPlaygrounds()
        {
            var playgrounds = await _serviceManager.Playground.GetAllPlaygroundAsync(trackChanges: false);
            return Ok(playgrounds);
        }
        [HttpGet("{id}", Name = "Playground")]
        public async Task<IActionResult> GetPlaygroundById(int id)
        {
            var playground = await _serviceManager.Playground.GetPlaygroundByIdAsync(id, trackChanges: false);
            return Ok(playground);
        }
        [HttpGet("owner/{ownerId}")]
        public async Task<IActionResult> GetPlaygroundsByOwner(int ownerId)
        {
            var playgrounds = await _serviceManager.Playground.GetPlaygroundsByOwnerAsync(ownerId, trackChanges: false);
            return Ok(playgrounds);
        }
        [HttpPost]
        [Authorize(Roles = "Owner")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreatePlayground([FromBody] CreatePlaygroundDto createPlayground)
        {
            var playgroundResponse = await _serviceManager.Playground.CreatePlaygroundAsync(createPlayground);
            return Ok(playgroundResponse);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Owner")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePlayground(int id)
        {
            var result =  await _serviceManager.Playground.DeletePlaygroundAsync(id, trackChanges: false);
            return Ok(result);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Owner")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatePlayground(int id, [FromBody] UpdatePlaygroundDto updatePlayground)
        {
           var result = await _serviceManager.Playground.UpdatePlaygroundAsync(id, updatePlayground, trackChanges: true);
            return Ok(result);
        }
    }
}

using Application.DataTransferObjects.Playground;
using Application.ServiceInterfaces;
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
        public async Task<IActionResult> CreatePlayground([FromBody] CreatePlaygroundDto createPlayground)
        {
            var playground = await _serviceManager.Playground.CreatePlaygroundAsync(createPlayground);
            return CreatedAtRoute("Playground", new { id = playground.PlaygroundId }, playground);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayground(int id)
        {
            await _serviceManager.Playground.DeletePlaygroundAsync(id, trackChanges: false);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayground(int id, [FromBody] UpdatePlaygroundDto updatePlayground)
        {
            await _serviceManager.Playground.UpdatePlaygroundAsync(id, updatePlayground, trackChanges: true);
            return NoContent();
        }
    }
}

using Application.DataTransferObjects.Review;
using Application.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public ReviewsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpGet("playground/{playgroundId}")]
        public async Task<IActionResult> GetReviewsForPlayground(int playgroundId)
        {
            var reviews = await _serviceManager.Review.GetForPlaygroundAsync(playgroundId, trackChanges: false);
            return Ok(reviews);
        }
        [HttpPost]
        public async Task<IActionResult> AddReview([FromBody] ReviewDto review)
        {
            var createdReview = await _serviceManager.Review.AddReviewAsync(review);
            return Ok(createdReview);
        }
    }
}

using Application.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public PaymentsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpGet("{id}", Name = "PaymentById")]
        public async Task<IActionResult> GetPaymentById(int id)
        {
            var payment = await _serviceManager.Payment.GetPaymentByBookingIdAsync(id, trackChanges: false);
            return Ok(payment);
        }
    }
}

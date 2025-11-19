using Application.DataTransferObjects.Booking;
using Application.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public BookingsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooking()
        {
            var bookings = await _serviceManager.Booking.GetAllBookingAsync(trackChanges: false);
            return Ok(bookings);
        }

        [HttpGet("{id}",Name ="GetBookingById")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var booking = await _serviceManager.Booking.GetBookingByIdAsync(id, trackChanges:false);
            return Ok(booking);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBooking createBooking)
        {
            var booking = await _serviceManager.Booking.CreateBookingAsync(createBooking);
            return CreatedAtRoute("GetBookingById", new { id = booking.BookingId }, booking);
        }
        [HttpPut("cancel/{id}")]
        public async Task<IActionResult> CancelBooking(int id)
        {
            await _serviceManager.Booking.CancelBookingAsync(id, trackChanges: true);
            return NoContent();
        }
    }
}

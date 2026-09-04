using Application.DataTransferObjects;
using Application.DataTransferObjects.Booking;
using Application.ServiceInterfaces;
using Domain.ErrorModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [HttpGet("{id}", Name = "GetBookingById")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var booking = await _serviceManager.Booking.GetBookingByIdAsync(id, trackChanges: false);
            return Ok(booking);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBooking createBooking)
        {
            var booking = await _serviceManager.Booking.CreateBookingAsync(createBooking);
            return Ok(booking);
        }
        [HttpPut("cancel/{id}")]
        public async Task<IActionResult> CancelBooking(int id)
        {
            var result = await _serviceManager.Booking.CancelBookingAsync(id, trackChanges: true);
            return Ok(result);
        }

        [HttpGet("owner/analytics")]
        [Authorize(Roles = "Owner,Admin")]
        public async Task<IActionResult> GetOwnerAnalytics()
        {
            var ownerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var analytics = await _serviceManager.Booking.GetOwnerAnalyticsAsync(ownerId);
            return Ok(analytics);
        }

        [HttpGet("owner")]
        [Authorize(Roles = "Owner,Admin")]
        public async Task<IActionResult> GetOwnerBookings([FromQuery] int? playgroundId, [FromQuery] string? status, [FromQuery] DateTime? date)
        {
            var ownerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var filters = new OwnerBookingQueryParams
            {
                PlaygroundId = playgroundId,
                Status = status,
                Date = date
            };
            var bookings = await _serviceManager.Booking.GetOwnerBookingsAsync(ownerId, filters, trackChanges: false);
            return Ok(bookings);
        }

        [HttpGet("owner/{id}")]
        [Authorize(Roles = "Owner,Admin")]
        public async Task<IActionResult> GetOwnerBookingDetails(int id)
        {
            var ownerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var booking = await _serviceManager.Booking.GetOwnerBookingDetailsAsync(ownerId, id, trackChanges: false);
            if (booking is null)
                return NotFound(new ErrorDetails { StatusCode = 404, Message = "Booking not found." });
            return Ok(booking);
        }

        [HttpPut("owner/confirm/{id}")]
        [Authorize(Roles = "Owner,Admin")]
        public async Task<IActionResult> ConfirmBooking(int id)
        {
            var ownerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var result = await _serviceManager.Booking.ConfirmBookingAsync(ownerId, id);
            return Ok(result);
        }
    }
}

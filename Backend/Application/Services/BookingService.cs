using Application.DataTransferObjects;
using Application.DataTransferObjects.Booking;
using Application.DataTransferObjects.Playground;
using Application.ServiceInterfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.RepositoryInterfaces;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public BookingService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<ServiceResponse> CancelBookingAsync(int id,bool trackChanges)
        {
            var booking = await _repositoryManager.Booking.GetBookingByIdAsync(id, trackChanges);
            if (booking is null)
                return new ServiceResponse(false, $"Booking with id: {id} not found");
            booking.Status = "Cancelled";
            booking.UpdatedAt = DateTime.UtcNow;
            await _repositoryManager.SaveAsync();
            return new ServiceResponse(true, "Booking cancelled successfully");
        }

        public async Task<ServiceResponse> CreateBookingAsync(CreateBooking createBooking)
        {
            if(createBooking.EndTime <= createBooking.StartTime)
                throw new Exception("End time must be after start time");
            var isAvailable = await _repositoryManager.Booking.IsTimeSlotAvailable(createBooking.PlaygroundId,
                createBooking.BookingDate, createBooking.StartTime, createBooking.EndTime);
            if (!isAvailable)
                throw new Exception("The selected time slot is not available for booking.");

            var playground = await _repositoryManager.Playground.GetPlaygroundByIdAsync(createBooking.PlaygroundId, trackChanges: false);
            if (playground is null)
                throw new NotFoundException($"Playground with id {createBooking.PlaygroundId} not found.");

            var duration = createBooking.EndTime - createBooking.StartTime;
            var bookingEntity = _mapper.Map<Booking>(createBooking);
            bookingEntity.TotalPrice = (decimal)duration.TotalHours * playground.PricePerHour;

            _repositoryManager.Booking.CreateBooking(bookingEntity);
            await _repositoryManager.SaveAsync();
            return new ServiceResponse(true, $"Booking created successfully from {createBooking.StartTime} to {createBooking.EndTime}");
        }

        public async Task<IEnumerable<GetBookingDto>> GetAllBookingAsync(bool trackChanges)
        {
           var bookings = await _repositoryManager.Booking.GetAllBookingAsync(trackChanges);
           var bookingsDto = _mapper.Map<IEnumerable<GetBookingDto>>(bookings);
           return bookingsDto;
        }

        public async Task<GetBookingDto> GetBookingByIdAsync(int id, bool trackChanges)
        {
           var booking = await _repositoryManager.Booking.GetBookingByIdAsync(id, trackChanges);
           if(booking is null)
               throw new NotFoundException($"Booking with id: {id} not found");

           var bookingDto = _mapper.Map<GetBookingDto>(booking);
           return bookingDto;
        }

        public async Task<IEnumerable<GetOwnerBookingDto>> GetOwnerBookingsAsync(int ownerId, OwnerBookingQueryParams filters, bool trackChanges)
        {
            var bookings = await _repositoryManager.Booking.GetBookingsByOwnerAsync(ownerId, trackChanges);

            if (filters.PlaygroundId.HasValue)
                bookings = bookings.Where(b => b.PlaygroundId == filters.PlaygroundId.Value);

            if (!string.IsNullOrEmpty(filters.Status))
                bookings = bookings.Where(b => b.Status == filters.Status);

            if (filters.Date.HasValue)
                bookings = bookings.Where(b => b.BookingDate.Date == filters.Date.Value.Date);

            return _mapper.Map<IEnumerable<GetOwnerBookingDto>>(bookings);
        }

        public async Task<GetOwnerBookingDto?> GetOwnerBookingDetailsAsync(int ownerId, int bookingId, bool trackChanges)
        {
            var booking = await _repositoryManager.Booking.GetBookingByOwnerAsync(ownerId, bookingId, trackChanges);
            if (booking is null)
                return null;

            return _mapper.Map<GetOwnerBookingDto>(booking);
        }

        public async Task<ServiceResponse> ConfirmBookingAsync(int ownerId, int bookingId)
        {
            var booking = await _repositoryManager.Booking.GetBookingByOwnerAsync(ownerId, bookingId, trackChanges: true);
            if (booking is null)
                return new ServiceResponse(false, "Booking not found or you do not own the associated playground.");

            if (booking.Status != "Pending")
                return new ServiceResponse(false, $"Cannot confirm a booking with status '{booking.Status}'. Only pending bookings can be confirmed.");

            booking.Status = "Confirmed";
            booking.UpdatedAt = DateTime.UtcNow;
            await _repositoryManager.SaveAsync();
            return new ServiceResponse(true, "Booking confirmed successfully.");
        }

        public async Task<OwnerPlaygroundAnalyticsDto> GetOwnerAnalyticsAsync(int ownerId)
        {
            var statusCounts = await _repositoryManager.Booking.GetBookingStatusCountsByOwnerAsync(ownerId);
            var totalBookings = statusCounts.Values.Sum();
            var confirmedBookings = statusCounts.GetValueOrDefault("Confirmed", 0);
            var pendingBookings = statusCounts.GetValueOrDefault("Pending", 0);
            var cancelledBookings = statusCounts.GetValueOrDefault("Cancelled", 0);
            var cancellationRate = totalBookings > 0 ? (decimal)cancelledBookings / totalBookings * 100 : 0;

            var totalRevenue = await _repositoryManager.Booking.GetRevenueByOwnerAsync(ownerId, confirmedOnly: false);
            var confirmedRevenue = await _repositoryManager.Booking.GetRevenueByOwnerAsync(ownerId, confirmedOnly: true);

            var playgroundStatsRaw = await _repositoryManager.Booking.GetPlaygroundStatsByOwnerAsync(ownerId);
            var playgroundStats = new List<PlaygroundPerformanceDto>();
            foreach (var p in playgroundStatsRaw)
            {
                var props = p.GetType().GetProperties();
                playgroundStats.Add(new PlaygroundPerformanceDto
                {
                    PlaygroundId = (int)(props[0].GetValue(p) ?? 0),
                    PlaygroundName = (string)(props[1].GetValue(p) ?? ""),
                    SportType = (string)(props[2].GetValue(p) ?? ""),
                    TotalBookings = (int)(props[3].GetValue(p) ?? 0),
                    ConfirmedBookings = (int)(props[4].GetValue(p) ?? 0),
                    CancelledBookings = (int)(props[5].GetValue(p) ?? 0),
                    Revenue = (decimal)(props[6].GetValue(p) ?? 0m)
                });
            }

            var monthlyData = await _repositoryManager.Booking.GetBookingsByMonthAsync(ownerId);
            var bookingsByMonth = monthlyData.Select(kvp => new BookingsByMonthDto
            {
                Month = kvp.Key,
                Count = kvp.Value,
                Revenue = 0
            }).ToList();

            return new OwnerPlaygroundAnalyticsDto
            {
                TotalBookings = totalBookings,
                ConfirmedBookings = confirmedBookings,
                PendingBookings = pendingBookings,
                CancelledBookings = cancelledBookings,
                CancellationRate = Math.Round(cancellationRate, 1),
                TotalRevenue = totalRevenue,
                ConfirmedRevenue = confirmedRevenue,
                PlaygroundStats = playgroundStats,
                BookingsByMonth = bookingsByMonth
            };
        }
    }
}

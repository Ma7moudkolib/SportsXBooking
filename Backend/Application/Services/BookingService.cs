using Application.DataTransferObjects;
using Application.DataTransferObjects.Booking;
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
    }
}

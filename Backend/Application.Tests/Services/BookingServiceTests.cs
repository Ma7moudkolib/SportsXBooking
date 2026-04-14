using Application.DataTransferObjects.Booking;
using Application.Services;
using Application.ServiceInterfaces;
using AutoFixture;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.Repositories;
using Moq;

namespace Application.Tests.Services
{
    public class BookingServiceTests
    {
        private readonly Mock<IRepositoryManager> _repositoryManagerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly IFixture _fixture;
        private readonly BookingService _sut;

        public BookingServiceTests()
        {
            _repositoryManagerMock = new Mock<IRepositoryManager>();
            _mapperMock = new Mock<IMapper>();
            _fixture = new Fixture();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _sut = new BookingService(
                _repositoryManagerMock.Object,
                _mapperMock.Object);
        }

        #region CancelBookingAsync Tests

        [Fact]
        public async Task CancelBookingAsync_WithValidId_ShouldCancelBooking()
        {
            // Arrange
            int bookingId = 1;
            var booking = _fixture.Create<Booking>();

            _repositoryManagerMock.Setup(r => r.Booking.GetBookingByIdAsync(bookingId, true))
                .ReturnsAsync(booking);

            _repositoryManagerMock.Setup(r => r.SaveAsync())
                .Returns(Task.CompletedTask);

            // Act
            var result = await _sut.CancelBookingAsync(bookingId, true);

            // Assert
            Assert.True(result.Success);
            Assert.Equal("Booking cancelled successfully", result.Message);
            Assert.Equal("Cancelled", booking.Status);
            _repositoryManagerMock.Verify(r => r.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task CancelBookingAsync_WithInvalidId_ShouldReturnFailure()
        {
            // Arrange
            int bookingId = 999;

            _repositoryManagerMock.Setup(r => r.Booking.GetBookingByIdAsync(bookingId, true))
                .ReturnsAsync((Booking)null);

            // Act
            var result = await _sut.CancelBookingAsync(bookingId, true);

            // Assert
            Assert.False(result.Success);
            Assert.Equal($"Booking with id: {bookingId} not found", result.Message);
            _repositoryManagerMock.Verify(r => r.SaveAsync(), Times.Never);
        }

        #endregion

        #region CreateBookingAsync Tests

        [Fact]
        public async Task CreateBookingAsync_WithValidData_ShouldCreateBooking()
        {
            // Arrange
            var createBooking = new CreateBooking
            {
                PlaygroundId = 1,
                BookingDate = DateTime.Now.AddDays(1).Date,
                StartTime = new TimeSpan(10, 0, 0),
                EndTime = new TimeSpan(11, 0, 0),
            };

            var bookingEntity = _fixture.Create<Booking>();
            var bookingDto = _fixture.Create<GetBookingDto>();

            _repositoryManagerMock.Setup(r => r.Booking
                .IsTimeSlotAvailable(createBooking.PlaygroundId, createBooking.BookingDate, 
                    createBooking.StartTime, createBooking.EndTime))
                .ReturnsAsync(true);

            _mapperMock.Setup(m => m.Map<Booking>(createBooking))
                .Returns(bookingEntity);

            _mapperMock.Setup(m => m.Map<GetBookingDto>(bookingEntity))
                .Returns(bookingDto);

            _repositoryManagerMock.Setup(r => r.SaveAsync())
                .Returns(Task.CompletedTask);

            // Act
            var result = await _sut.CreateBookingAsync(createBooking);

            // Assert
            Assert.True(result.Success);
            Assert.Contains("Booking created successfully", result.Message);
            _repositoryManagerMock.Verify(r => r.Booking.CreateBooking(bookingEntity), Times.Once);
            _repositoryManagerMock.Verify(r => r.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task CreateBookingAsync_WithEndTimeBeforeStartTime_ShouldThrowException()
        {
            // Arrange
            var createBooking = new CreateBooking
            {
                PlaygroundId = 1,
                BookingDate = DateTime.Now.AddDays(1).Date,
                StartTime = new TimeSpan(11, 0, 0),
                EndTime = new TimeSpan(10, 0, 0),
            };

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _sut.CreateBookingAsync(createBooking));
        }

        [Fact]
        public async Task CreateBookingAsync_WithUnavailableTimeSlot_ShouldThrowException()
        {
            // Arrange
            var createBooking = new CreateBooking
            {
                PlaygroundId = 1,
                BookingDate = DateTime.Now.AddDays(1).Date,
                StartTime = new TimeSpan(10, 0, 0),
                EndTime = new TimeSpan(11, 0, 0),
            };

            _repositoryManagerMock.Setup(r => r.Booking
                .IsTimeSlotAvailable(createBooking.PlaygroundId, createBooking.BookingDate,
                    createBooking.StartTime, createBooking.EndTime))
                .ReturnsAsync(false);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => _sut.CreateBookingAsync(createBooking));
            Assert.Equal("The selected time slot is not available for booking.", exception.Message);
        }

        #endregion

        #region GetAllBookingAsync Tests

        [Fact]
        public async Task GetAllBookingAsync_ShouldReturnAllBookings()
        {
            // Arrange
            var bookings = _fixture.CreateMany<Booking>(3).ToList();
            var bookingDtos = _fixture.CreateMany<GetBookingDto>(3);

            _repositoryManagerMock.Setup(r => r.Booking.GetAllBookingAsync(false))
                .ReturnsAsync(bookings);

            _mapperMock.Setup(m => m.Map<IEnumerable<GetBookingDto>>(bookings))
                .Returns(bookingDtos);

            // Act
            var result = await _sut.GetAllBookingAsync(false);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public async Task GetAllBookingAsync_WithEmptyDatabase_ShouldReturnEmptyList()
        {
            // Arrange
            var bookings = new List<Booking>();

            _repositoryManagerMock.Setup(r => r.Booking.GetAllBookingAsync(false))
                .ReturnsAsync(bookings);

            _mapperMock.Setup(m => m.Map<IEnumerable<GetBookingDto>>(bookings))
                .Returns(new List<GetBookingDto>());

            // Act
            var result = await _sut.GetAllBookingAsync(false);

            // Assert
            Assert.Empty(result);
        }

        #endregion

        #region GetBookingByIdAsync Tests

        [Fact]
        public async Task GetBookingByIdAsync_WithValidId_ShouldReturnBooking()
        {
            // Arrange
            int bookingId = 1;
            var booking = _fixture.Create<Booking>();
            var bookingDto = _fixture.Create<GetBookingDto>();

            _repositoryManagerMock.Setup(r => r.Booking.GetBookingByIdAsync(bookingId, false))
                .ReturnsAsync(booking);

            _mapperMock.Setup(m => m.Map<GetBookingDto>(booking))
                .Returns(bookingDto);

            // Act
            var result = await _sut.GetBookingByIdAsync(bookingId, false);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(bookingDto, result);
        }

        [Fact]
        public async Task GetBookingByIdAsync_WithInvalidId_ShouldThrowNotFoundException()
        {
            // Arrange
            int bookingId = 999;

            _repositoryManagerMock.Setup(r => r.Booking.GetBookingByIdAsync(bookingId, false))
                .ReturnsAsync((Booking)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _sut.GetBookingByIdAsync(bookingId, false));
        }

        #endregion
    }
}
using Application.DataTransferObjects.Payment;
using Application.Services;
using AutoFixture;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.Repositories;
using Moq;
using Xunit;

namespace Application.Tests.Services
{
    public class PaymentServiceTests
    {
        private readonly Mock<IRepositoryManager> _repositoryManagerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly IFixture _fixture;
        private readonly PaymentService _sut;

        public PaymentServiceTests()
        {
            _repositoryManagerMock = new Mock<IRepositoryManager>();
            _mapperMock = new Mock<IMapper>();
            _fixture = new Fixture();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _sut = new PaymentService(
                _repositoryManagerMock.Object,
                _mapperMock.Object);
        }

        #region GetPaymentByBookingIdAsync Tests

        [Fact]
        public async Task GetPaymentByBookingIdAsync_WithValidBookingId_ShouldReturnPayment()
        {
            // Arrange
            int bookingId = 1;
            var booking = _fixture.Create<Booking>();
            var payment = _fixture.Create<Payment>();
            var paymentDto = _fixture.Create<GetPaymentDto>();

            _repositoryManagerMock.Setup(r => r.Booking.GetBookingByIdAsync(bookingId, false))
                .ReturnsAsync(booking);

            _repositoryManagerMock.Setup(r => r.Payment.GetPaymentByBookingIdAsync(bookingId, false))
                .ReturnsAsync(payment);

            _mapperMock.Setup(m => m.Map<GetPaymentDto>(payment))
                .Returns(paymentDto);

            // Act
            var result = await _sut.GetPaymentByBookingIdAsync(bookingId, false);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(paymentDto, result);
        }

        [Fact]
        public async Task GetPaymentByBookingIdAsync_WithInvalidBookingId_ShouldThrowNotFoundException()
        {
            // Arrange
            int bookingId = 999;

            _repositoryManagerMock.Setup(r => r.Booking.GetBookingByIdAsync(bookingId, false))
                .ReturnsAsync((Booking)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() =>
                _sut.GetPaymentByBookingIdAsync(bookingId, false));

            Assert.Equal($"Booking with id: {bookingId} does not exist.", exception.Message);
            _repositoryManagerMock.Verify(r => r.Payment.GetPaymentByBookingIdAsync(It.IsAny<int>(), It.IsAny<bool>()), Times.Never);
        }

        [Fact]
        public async Task GetPaymentByBookingIdAsync_WithValidBookingButNoPayment_ShouldReturnNullPayment()
        {
            // Arrange
            int bookingId = 1;
            var booking = _fixture.Create<Booking>();

            _repositoryManagerMock.Setup(r => r.Booking.GetBookingByIdAsync(bookingId, false))
                .ReturnsAsync(booking);

            _repositoryManagerMock.Setup(r => r.Payment.GetPaymentByBookingIdAsync(bookingId, false))
                .ReturnsAsync((Payment)null);

            _mapperMock.Setup(m => m.Map<GetPaymentDto>(null as Payment))
                .Returns((GetPaymentDto)null);

            // Act
            var result = await _sut.GetPaymentByBookingIdAsync(bookingId, false);

            // Assert
            Assert.Null(result);
        }

        #endregion
    }
}
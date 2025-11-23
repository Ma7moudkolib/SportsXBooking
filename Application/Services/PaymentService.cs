using Application.DataTransferObjects.Payment;
using Application.ServiceInterfaces;
using AutoMapper;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public PaymentService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<GetPaymentDto> GetPaymentByBookingIdAsync(int bookingId, bool trackChanges)
        {
            var bookingIdExists = await _repositoryManager.Booking.GetBookingByIdAsync(bookingId, trackChanges);
            if (bookingIdExists == null)
                throw new KeyNotFoundException($"Booking with id: {bookingId} does not exist.");

            var paymentEntity = await _repositoryManager.Payment.GetPaymentByBookingIdAsync(bookingId, trackChanges);
            var paymentDto = _mapper.Map<GetPaymentDto>(paymentEntity);
            return paymentDto;
        }
    }
}

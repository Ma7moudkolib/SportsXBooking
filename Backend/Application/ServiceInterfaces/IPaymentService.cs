using Application.DataTransferObjects.Payment;

namespace Application.ServiceInterfaces
{
    public interface IPaymentService
    {
        Task<GetPaymentDto> GetPaymentByBookingIdAsync(int bookingId, bool trackChanges);
    }
}

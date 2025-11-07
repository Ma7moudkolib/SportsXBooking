using Domain.Entities;

namespace Domain.RepositoryInterfaces
{
    public interface IPaymentRepository
    {
        Task<Payment> GetPaymentByBookingIdAsync(int bookingId, bool trackChanges);
    }
}

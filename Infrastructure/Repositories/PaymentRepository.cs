using Domain.Entities;
using Domain.RepositoryInterfaces;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PaymentRepository : RepositoryBase<Payment> , IPaymentRepository
    {
        public PaymentRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }

        public async Task<Payment> GetPaymentByBookingIdAsync(int bookingId, bool trackChanges) =>
            await FindByCondition(b=>b.BookingId == bookingId, trackChanges).SingleOrDefaultAsync()!;
    }
    
}

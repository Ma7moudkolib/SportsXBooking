using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasData(new Payment
            {
                PaymentId = 1,
                BookingId = 1,
                Amount = 300,
                PaymentMethod = "Cash",
                PaymentStatus = "Paid",
                TransactionId = "TXN-DEMO-111",
                TransactionDate = new DateTime(2025, 1, 1, 10, 0, 0)
            });
        }
    }
}

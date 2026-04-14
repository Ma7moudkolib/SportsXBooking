using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasData(new Booking
            {
                BookingId = 1,
                PlayerId = 3,
                PlaygroundId = 1,
                BookingDate = new DateTime(2025, 1, 1, 10, 0, 0),
                StartTime = new TimeSpan(14, 0, 0),
                EndTime = new TimeSpan(16, 0, 0),
                TotalPrice = 300,
                Status = "Confirmed",
                CreatedAt = new DateTime(2025, 1, 1, 10, 0, 0),
                UpdatedAt = new DateTime(2025, 1, 1, 10, 0, 0)
            });
        }
    }
}

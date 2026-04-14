using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasData(
                new Review
                {
                    ReviewId = 1,
                    PlayerId = 3,
                    PlaygroundId = 1,
                    Rating = 5,
                    Comment = "Amazing playground, very clean!",
                    IsApproved = true,
                    CreatedAt = new DateTime(2025, 1, 1, 10, 0, 0)
                }
            );
        }
    }
}

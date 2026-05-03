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
                    PlayerId = 14,
                    PlaygroundId = 1,
                    Rating = 4,
                    Comment = "Great experience at venue 1. Review #1",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 2, 1, 15, 0, 0)
                },
                new Review
                {
                    ReviewId = 2,
                    PlayerId = 15,
                    PlaygroundId = 2,
                    Rating = 5,
                    Comment = "Great experience at venue 2. Review #2",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 2, 2, 15, 0, 0)
                },
                new Review
                {
                    ReviewId = 3,
                    PlayerId = 16,
                    PlaygroundId = 3,
                    Rating = 3,
                    Comment = "Great experience at venue 3. Review #3",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 2, 3, 15, 0, 0)
                },
                new Review
                {
                    ReviewId = 4,
                    PlayerId = 17,
                    PlaygroundId = 4,
                    Rating = 4,
                    Comment = "Great experience at venue 4. Review #4",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 2, 4, 15, 0, 0)
                },
                new Review
                {
                    ReviewId = 5,
                    PlayerId = 18,
                    PlaygroundId = 5,
                    Rating = 5,
                    Comment = "Great experience at venue 5. Review #5",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 2, 5, 15, 0, 0)
                },
                new Review
                {
                    ReviewId = 6,
                    PlayerId = 19,
                    PlaygroundId = 6,
                    Rating = 3,
                    Comment = "Great experience at venue 6. Review #6",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 2, 6, 15, 0, 0)
                },
                new Review
                {
                    ReviewId = 7,
                    PlayerId = 20,
                    PlaygroundId = 7,
                    Rating = 4,
                    Comment = "Great experience at venue 7. Review #7",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 2, 7, 15, 0, 0)
                },
                new Review
                {
                    ReviewId = 8,
                    PlayerId = 21,
                    PlaygroundId = 8,
                    Rating = 5,
                    Comment = "Great experience at venue 8. Review #8",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 2, 8, 15, 0, 0)
                },
                new Review
                {
                    ReviewId = 9,
                    PlayerId = 22,
                    PlaygroundId = 9,
                    Rating = 3,
                    Comment = "Great experience at venue 9. Review #9",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 2, 9, 15, 0, 0)
                },
                new Review
                {
                    ReviewId = 10,
                    PlayerId = 23,
                    PlaygroundId = 10,
                    Rating = 4,
                    Comment = "Great experience at venue 10. Review #10",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 2, 10, 15, 0, 0)
                },
                new Review
                {
                    ReviewId = 11,
                    PlayerId = 24,
                    PlaygroundId = 11,
                    Rating = 5,
                    Comment = "Great experience at venue 11. Review #11",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 2, 11, 15, 0, 0)
                },
                new Review
                {
                    ReviewId = 12,
                    PlayerId = 25,
                    PlaygroundId = 12,
                    Rating = 3,
                    Comment = "Great experience at venue 12. Review #12",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 2, 12, 15, 0, 0)
                },
                new Review
                {
                    ReviewId = 13,
                    PlayerId = 26,
                    PlaygroundId = 13,
                    Rating = 4,
                    Comment = "Great experience at venue 13. Review #13",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 2, 13, 15, 0, 0)
                },
                new Review
                {
                    ReviewId = 14,
                    PlayerId = 27,
                    PlaygroundId = 14,
                    Rating = 5,
                    Comment = "Great experience at venue 14. Review #14",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 2, 14, 15, 0, 0)
                },
                new Review
                {
                    ReviewId = 15,
                    PlayerId = 28,
                    PlaygroundId = 15,
                    Rating = 3,
                    Comment = "Great experience at venue 15. Review #15",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 2, 15, 15, 0, 0)
                },
                new Review
                {
                    ReviewId = 16,
                    PlayerId = 29,
                    PlaygroundId = 1,
                    Rating = 4,
                    Comment = "Great experience at venue 1. Review #16",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 2, 16, 15, 0, 0)
                },
                new Review
                {
                    ReviewId = 17,
                    PlayerId = 30,
                    PlaygroundId = 2,
                    Rating = 5,
                    Comment = "Great experience at venue 2. Review #17",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 2, 17, 15, 0, 0)
                },
                new Review
                {
                    ReviewId = 18,
                    PlayerId = 31,
                    PlaygroundId = 3,
                    Rating = 3,
                    Comment = "Great experience at venue 3. Review #18",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 2, 18, 15, 0, 0)
                },
                new Review
                {
                    ReviewId = 19,
                    PlayerId = 32,
                    PlaygroundId = 4,
                    Rating = 4,
                    Comment = "Great experience at venue 4. Review #19",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 2, 19, 15, 0, 0)
                },
                new Review
                {
                    ReviewId = 20,
                    PlayerId = 33,
                    PlaygroundId = 5,
                    Rating = 5,
                    Comment = "Great experience at venue 5. Review #20",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 2, 20, 15, 0, 0)
                },
                new Review
                {
                    ReviewId = 21,
                    PlayerId = 34,
                    PlaygroundId = 6,
                    Rating = 3,
                    Comment = "Great experience at venue 6. Review #21",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 2, 21, 15, 0, 0)
                },
                new Review
                {
                    ReviewId = 22,
                    PlayerId = 35,
                    PlaygroundId = 7,
                    Rating = 4,
                    Comment = "Great experience at venue 7. Review #22",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 2, 22, 15, 0, 0)
                },
                new Review
                {
                    ReviewId = 23,
                    PlayerId = 36,
                    PlaygroundId = 8,
                    Rating = 5,
                    Comment = "Great experience at venue 8. Review #23",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 2, 23, 15, 0, 0)
                },
                new Review
                {
                    ReviewId = 24,
                    PlayerId = 37,
                    PlaygroundId = 9,
                    Rating = 3,
                    Comment = "Great experience at venue 9. Review #24",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 2, 24, 15, 0, 0)
                },
                new Review
                {
                    ReviewId = 25,
                    PlayerId = 38,
                    PlaygroundId = 10,
                    Rating = 4,
                    Comment = "Great experience at venue 10. Review #25",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 2, 25, 15, 0, 0)
                },
                new Review
                {
                    ReviewId = 26,
                    PlayerId = 39,
                    PlaygroundId = 11,
                    Rating = 5,
                    Comment = "Great experience at venue 11. Review #26",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 2, 26, 15, 0, 0)
                },
                new Review
                {
                    ReviewId = 27,
                    PlayerId = 40,
                    PlaygroundId = 12,
                    Rating = 3,
                    Comment = "Great experience at venue 12. Review #27",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 2, 27, 15, 0, 0)
                },
                new Review
                {
                    ReviewId = 28,
                    PlayerId = 41,
                    PlaygroundId = 13,
                    Rating = 4,
                    Comment = "Great experience at venue 13. Review #28",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 2, 28, 15, 0, 0)
                },
                new Review
                {
                    ReviewId = 29,
                    PlayerId = 42,
                    PlaygroundId = 14,
                    Rating = 5,
                    Comment = "Great experience at venue 14. Review #29",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 2, 1, 15, 0, 0)
                },
                new Review
                {
                    ReviewId = 30,
                    PlayerId = 43,
                    PlaygroundId = 15,
                    Rating = 3,
                    Comment = "Great experience at venue 15. Review #30",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 2, 2, 15, 0, 0)
                },
                new Review
                {
                    ReviewId = 31,
                    PlayerId = 44,
                    PlaygroundId = 1,
                    Rating = 4,
                    Comment = "Great experience at venue 1. Review #31",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 2, 3, 15, 0, 0)
                },
                new Review
                {
                    ReviewId = 32,
                    PlayerId = 45,
                    PlaygroundId = 2,
                    Rating = 5,
                    Comment = "Great experience at venue 2. Review #32",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 2, 4, 15, 0, 0)
                },
                new Review
                {
                    ReviewId = 33,
                    PlayerId = 46,
                    PlaygroundId = 3,
                    Rating = 3,
                    Comment = "Great experience at venue 3. Review #33",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 2, 5, 15, 0, 0)
                },
                new Review
                {
                    ReviewId = 34,
                    PlayerId = 47,
                    PlaygroundId = 4,
                    Rating = 4,
                    Comment = "Great experience at venue 4. Review #34",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 2, 6, 15, 0, 0)
                },
                new Review
                {
                    ReviewId = 35,
                    PlayerId = 48,
                    PlaygroundId = 5,
                    Rating = 5,
                    Comment = "Great experience at venue 5. Review #35",
                    IsApproved = true,
                    CreatedAt = new DateTime(2026, 2, 7, 15, 0, 0)
                }
            );
        }
    }
}

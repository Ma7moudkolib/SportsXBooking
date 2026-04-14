using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class PlaygroundConfiguration : IEntityTypeConfiguration<Playground>
    {
        public void Configure(EntityTypeBuilder<Playground> builder)
        {
            builder.HasData(new Playground
            {
                PlaygroundId = 1,
                OwnerId = 2,
                Name = "Green Field Playground",
                Location = "Cairo, Nasr City",
                SportType = "Football",
                PricePerHour = 150,
                ImageUrl = "https://example.com/green-field.jpg",
                IsAvailable = true,
                CreatedAt = new DateTime(2025, 1, 1, 10, 0, 0)
            },
            new Playground
            {
                PlaygroundId = 2,
                OwnerId = 2,
                Name = "Elite Tennis Court",
                Location = "Alexandria, Smouha",
                SportType = "Tennis",
                PricePerHour = 200,
                ImageUrl = "https://example.com/tennis-court.jpg",
                IsAvailable = true,
                CreatedAt = new DateTime(2025, 1, 1, 10, 0, 0)
            });
        }
    }
}

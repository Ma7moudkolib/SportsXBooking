using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class PlaygroundConfiguration : IEntityTypeConfiguration<Playground>
    {
        public void Configure(EntityTypeBuilder<Playground> builder)
        {
            builder.HasData(
                new Playground
                {
                    PlaygroundId = 1,
                    OwnerId = 4,
                    Name = "Padel Arena 1",
                    Location = "Cairo, Nasr City",
                    SportType = "Padel",
                    PricePerHour = 130,
                    ImageUrl = "https://picsum.photos/seed/playground1/1200/700",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 2,
                    OwnerId = 5,
                    Name = "Tennis Arena 2",
                    Location = "Cairo, Maadi",
                    SportType = "Tennis",
                    PricePerHour = 140,
                    ImageUrl = "https://picsum.photos/seed/playground2/1200/700",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 3,
                    OwnerId = 6,
                    Name = "Football Arena 3",
                    Location = "Cairo, Zamalek",
                    SportType = "Football",
                    PricePerHour = 150,
                    ImageUrl = "https://picsum.photos/seed/playground3/1200/700",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 4,
                    OwnerId = 7,
                    Name = "Padel Arena 4",
                    Location = "Alexandria, Smouha",
                    SportType = "Padel",
                    PricePerHour = 160,
                    ImageUrl = "https://picsum.photos/seed/playground4/1200/700",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 5,
                    OwnerId = 8,
                    Name = "Tennis Arena 5",
                    Location = "Giza, 6th October",
                    SportType = "Tennis",
                    PricePerHour = 170,
                    ImageUrl = "https://picsum.photos/seed/playground5/1200/700",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 6,
                    OwnerId = 9,
                    Name = "Football Arena 6",
                    Location = "Cairo, Nasr City",
                    SportType = "Football",
                    PricePerHour = 180,
                    ImageUrl = "https://picsum.photos/seed/playground6/1200/700",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 7,
                    OwnerId = 10,
                    Name = "Padel Arena 7",
                    Location = "Cairo, Maadi",
                    SportType = "Padel",
                    PricePerHour = 190,
                    ImageUrl = "https://picsum.photos/seed/playground7/1200/700",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 8,
                    OwnerId = 11,
                    Name = "Tennis Arena 8",
                    Location = "Cairo, Zamalek",
                    SportType = "Tennis",
                    PricePerHour = 200,
                    ImageUrl = "https://picsum.photos/seed/playground8/1200/700",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 9,
                    OwnerId = 12,
                    Name = "Football Arena 9",
                    Location = "Alexandria, Smouha",
                    SportType = "Football",
                    PricePerHour = 210,
                    ImageUrl = "https://picsum.photos/seed/playground9/1200/700",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 10,
                    OwnerId = 13,
                    Name = "Padel Arena 10",
                    Location = "Giza, 6th October",
                    SportType = "Padel",
                    PricePerHour = 220,
                    ImageUrl = "https://picsum.photos/seed/playground10/1200/700",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 11,
                    OwnerId = 4,
                    Name = "Tennis Arena 11",
                    Location = "Cairo, Nasr City",
                    SportType = "Tennis",
                    PricePerHour = 230,
                    ImageUrl = "https://picsum.photos/seed/playground11/1200/700",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 12,
                    OwnerId = 5,
                    Name = "Football Arena 12",
                    Location = "Cairo, Maadi",
                    SportType = "Football",
                    PricePerHour = 240,
                    ImageUrl = "https://picsum.photos/seed/playground12/1200/700",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 13,
                    OwnerId = 6,
                    Name = "Padel Arena 13",
                    Location = "Cairo, Zamalek",
                    SportType = "Padel",
                    PricePerHour = 250,
                    ImageUrl = "https://picsum.photos/seed/playground13/1200/700",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 14,
                    OwnerId = 7,
                    Name = "Tennis Arena 14",
                    Location = "Alexandria, Smouha",
                    SportType = "Tennis",
                    PricePerHour = 260,
                    ImageUrl = "https://picsum.photos/seed/playground14/1200/700",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 15,
                    OwnerId = 8,
                    Name = "Football Arena 15",
                    Location = "Giza, 6th October",
                    SportType = "Football",
                    PricePerHour = 270,
                    ImageUrl = "https://picsum.photos/seed/playground15/1200/700",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                }
            );
        }
    }
}

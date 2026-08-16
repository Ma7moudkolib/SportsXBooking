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
                    ImageUrl = "https://images.unsplash.com/photo-1658491830143-72808ca237e3?auto=format&fit=crop&w=1200&h=700&q=80",
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
                    ImageUrl = "https://images.unsplash.com/photo-1635089877059-500eb3720c61?auto=format&fit=crop&w=1200&h=700&q=80",
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
                    ImageUrl = "https://images.unsplash.com/photo-1575279355017-5afe464a4fa1?auto=format&fit=crop&w=1200&h=700&q=80",
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
                    ImageUrl = "https://images.unsplash.com/photo-1658491830143-72808ca237e3?auto=format&fit=crop&w=1200&h=700&q=80",
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
                    ImageUrl = "https://images.unsplash.com/photo-1635089877059-500eb3720c61?auto=format&fit=crop&w=1200&h=700&q=80",
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
                    ImageUrl = "https://images.unsplash.com/photo-1575279355017-5afe464a4fa1?auto=format&fit=crop&w=1200&h=700&q=80",
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
                    ImageUrl = "https://images.unsplash.com/photo-1658491830143-72808ca237e3?auto=format&fit=crop&w=1200&h=700&q=80",
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
                    ImageUrl = "https://images.unsplash.com/photo-1635089877059-500eb3720c61?auto=format&fit=crop&w=1200&h=700&q=80",
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
                    ImageUrl = "https://images.unsplash.com/photo-1575279355017-5afe464a4fa1?auto=format&fit=crop&w=1200&h=700&q=80",
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
                    ImageUrl = "https://images.unsplash.com/photo-1658491830143-72808ca237e3?auto=format&fit=crop&w=1200&h=700&q=80",
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
                    ImageUrl = "https://images.unsplash.com/photo-1635089877059-500eb3720c61?auto=format&fit=crop&w=1200&h=700&q=80",
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
                    ImageUrl = "https://images.unsplash.com/photo-1575279355017-5afe464a4fa1?auto=format&fit=crop&w=1200&h=700&q=80",
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
                    ImageUrl = "https://images.unsplash.com/photo-1658491830143-72808ca237e3?auto=format&fit=crop&w=1200&h=700&q=80",
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
                    ImageUrl = "https://images.unsplash.com/photo-1635089877059-500eb3720c61?auto=format&fit=crop&w=1200&h=700&q=80",
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
                    ImageUrl = "https://images.unsplash.com/photo-1575279355017-5afe464a4fa1?auto=format&fit=crop&w=1200&h=700&q=80",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 16,
                    OwnerId = 9,
                    Name = "Padel Arena 16",
                    Location = "Cairo, Nasr City",
                    SportType = "Padel",
                    PricePerHour = 280,
                    ImageUrl = "https://images.unsplash.com/photo-1658491830143-72808ca237e3?auto=format&fit=crop&w=1200&h=700&q=80",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 17,
                    OwnerId = 10,
                    Name = "Tennis Arena 17",
                    Location = "Cairo, Maadi",
                    SportType = "Tennis",
                    PricePerHour = 290,
                    ImageUrl = "https://images.unsplash.com/photo-1635089877059-500eb3720c61?auto=format&fit=crop&w=1200&h=700&q=80",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 18,
                    OwnerId = 11,
                    Name = "Football Arena 18",
                    Location = "Cairo, Zamalek",
                    SportType = "Football",
                    PricePerHour = 300,
                    ImageUrl = "https://images.unsplash.com/photo-1575279355017-5afe464a4fa1?auto=format&fit=crop&w=1200&h=700&q=80",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 19,
                    OwnerId = 12,
                    Name = "Padel Arena 19",
                    Location = "Alexandria, Smouha",
                    SportType = "Padel",
                    PricePerHour = 310,
                    ImageUrl = "https://images.unsplash.com/photo-1658491830143-72808ca237e3?auto=format&fit=crop&w=1200&h=700&q=80",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 20,
                    OwnerId = 13,
                    Name = "Tennis Arena 20",
                    Location = "Giza, 6th October",
                    SportType = "Tennis",
                    PricePerHour = 320,
                    ImageUrl = "https://images.unsplash.com/photo-1635089877059-500eb3720c61?auto=format&fit=crop&w=1200&h=700&q=80",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 21,
                    OwnerId = 4,
                    Name = "Football Arena 21",
                    Location = "Cairo, Nasr City",
                    SportType = "Football",
                    PricePerHour = 330,
                    ImageUrl = "https://images.unsplash.com/photo-1575279355017-5afe464a4fa1?auto=format&fit=crop&w=1200&h=700&q=80",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 22,
                    OwnerId = 5,
                    Name = "Padel Arena 22",
                    Location = "Cairo, Maadi",
                    SportType = "Padel",
                    PricePerHour = 340,
                    ImageUrl = "https://images.unsplash.com/photo-1658491830143-72808ca237e3?auto=format&fit=crop&w=1200&h=700&q=80",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 23,
                    OwnerId = 6,
                    Name = "Tennis Arena 23",
                    Location = "Cairo, Zamalek",
                    SportType = "Tennis",
                    PricePerHour = 350,
                    ImageUrl = "https://images.unsplash.com/photo-1635089877059-500eb3720c61?auto=format&fit=crop&w=1200&h=700&q=80",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 24,
                    OwnerId = 7,
                    Name = "Football Arena 24",
                    Location = "Alexandria, Smouha",
                    SportType = "Football",
                    PricePerHour = 360,
                    ImageUrl = "https://images.unsplash.com/photo-1575279355017-5afe464a4fa1?auto=format&fit=crop&w=1200&h=700&q=80",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 25,
                    OwnerId = 8,
                    Name = "Padel Arena 25",
                    Location = "Giza, 6th October",
                    SportType = "Padel",
                    PricePerHour = 370,
                    ImageUrl = "https://images.unsplash.com/photo-1658491830143-72808ca237e3?auto=format&fit=crop&w=1200&h=700&q=80",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 26,
                    OwnerId = 9,
                    Name = "Tennis Arena 26",
                    Location = "Cairo, Nasr City",
                    SportType = "Tennis",
                    PricePerHour = 380,
                    ImageUrl = "https://images.unsplash.com/photo-1635089877059-500eb3720c61?auto=format&fit=crop&w=1200&h=700&q=80",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 27,
                    OwnerId = 10,
                    Name = "Football Arena 27",
                    Location = "Cairo, Maadi",
                    SportType = "Football",
                    PricePerHour = 390,
                    ImageUrl = "https://images.unsplash.com/photo-1575279355017-5afe464a4fa1?auto=format&fit=crop&w=1200&h=700&q=80",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 28,
                    OwnerId = 11,
                    Name = "Padel Arena 28",
                    Location = "Cairo, Zamalek",
                    SportType = "Padel",
                    PricePerHour = 400,
                    ImageUrl = "https://images.unsplash.com/photo-1658491830143-72808ca237e3?auto=format&fit=crop&w=1200&h=700&q=80",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 29,
                    OwnerId = 12,
                    Name = "Tennis Arena 29",
                    Location = "Alexandria, Smouha",
                    SportType = "Tennis",
                    PricePerHour = 410,
                    ImageUrl = "https://images.unsplash.com/photo-1635089877059-500eb3720c61?auto=format&fit=crop&w=1200&h=700&q=80",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 30,
                    OwnerId = 13,
                    Name = "Football Arena 30",
                    Location = "Giza, 6th October",
                    SportType = "Football",
                    PricePerHour = 420,
                    ImageUrl = "https://images.unsplash.com/photo-1575279355017-5afe464a4fa1?auto=format&fit=crop&w=1200&h=700&q=80",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 31,
                    OwnerId = 4,
                    Name = "Padel Arena 31",
                    Location = "Cairo, Nasr City",
                    SportType = "Padel",
                    PricePerHour = 430,
                    ImageUrl = "https://images.unsplash.com/photo-1658491830143-72808ca237e3?auto=format&fit=crop&w=1200&h=700&q=80",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 32,
                    OwnerId = 5,
                    Name = "Tennis Arena 32",
                    Location = "Cairo, Maadi",
                    SportType = "Tennis",
                    PricePerHour = 440,
                    ImageUrl = "https://images.unsplash.com/photo-1635089877059-500eb3720c61?auto=format&fit=crop&w=1200&h=700&q=80",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 33,
                    OwnerId = 6,
                    Name = "Football Arena 33",
                    Location = "Cairo, Zamalek",
                    SportType = "Football",
                    PricePerHour = 450,
                    ImageUrl = "https://images.unsplash.com/photo-1575279355017-5afe464a4fa1?auto=format&fit=crop&w=1200&h=700&q=80",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 34,
                    OwnerId = 7,
                    Name = "Padel Arena 34",
                    Location = "Alexandria, Smouha",
                    SportType = "Padel",
                    PricePerHour = 460,
                    ImageUrl = "https://images.unsplash.com/photo-1658491830143-72808ca237e3?auto=format&fit=crop&w=1200&h=700&q=80",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 35,
                    OwnerId = 8,
                    Name = "Tennis Arena 35",
                    Location = "Giza, 6th October",
                    SportType = "Tennis",
                    PricePerHour = 470,
                    ImageUrl = "https://images.unsplash.com/photo-1635089877059-500eb3720c61?auto=format&fit=crop&w=1200&h=700&q=80",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 36,
                    OwnerId = 9,
                    Name = "Football Arena 36",
                    Location = "Cairo, Nasr City",
                    SportType = "Football",
                    PricePerHour = 480,
                    ImageUrl = "https://images.unsplash.com/photo-1575279355017-5afe464a4fa1?auto=format&fit=crop&w=1200&h=700&q=80",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 37,
                    OwnerId = 10,
                    Name = "Padel Arena 37",
                    Location = "Cairo, Maadi",
                    SportType = "Padel",
                    PricePerHour = 490,
                    ImageUrl = "https://images.unsplash.com/photo-1658491830143-72808ca237e3?auto=format&fit=crop&w=1200&h=700&q=80",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 38,
                    OwnerId = 11,
                    Name = "Tennis Arena 38",
                    Location = "Cairo, Zamalek",
                    SportType = "Tennis",
                    PricePerHour = 500,
                    ImageUrl = "https://images.unsplash.com/photo-1635089877059-500eb3720c61?auto=format&fit=crop&w=1200&h=700&q=80",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 39,
                    OwnerId = 12,
                    Name = "Football Arena 39",
                    Location = "Alexandria, Smouha",
                    SportType = "Football",
                    PricePerHour = 510,
                    ImageUrl = "https://images.unsplash.com/photo-1575279355017-5afe464a4fa1?auto=format&fit=crop&w=1200&h=700&q=80",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Playground
                {
                    PlaygroundId = 40,
                    OwnerId = 13,
                    Name = "Padel Arena 40",
                    Location = "Giza, 6th October",
                    SportType = "Padel",
                    PricePerHour = 520,
                    ImageUrl = "https://images.unsplash.com/photo-1658491830143-72808ca237e3?auto=format&fit=crop&w=1200&h=700&q=80",
                    IsAvailable = true,
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                }
            );
        }
    }
}
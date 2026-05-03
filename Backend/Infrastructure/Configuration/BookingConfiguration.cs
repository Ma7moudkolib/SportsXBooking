using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasData(
                new Booking
                {
                    BookingId = 1,
                    PlayerId = 14,
                    PlaygroundId = 1,
                    BookingDate = new DateTime(2026, 2, 1, 0, 0, 0),
                    StartTime = new TimeSpan(8, 0, 0),
                    EndTime = new TimeSpan(9, 0, 0),
                    TotalPrice = 198,
                    Status = "Pending",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 2,
                    PlayerId = 15,
                    PlaygroundId = 2,
                    BookingDate = new DateTime(2026, 2, 2, 0, 0, 0),
                    StartTime = new TimeSpan(9, 0, 0),
                    EndTime = new TimeSpan(11, 0, 0),
                    TotalPrice = 146,
                    Status = "Pending",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 3,
                    PlayerId = 16,
                    PlaygroundId = 3,
                    BookingDate = new DateTime(2026, 2, 3, 0, 0, 0),
                    StartTime = new TimeSpan(10, 0, 0),
                    EndTime = new TimeSpan(11, 0, 0),
                    TotalPrice = 214,
                    Status = "Confirmed",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 4,
                    PlayerId = 17,
                    PlaygroundId = 4,
                    BookingDate = new DateTime(2026, 2, 4, 0, 0, 0),
                    StartTime = new TimeSpan(11, 0, 0),
                    EndTime = new TimeSpan(13, 0, 0),
                    TotalPrice = 162,
                    Status = "Pending",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 5,
                    PlayerId = 18,
                    PlaygroundId = 5,
                    BookingDate = new DateTime(2026, 2, 5, 0, 0, 0),
                    StartTime = new TimeSpan(12, 0, 0),
                    EndTime = new TimeSpan(13, 0, 0),
                    TotalPrice = 230,
                    Status = "Pending",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 6,
                    PlayerId = 19,
                    PlaygroundId = 6,
                    BookingDate = new DateTime(2026, 2, 6, 0, 0, 0),
                    StartTime = new TimeSpan(13, 0, 0),
                    EndTime = new TimeSpan(15, 0, 0),
                    TotalPrice = 178,
                    Status = "Confirmed",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 7,
                    PlayerId = 20,
                    PlaygroundId = 7,
                    BookingDate = new DateTime(2026, 2, 7, 0, 0, 0),
                    StartTime = new TimeSpan(14, 0, 0),
                    EndTime = new TimeSpan(15, 0, 0),
                    TotalPrice = 246,
                    Status = "Cancelled",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 8,
                    PlayerId = 21,
                    PlaygroundId = 8,
                    BookingDate = new DateTime(2026, 2, 8, 0, 0, 0),
                    StartTime = new TimeSpan(15, 0, 0),
                    EndTime = new TimeSpan(17, 0, 0),
                    TotalPrice = 194,
                    Status = "Pending",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 9,
                    PlayerId = 22,
                    PlaygroundId = 9,
                    BookingDate = new DateTime(2026, 2, 9, 0, 0, 0),
                    StartTime = new TimeSpan(16, 0, 0),
                    EndTime = new TimeSpan(17, 0, 0),
                    TotalPrice = 262,
                    Status = "Confirmed",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 10,
                    PlayerId = 23,
                    PlaygroundId = 10,
                    BookingDate = new DateTime(2026, 2, 10, 0, 0, 0),
                    StartTime = new TimeSpan(17, 0, 0),
                    EndTime = new TimeSpan(19, 0, 0),
                    TotalPrice = 210,
                    Status = "Pending",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 11,
                    PlayerId = 24,
                    PlaygroundId = 11,
                    BookingDate = new DateTime(2026, 2, 11, 0, 0, 0),
                    StartTime = new TimeSpan(8, 0, 0),
                    EndTime = new TimeSpan(9, 0, 0),
                    TotalPrice = 278,
                    Status = "Pending",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 12,
                    PlayerId = 25,
                    PlaygroundId = 12,
                    BookingDate = new DateTime(2026, 2, 12, 0, 0, 0),
                    StartTime = new TimeSpan(9, 0, 0),
                    EndTime = new TimeSpan(11, 0, 0),
                    TotalPrice = 226,
                    Status = "Confirmed",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 13,
                    PlayerId = 26,
                    PlaygroundId = 13,
                    BookingDate = new DateTime(2026, 2, 13, 0, 0, 0),
                    StartTime = new TimeSpan(10, 0, 0),
                    EndTime = new TimeSpan(11, 0, 0),
                    TotalPrice = 294,
                    Status = "Pending",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 14,
                    PlayerId = 27,
                    PlaygroundId = 14,
                    BookingDate = new DateTime(2026, 2, 14, 0, 0, 0),
                    StartTime = new TimeSpan(11, 0, 0),
                    EndTime = new TimeSpan(13, 0, 0),
                    TotalPrice = 242,
                    Status = "Cancelled",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 15,
                    PlayerId = 28,
                    PlaygroundId = 15,
                    BookingDate = new DateTime(2026, 2, 15, 0, 0, 0),
                    StartTime = new TimeSpan(12, 0, 0),
                    EndTime = new TimeSpan(13, 0, 0),
                    TotalPrice = 310,
                    Status = "Confirmed",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 16,
                    PlayerId = 29,
                    PlaygroundId = 1,
                    BookingDate = new DateTime(2026, 2, 16, 0, 0, 0),
                    StartTime = new TimeSpan(13, 0, 0),
                    EndTime = new TimeSpan(15, 0, 0),
                    TotalPrice = 138,
                    Status = "Pending",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 17,
                    PlayerId = 30,
                    PlaygroundId = 2,
                    BookingDate = new DateTime(2026, 2, 17, 0, 0, 0),
                    StartTime = new TimeSpan(14, 0, 0),
                    EndTime = new TimeSpan(15, 0, 0),
                    TotalPrice = 206,
                    Status = "Pending",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 18,
                    PlayerId = 31,
                    PlaygroundId = 3,
                    BookingDate = new DateTime(2026, 2, 18, 0, 0, 0),
                    StartTime = new TimeSpan(15, 0, 0),
                    EndTime = new TimeSpan(17, 0, 0),
                    TotalPrice = 154,
                    Status = "Confirmed",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 19,
                    PlayerId = 32,
                    PlaygroundId = 4,
                    BookingDate = new DateTime(2026, 2, 19, 0, 0, 0),
                    StartTime = new TimeSpan(16, 0, 0),
                    EndTime = new TimeSpan(17, 0, 0),
                    TotalPrice = 222,
                    Status = "Pending",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 20,
                    PlayerId = 33,
                    PlaygroundId = 5,
                    BookingDate = new DateTime(2026, 2, 20, 0, 0, 0),
                    StartTime = new TimeSpan(17, 0, 0),
                    EndTime = new TimeSpan(19, 0, 0),
                    TotalPrice = 170,
                    Status = "Pending",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 21,
                    PlayerId = 34,
                    PlaygroundId = 6,
                    BookingDate = new DateTime(2026, 2, 21, 0, 0, 0),
                    StartTime = new TimeSpan(8, 0, 0),
                    EndTime = new TimeSpan(9, 0, 0),
                    TotalPrice = 238,
                    Status = "Cancelled",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 22,
                    PlayerId = 35,
                    PlaygroundId = 7,
                    BookingDate = new DateTime(2026, 2, 22, 0, 0, 0),
                    StartTime = new TimeSpan(9, 0, 0),
                    EndTime = new TimeSpan(11, 0, 0),
                    TotalPrice = 186,
                    Status = "Pending",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 23,
                    PlayerId = 36,
                    PlaygroundId = 8,
                    BookingDate = new DateTime(2026, 2, 23, 0, 0, 0),
                    StartTime = new TimeSpan(10, 0, 0),
                    EndTime = new TimeSpan(11, 0, 0),
                    TotalPrice = 254,
                    Status = "Pending",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 24,
                    PlayerId = 37,
                    PlaygroundId = 9,
                    BookingDate = new DateTime(2026, 2, 24, 0, 0, 0),
                    StartTime = new TimeSpan(11, 0, 0),
                    EndTime = new TimeSpan(13, 0, 0),
                    TotalPrice = 202,
                    Status = "Confirmed",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 25,
                    PlayerId = 38,
                    PlaygroundId = 10,
                    BookingDate = new DateTime(2026, 2, 25, 0, 0, 0),
                    StartTime = new TimeSpan(12, 0, 0),
                    EndTime = new TimeSpan(13, 0, 0),
                    TotalPrice = 270,
                    Status = "Pending",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 26,
                    PlayerId = 39,
                    PlaygroundId = 11,
                    BookingDate = new DateTime(2026, 2, 26, 0, 0, 0),
                    StartTime = new TimeSpan(13, 0, 0),
                    EndTime = new TimeSpan(15, 0, 0),
                    TotalPrice = 218,
                    Status = "Pending",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 27,
                    PlayerId = 40,
                    PlaygroundId = 12,
                    BookingDate = new DateTime(2026, 2, 27, 0, 0, 0),
                    StartTime = new TimeSpan(14, 0, 0),
                    EndTime = new TimeSpan(15, 0, 0),
                    TotalPrice = 286,
                    Status = "Confirmed",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 28,
                    PlayerId = 41,
                    PlaygroundId = 13,
                    BookingDate = new DateTime(2026, 2, 28, 0, 0, 0),
                    StartTime = new TimeSpan(15, 0, 0),
                    EndTime = new TimeSpan(17, 0, 0),
                    TotalPrice = 234,
                    Status = "Cancelled",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 29,
                    PlayerId = 42,
                    PlaygroundId = 14,
                    BookingDate = new DateTime(2026, 2, 1, 0, 0, 0),
                    StartTime = new TimeSpan(16, 0, 0),
                    EndTime = new TimeSpan(17, 0, 0),
                    TotalPrice = 302,
                    Status = "Pending",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 30,
                    PlayerId = 43,
                    PlaygroundId = 15,
                    BookingDate = new DateTime(2026, 2, 2, 0, 0, 0),
                    StartTime = new TimeSpan(17, 0, 0),
                    EndTime = new TimeSpan(19, 0, 0),
                    TotalPrice = 250,
                    Status = "Confirmed",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 31,
                    PlayerId = 44,
                    PlaygroundId = 1,
                    BookingDate = new DateTime(2026, 2, 3, 0, 0, 0),
                    StartTime = new TimeSpan(8, 0, 0),
                    EndTime = new TimeSpan(9, 0, 0),
                    TotalPrice = 198,
                    Status = "Pending",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 32,
                    PlayerId = 45,
                    PlaygroundId = 2,
                    BookingDate = new DateTime(2026, 2, 4, 0, 0, 0),
                    StartTime = new TimeSpan(9, 0, 0),
                    EndTime = new TimeSpan(11, 0, 0),
                    TotalPrice = 146,
                    Status = "Pending",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 33,
                    PlayerId = 46,
                    PlaygroundId = 3,
                    BookingDate = new DateTime(2026, 2, 5, 0, 0, 0),
                    StartTime = new TimeSpan(10, 0, 0),
                    EndTime = new TimeSpan(11, 0, 0),
                    TotalPrice = 214,
                    Status = "Confirmed",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 34,
                    PlayerId = 47,
                    PlaygroundId = 4,
                    BookingDate = new DateTime(2026, 2, 6, 0, 0, 0),
                    StartTime = new TimeSpan(11, 0, 0),
                    EndTime = new TimeSpan(13, 0, 0),
                    TotalPrice = 162,
                    Status = "Pending",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 35,
                    PlayerId = 48,
                    PlaygroundId = 5,
                    BookingDate = new DateTime(2026, 2, 7, 0, 0, 0),
                    StartTime = new TimeSpan(12, 0, 0),
                    EndTime = new TimeSpan(13, 0, 0),
                    TotalPrice = 230,
                    Status = "Cancelled",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 36,
                    PlayerId = 49,
                    PlaygroundId = 6,
                    BookingDate = new DateTime(2026, 2, 8, 0, 0, 0),
                    StartTime = new TimeSpan(13, 0, 0),
                    EndTime = new TimeSpan(15, 0, 0),
                    TotalPrice = 178,
                    Status = "Confirmed",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 37,
                    PlayerId = 50,
                    PlaygroundId = 7,
                    BookingDate = new DateTime(2026, 2, 9, 0, 0, 0),
                    StartTime = new TimeSpan(14, 0, 0),
                    EndTime = new TimeSpan(15, 0, 0),
                    TotalPrice = 246,
                    Status = "Pending",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 38,
                    PlayerId = 51,
                    PlaygroundId = 8,
                    BookingDate = new DateTime(2026, 2, 10, 0, 0, 0),
                    StartTime = new TimeSpan(15, 0, 0),
                    EndTime = new TimeSpan(17, 0, 0),
                    TotalPrice = 194,
                    Status = "Pending",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 39,
                    PlayerId = 52,
                    PlaygroundId = 9,
                    BookingDate = new DateTime(2026, 2, 11, 0, 0, 0),
                    StartTime = new TimeSpan(16, 0, 0),
                    EndTime = new TimeSpan(17, 0, 0),
                    TotalPrice = 262,
                    Status = "Confirmed",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 40,
                    PlayerId = 53,
                    PlaygroundId = 10,
                    BookingDate = new DateTime(2026, 2, 12, 0, 0, 0),
                    StartTime = new TimeSpan(17, 0, 0),
                    EndTime = new TimeSpan(19, 0, 0),
                    TotalPrice = 210,
                    Status = "Pending",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 41,
                    PlayerId = 54,
                    PlaygroundId = 11,
                    BookingDate = new DateTime(2026, 2, 13, 0, 0, 0),
                    StartTime = new TimeSpan(8, 0, 0),
                    EndTime = new TimeSpan(9, 0, 0),
                    TotalPrice = 278,
                    Status = "Pending",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 42,
                    PlayerId = 55,
                    PlaygroundId = 12,
                    BookingDate = new DateTime(2026, 2, 14, 0, 0, 0),
                    StartTime = new TimeSpan(9, 0, 0),
                    EndTime = new TimeSpan(11, 0, 0),
                    TotalPrice = 226,
                    Status = "Cancelled",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 43,
                    PlayerId = 56,
                    PlaygroundId = 13,
                    BookingDate = new DateTime(2026, 2, 15, 0, 0, 0),
                    StartTime = new TimeSpan(10, 0, 0),
                    EndTime = new TimeSpan(11, 0, 0),
                    TotalPrice = 294,
                    Status = "Pending",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 44,
                    PlayerId = 57,
                    PlaygroundId = 14,
                    BookingDate = new DateTime(2026, 2, 16, 0, 0, 0),
                    StartTime = new TimeSpan(11, 0, 0),
                    EndTime = new TimeSpan(13, 0, 0),
                    TotalPrice = 242,
                    Status = "Pending",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 45,
                    PlayerId = 58,
                    PlaygroundId = 15,
                    BookingDate = new DateTime(2026, 2, 17, 0, 0, 0),
                    StartTime = new TimeSpan(12, 0, 0),
                    EndTime = new TimeSpan(13, 0, 0),
                    TotalPrice = 310,
                    Status = "Confirmed",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 46,
                    PlayerId = 59,
                    PlaygroundId = 1,
                    BookingDate = new DateTime(2026, 2, 18, 0, 0, 0),
                    StartTime = new TimeSpan(13, 0, 0),
                    EndTime = new TimeSpan(15, 0, 0),
                    TotalPrice = 138,
                    Status = "Pending",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 47,
                    PlayerId = 60,
                    PlaygroundId = 2,
                    BookingDate = new DateTime(2026, 2, 19, 0, 0, 0),
                    StartTime = new TimeSpan(14, 0, 0),
                    EndTime = new TimeSpan(15, 0, 0),
                    TotalPrice = 206,
                    Status = "Pending",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 48,
                    PlayerId = 61,
                    PlaygroundId = 3,
                    BookingDate = new DateTime(2026, 2, 20, 0, 0, 0),
                    StartTime = new TimeSpan(15, 0, 0),
                    EndTime = new TimeSpan(17, 0, 0),
                    TotalPrice = 154,
                    Status = "Confirmed",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 49,
                    PlayerId = 62,
                    PlaygroundId = 4,
                    BookingDate = new DateTime(2026, 2, 21, 0, 0, 0),
                    StartTime = new TimeSpan(16, 0, 0),
                    EndTime = new TimeSpan(17, 0, 0),
                    TotalPrice = 222,
                    Status = "Cancelled",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 50,
                    PlayerId = 63,
                    PlaygroundId = 5,
                    BookingDate = new DateTime(2026, 2, 22, 0, 0, 0),
                    StartTime = new TimeSpan(17, 0, 0),
                    EndTime = new TimeSpan(19, 0, 0),
                    TotalPrice = 170,
                    Status = "Pending",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 51,
                    PlayerId = 14,
                    PlaygroundId = 6,
                    BookingDate = new DateTime(2026, 2, 23, 0, 0, 0),
                    StartTime = new TimeSpan(8, 0, 0),
                    EndTime = new TimeSpan(9, 0, 0),
                    TotalPrice = 238,
                    Status = "Confirmed",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 52,
                    PlayerId = 15,
                    PlaygroundId = 7,
                    BookingDate = new DateTime(2026, 2, 24, 0, 0, 0),
                    StartTime = new TimeSpan(9, 0, 0),
                    EndTime = new TimeSpan(11, 0, 0),
                    TotalPrice = 186,
                    Status = "Pending",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 53,
                    PlayerId = 16,
                    PlaygroundId = 8,
                    BookingDate = new DateTime(2026, 2, 25, 0, 0, 0),
                    StartTime = new TimeSpan(10, 0, 0),
                    EndTime = new TimeSpan(11, 0, 0),
                    TotalPrice = 254,
                    Status = "Pending",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 54,
                    PlayerId = 17,
                    PlaygroundId = 9,
                    BookingDate = new DateTime(2026, 2, 26, 0, 0, 0),
                    StartTime = new TimeSpan(11, 0, 0),
                    EndTime = new TimeSpan(13, 0, 0),
                    TotalPrice = 202,
                    Status = "Confirmed",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                },
                new Booking
                {
                    BookingId = 55,
                    PlayerId = 18,
                    PlaygroundId = 10,
                    BookingDate = new DateTime(2026, 2, 27, 0, 0, 0),
                    StartTime = new TimeSpan(12, 0, 0),
                    EndTime = new TimeSpan(13, 0, 0),
                    TotalPrice = 270,
                    Status = "Pending",
                    CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 10, 10, 0, 0)
                }
            );
        }
    }
}

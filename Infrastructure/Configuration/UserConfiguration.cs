using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User
            {
                UserId = 1,
                FullName = "Admin User",
                Email = "admin@example.com",
                PasswordHash = "admin123hashed",
                Phone = "0100000000",
                Role = "Admin",
                IsActive = true,
                CreatedAt = new DateTime(2025, 1, 1, 10, 0, 0),
                UpdatedAt = new DateTime(2025, 1, 1, 10, 0, 0)
            },
            new User
            {
                UserId = 2,
                FullName = "Playground Owner",
                Email = "owner@example.com",
                PasswordHash = "owner123hashed",
                Phone = "0101111111",
                Role = "Owner",
                IsActive = true,
                CreatedAt = new DateTime(2025, 1, 1, 10, 0, 0),
                UpdatedAt = new DateTime(2025, 1, 1, 10, 0, 0)
            },
            new User
            {
                UserId = 3,
                FullName = "Regular Player",
                Email = "player@example.com",
                PasswordHash = "player123hashed",
                Phone = "0102222222",
                Role = "Player",
                IsActive = true,
                CreatedAt = new DateTime(2025, 1, 1, 10, 0, 0),
                UpdatedAt = new DateTime(2025, 1, 1, 10, 0, 0)
            });
        }
    }
}

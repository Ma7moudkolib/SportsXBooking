using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    UserId = 1,
                    FullName = "Admin User 1",
                    Email = "admin1@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEAdminSeedHash1",
                    Phone = "0101000001",
                    Role = "Admin",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 2,
                    FullName = "Admin User 2",
                    Email = "admin2@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEAdminSeedHash2",
                    Phone = "0101000002",
                    Role = "Admin",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 3,
                    FullName = "Admin User 3",
                    Email = "admin3@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEAdminSeedHash3",
                    Phone = "0101000003",
                    Role = "Admin",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 4,
                    FullName = "Owner User 1",
                    Email = "owner1@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEOwnerSeedHash1",
                    Phone = "0102000001",
                    Role = "Owner",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 5,
                    FullName = "Owner User 2",
                    Email = "owner2@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEOwnerSeedHash2",
                    Phone = "0102000002",
                    Role = "Owner",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 6,
                    FullName = "Owner User 3",
                    Email = "owner3@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEOwnerSeedHash3",
                    Phone = "0102000003",
                    Role = "Owner",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 7,
                    FullName = "Owner User 4",
                    Email = "owner4@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEOwnerSeedHash4",
                    Phone = "0102000004",
                    Role = "Owner",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 8,
                    FullName = "Owner User 5",
                    Email = "owner5@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEOwnerSeedHash5",
                    Phone = "0102000005",
                    Role = "Owner",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 9,
                    FullName = "Owner User 6",
                    Email = "owner6@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEOwnerSeedHash6",
                    Phone = "0102000006",
                    Role = "Owner",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 10,
                    FullName = "Owner User 7",
                    Email = "owner7@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEOwnerSeedHash7",
                    Phone = "0102000007",
                    Role = "Owner",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 11,
                    FullName = "Owner User 8",
                    Email = "owner8@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEOwnerSeedHash8",
                    Phone = "0102000008",
                    Role = "Owner",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 12,
                    FullName = "Owner User 9",
                    Email = "owner9@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEOwnerSeedHash9",
                    Phone = "0102000009",
                    Role = "Owner",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 13,
                    FullName = "Owner User 10",
                    Email = "owner10@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEOwnerSeedHash10",
                    Phone = "0102000010",
                    Role = "Owner",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 14,
                    FullName = "Player User 1",
                    Email = "player1@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash1",
                    Phone = "0103000001",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 15,
                    FullName = "Player User 2",
                    Email = "player2@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash2",
                    Phone = "0103000002",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 16,
                    FullName = "Player User 3",
                    Email = "player3@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash3",
                    Phone = "0103000003",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 17,
                    FullName = "Player User 4",
                    Email = "player4@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash4",
                    Phone = "0103000004",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 18,
                    FullName = "Player User 5",
                    Email = "player5@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash5",
                    Phone = "0103000005",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 19,
                    FullName = "Player User 6",
                    Email = "player6@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash6",
                    Phone = "0103000006",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 20,
                    FullName = "Player User 7",
                    Email = "player7@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash7",
                    Phone = "0103000007",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 21,
                    FullName = "Player User 8",
                    Email = "player8@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash8",
                    Phone = "0103000008",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 22,
                    FullName = "Player User 9",
                    Email = "player9@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash9",
                    Phone = "0103000009",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 23,
                    FullName = "Player User 10",
                    Email = "player10@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash10",
                    Phone = "0103000010",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 24,
                    FullName = "Player User 11",
                    Email = "player11@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash11",
                    Phone = "0103000011",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 25,
                    FullName = "Player User 12",
                    Email = "player12@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash12",
                    Phone = "0103000012",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 26,
                    FullName = "Player User 13",
                    Email = "player13@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash13",
                    Phone = "0103000013",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 27,
                    FullName = "Player User 14",
                    Email = "player14@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash14",
                    Phone = "0103000014",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 28,
                    FullName = "Player User 15",
                    Email = "player15@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash15",
                    Phone = "0103000015",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 29,
                    FullName = "Player User 16",
                    Email = "player16@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash16",
                    Phone = "0103000016",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 30,
                    FullName = "Player User 17",
                    Email = "player17@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash17",
                    Phone = "0103000017",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 31,
                    FullName = "Player User 18",
                    Email = "player18@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash18",
                    Phone = "0103000018",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 32,
                    FullName = "Player User 19",
                    Email = "player19@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash19",
                    Phone = "0103000019",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 33,
                    FullName = "Player User 20",
                    Email = "player20@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash20",
                    Phone = "0103000020",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 34,
                    FullName = "Player User 21",
                    Email = "player21@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash21",
                    Phone = "0103000021",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 35,
                    FullName = "Player User 22",
                    Email = "player22@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash22",
                    Phone = "0103000022",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 36,
                    FullName = "Player User 23",
                    Email = "player23@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash23",
                    Phone = "0103000023",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 37,
                    FullName = "Player User 24",
                    Email = "player24@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash24",
                    Phone = "0103000024",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 38,
                    FullName = "Player User 25",
                    Email = "player25@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash25",
                    Phone = "0103000025",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 39,
                    FullName = "Player User 26",
                    Email = "player26@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash26",
                    Phone = "0103000026",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 40,
                    FullName = "Player User 27",
                    Email = "player27@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash27",
                    Phone = "0103000027",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 41,
                    FullName = "Player User 28",
                    Email = "player28@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash28",
                    Phone = "0103000028",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 42,
                    FullName = "Player User 29",
                    Email = "player29@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash29",
                    Phone = "0103000029",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 43,
                    FullName = "Player User 30",
                    Email = "player30@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash30",
                    Phone = "0103000030",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 44,
                    FullName = "Player User 31",
                    Email = "player31@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash31",
                    Phone = "0103000031",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 45,
                    FullName = "Player User 32",
                    Email = "player32@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash32",
                    Phone = "0103000032",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 46,
                    FullName = "Player User 33",
                    Email = "player33@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash33",
                    Phone = "0103000033",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 47,
                    FullName = "Player User 34",
                    Email = "player34@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash34",
                    Phone = "0103000034",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 48,
                    FullName = "Player User 35",
                    Email = "player35@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash35",
                    Phone = "0103000035",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 49,
                    FullName = "Player User 36",
                    Email = "player36@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash36",
                    Phone = "0103000036",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 50,
                    FullName = "Player User 37",
                    Email = "player37@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash37",
                    Phone = "0103000037",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 51,
                    FullName = "Player User 38",
                    Email = "player38@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash38",
                    Phone = "0103000038",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 52,
                    FullName = "Player User 39",
                    Email = "player39@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash39",
                    Phone = "0103000039",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 53,
                    FullName = "Player User 40",
                    Email = "player40@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash40",
                    Phone = "0103000040",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 54,
                    FullName = "Player User 41",
                    Email = "player41@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash41",
                    Phone = "0103000041",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 55,
                    FullName = "Player User 42",
                    Email = "player42@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash42",
                    Phone = "0103000042",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 56,
                    FullName = "Player User 43",
                    Email = "player43@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash43",
                    Phone = "0103000043",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 57,
                    FullName = "Player User 44",
                    Email = "player44@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash44",
                    Phone = "0103000044",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 58,
                    FullName = "Player User 45",
                    Email = "player45@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash45",
                    Phone = "0103000045",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 59,
                    FullName = "Player User 46",
                    Email = "player46@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash46",
                    Phone = "0103000046",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 60,
                    FullName = "Player User 47",
                    Email = "player47@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash47",
                    Phone = "0103000047",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 61,
                    FullName = "Player User 48",
                    Email = "player48@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash48",
                    Phone = "0103000048",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 62,
                    FullName = "Player User 49",
                    Email = "player49@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash49",
                    Phone = "0103000049",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                },
                new User
                {
                    UserId = 63,
                    FullName = "Player User 50",
                    Email = "player50@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash50",
                    Phone = "0103000050",
                    Role = "Player",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1, 8, 0, 0),
                    UpdatedAt = new DateTime(2026, 1, 1, 8, 0, 0)
                }
            );
        }
    }
}

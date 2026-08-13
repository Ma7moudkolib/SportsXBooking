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
                    Id = 1,
                    FirstName = "Admin",
                    LastName = "User 1",
                    Email = "admin1@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEAdminSeedHash1",
                    PhoneNumber = "0101000001",
                    Role = "Admin",

                },
                new User
                {
                    Id = 2,
                    FirstName = "Admin",
                    LastName = " User 2",
                    Email = "admin2@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEAdminSeedHash2",
                    PhoneNumber = "0101000002",
                    Role = "Admin",
                },
                new User
                {
                    Id = 3,
                    FirstName = "Admin",
                    LastName = "User 3",
                    Email = "admin3@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEAdminSeedHash3",
                    PhoneNumber = "0101000003",
                    Role = "Admin",

                },
                new User
                {
                    Id = 4,
                    FirstName = "Owner",
                    LastName = "User 1",
                    Email = "owner1@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEOwnerSeedHash1",
                    PhoneNumber = "0102000001",
                    Role = "Owner",

                },
                new User
                {
                    Id = 5,
                    FirstName = "Owner",
                    LastName = "User 2",
                    Email = "owner2@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEOwnerSeedHash2",
                    PhoneNumber = "0102000002",
                    Role = "Owner",

                },
                new User
                {
                    Id = 6,
                    FirstName = "Owner",
                    LastName = "User 3",
                    Email = "owner3@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEOwnerSeedHash3",
                    PhoneNumber = "0102000003",
                    Role = "Owner",
                },
                new User
                {
                    Id = 7,
                    FirstName = "Owner",
                    LastName = "User 4",
                    Email = "owner4@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEOwnerSeedHash4",
                    PhoneNumber = "0102000004",
                    Role = "Owner",

                },
                new User
                {
                    Id = 8,
                    FirstName = "Owner",
                    LastName = "User 5",
                    Email = "owner5@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEOwnerSeedHash5",
                    PhoneNumber = "0102000005",
                    Role = "Owner",

                },
                new User
                {
                    Id = 9,
                    FirstName = "Owner",
                    LastName = "User 6",
                    Email = "owner6@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEOwnerSeedHash6",
                    PhoneNumber = "0102000006",
                    Role = "Owner",
                },
                new User
                {
                    Id = 10,
                    FirstName = "Owner",
                    LastName = "User 7",
                    Email = "owner7@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEOwnerSeedHash7",
                    PhoneNumber = "0102000007",
                    Role = "Owner",

                },
                new User
                {
                    Id = 11,
                    FirstName = "Owner",
                    LastName = "User 8",
                    Email = "owner8@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEOwnerSeedHash8",
                    PhoneNumber = "0102000008",
                    Role = "Owner",

                },
                new User
                {
                    Id = 12,
                    FirstName = "Owner",
                    LastName = "User 9",
                    Email = "owner9@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEOwnerSeedHash9",
                    PhoneNumber = "0102000009",
                    Role = "Owner",

                },
                new User
                {
                    Id = 13,
                    FirstName = "Owner",
                    LastName = "User 10",
                    Email = "owner10@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEOwnerSeedHash10",
                    PhoneNumber = "0102000010",
                    Role = "Owner",

                },
                new User
                {
                    Id = 14,
                    FirstName = "Player User 1",
                    LastName = "Player User 1",
                    Email = "player1@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash1",
                    PhoneNumber = "0103000001",
                    Role = "Player",

                },
                new User
                {
                    Id = 15,
                    FirstName = "Player User 2",
                    LastName = "Player User 2",
                    Email = "player2@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash2",
                    PhoneNumber = "0103000002",
                    Role = "Player",

                },
                new User
                {
                    Id = 16,
                    FirstName = "Player User 3",
                    LastName = "Player User 3",
                    Email = "player3@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash3",
                    PhoneNumber = "0103000003",
                    Role = "Player",

                },
                new User
                {
                    Id = 17,
                    FirstName = "Player User 4",
                    LastName = "Player User 4",
                    Email = "player4@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash4",
                    PhoneNumber = "0103000004",
                    Role = "Player",

                },
                new User
                {
                    Id = 18,
                    FirstName = "Player User 5",
                    LastName = "Player User 5",
                    Email = "player5@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash5",
                    PhoneNumber = "0103000005",
                    Role = "Player",

                },
                new User
                {
                    Id = 19,
                    FirstName = "Player User 6",
                    LastName = "Player User 6",
                    Email = "player6@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash6",
                    PhoneNumber = "0103000006",
                    Role = "Player",

                },
                new User
                {
                    Id = 20,
                    FirstName = "Player User 7",
                    LastName = "Player User 7",
                    Email = "player7@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash7",
                    PhoneNumber = "0103000007",
                    Role = "Player",

                },
                new User
                {
                    Id = 21,
                    FirstName = "Player User 8",
                    LastName = "Player User 8",
                    Email = "player8@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash8",
                    PhoneNumber = "0103000008",
                    Role = "Player",

                },
                new User
                {
                    Id = 22,
                    FirstName = "Player User 9",
                    LastName = "Player User 9",
                    Email = "player9@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash9",
                    PhoneNumber = "0103000009",
                    Role = "Player",

                },
                new User
                {
                    Id = 23,
                    FirstName = "Player User 10",
                    LastName = "Player User 10",
                    Email = "player10@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash10",
                    PhoneNumber = "0103000010",
                    Role = "Player",

                },
                new User
                {
                    Id = 24,
                    FirstName = "Player User 11",
                    LastName = "Player User 11",
                    Email = "player11@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash11",
                    PhoneNumber = "0103000011",
                    Role = "Player",

                },
                new User
                {
                    Id = 25,
                    FirstName = "Player User 12",
                    LastName = "Player User 12",
                    Email = "player12@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash12",
                    PhoneNumber = "0103000012",
                    Role = "Player",

                },
                new User
                {
                    Id = 26,
                    FirstName = "Player User 13",
                    LastName = "Player User 13",
                    Email = "player13@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash13",
                    PhoneNumber = "0103000013",
                    Role = "Player",

                },
                new User
                {
                    Id = 27,
                    FirstName = "Player User 14",
                    LastName = "Player User 14",
                    Email = "player14@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash14",
                    PhoneNumber = "0103000014",
                    Role = "Player",

                },
                new User
                {
                    Id = 28,
                    FirstName = "Player User 15",
                    LastName = "Player User 15",
                    Email = "player15@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash15",
                    PhoneNumber = "0103000015",
                    Role = "Player",

                },
                new User
                {
                    Id = 29,
                    FirstName = "Player User 16",
                    LastName = "Player User 16",
                    Email = "player16@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash16",
                    PhoneNumber = "0103000016",
                    Role = "Player",

                },
                new User
                {
                    Id = 30,
                    FirstName = "Player User 17",
                    LastName = "Player User 17",
                    Email = "player17@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash17",
                    PhoneNumber = "0103000017",
                    Role = "Player",

                },
                new User
                {
                    Id = 31,
                    FirstName = "Player User 18",
                    LastName = "Player User 18",
                    Email = "player18@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash18",
                    PhoneNumber = "0103000018",
                    Role = "Player",

                },
                new User
                {
                    Id = 32,
                    FirstName = "Player User 19",
                    LastName = "Player User 19",
                    Email = "player19@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash19",
                    PhoneNumber = "0103000019",
                    Role = "Player",

                },
                new User
                {
                    Id = 33,
                    FirstName = "Player User 20",
                    LastName = "Player User 20",
                    Email = "player20@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash20",
                    PhoneNumber = "0103000020",
                    Role = "Player",

                },
                new User
                {
                    Id = 34,
                    FirstName = "Player User 21",
                    LastName = "Player User 21",
                    Email = "player21@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash21",
                    PhoneNumber = "0103000021",
                    Role = "Player",

                },
                new User
                {
                    Id = 35,
                    FirstName = "Player User 22",
                    LastName = "Player User 22",
                    Email = "player22@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash22",
                    PhoneNumber = "0103000022",
                    Role = "Player",

                },
                new User
                {
                    Id = 36,
                    FirstName = "Player User 23",
                    LastName = "Player User 23",
                    Email = "player23@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash23",
                    PhoneNumber = "0103000023",
                    Role = "Player",

                },
                new User
                {
                    Id = 37,
                    FirstName = "Player User 24",
                    LastName = "Player User 24",
                    Email = "player24@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash24",
                    PhoneNumber = "0103000024",
                    Role = "Player",

                },
                new User
                {
                    Id = 38,
                    FirstName = "Player User 25",
                    LastName = "Player User 25",
                    Email = "player25@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash25",
                    PhoneNumber = "0103000025",
                    Role = "Player",

                },
                new User
                {
                    Id = 39,
                    FirstName = "Player User 26",
                    LastName = "Player User 26",
                    Email = "player26@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash26",
                    PhoneNumber = "0103000026",
                    Role = "Player",

                },
                new User
                {
                    Id = 40,
                    FirstName = "Player User 27",
                    LastName = "Player User 27",
                    Email = "player27@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash27",
                    PhoneNumber = "0103000027",
                    Role = "Player",

                },
                new User
                {
                    Id = 41,
                    FirstName = "Player User 28",
                    LastName = "Player User 28",
                    Email = "player28@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash28",
                    PhoneNumber = "0103000028",
                    Role = "Player",

                },
                new User
                {
                    Id = 42,
                    FirstName = "Player User 29",
                    LastName = "Player User 29",
                    Email = "player29@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash29",
                    PhoneNumber = "0103000029",
                    Role = "Player",

                },
                new User
                {
                    Id = 43,
                    FirstName = "Player User 30",
                    LastName = "Player User 30",
                    Email = "player30@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash30",
                    PhoneNumber = "0103000030",
                    Role = "Player",

                },
                new User
                {
                    Id = 44,
                    FirstName = "Player User 31",
                    LastName = "Player User 31",
                    Email = "player31@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash31",
                    PhoneNumber = "0103000031",
                    Role = "Player",

                },
                new User
                {
                    Id = 45,
                    FirstName = "Player User 32",
                    LastName = "Player User 32",
                    Email = "player32@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash32",
                    PhoneNumber = "0103000032",
                    Role = "Player",

                },
                new User
                {
                    Id = 46,
                    FirstName = "Player User 33",
                    LastName = "Player User 33",
                    Email = "player33@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash33",
                    PhoneNumber = "0103000033",
                    Role = "Player",

                },
                new User
                {
                    Id = 47,
                    FirstName = "Player User 34",
                    LastName = "Player User 34",
                    Email = "player34@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash34",
                    PhoneNumber = "0103000034",
                    Role = "Player",

                },
                new User
                {
                    Id = 48,
                    FirstName = "Player User 35",
                    LastName = "Player User 35",
                    Email = "player35@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash35",
                    PhoneNumber = "0103000035",
                    Role = "Player",

                },
                new User
                {
                    Id = 49,
                    FirstName = "Player User 36",
                    LastName = "Player User 36",
                    Email = "player36@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash36",
                    PhoneNumber = "0103000036",
                    Role = "Player",

                },
                new User
                {
                    Id = 50,
                    FirstName = "Player User 37",
                    LastName = "Player User 37",
                    Email = "player37@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash37",
                    PhoneNumber = "0103000037",
                    Role = "Player",

                },
                new User
                {
                    Id = 51,
                    FirstName = "Player User 38",
                    LastName = "Player User 38",
                    Email = "player38@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash38",
                    PhoneNumber = "0103000038",
                    Role = "Player",

                },
                new User
                {
                    Id = 52,
                    FirstName = "Player User 39",
                    LastName = "Player User 39",
                    Email = "player39@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash39",
                    PhoneNumber = "0103000039",
                    Role = "Player",

                },
                new User
                {
                    Id = 53,
                    FirstName = "Player User 40",
                    LastName = "Player User 40",
                    Email = "player40@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash40",
                    PhoneNumber = "0103000040",
                    Role = "Player",

                },
                new User
                {
                    Id = 54,
                    FirstName = "Player User 41",
                    LastName = "Player User 41",
                    Email = "player41@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash41",
                    PhoneNumber = "0103000041",
                    Role = "Player",

                },
                new User
                {
                    Id = 55,
                    FirstName = "Player User 42",
                    LastName = "Player User 42",
                    Email = "player42@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash42",
                    PhoneNumber = "0103000042",
                    Role = "Player",

                },
                new User
                {
                    Id = 56,
                    FirstName = "Player User 43",
                    LastName = "Player User 43",
                    Email = "player43@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash43",
                    PhoneNumber = "0103000043",
                    Role = "Player",

                },
                new User
                {
                    Id = 57,
                    FirstName = "Player User 44",
                    LastName = "Player User 44",
                    Email = "player44@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash44",
                    PhoneNumber = "0103000044",
                    Role = "Player",

                },
                new User
                {
                    Id = 58,
                    FirstName = "Player User 45",
                    LastName = "Player User 45",
                    Email = "player45@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash45",
                    PhoneNumber = "0103000045",
                    Role = "Player"
                },
                new User
                {
                    Id = 59,
                    FirstName = "Player User 46",
                    LastName = "Player User 46",
                    Email = "player46@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash46",
                    PhoneNumber = "0103000046",
                    Role = "Player",
                },
                new User
                {
                    Id = 60,
                    FirstName = "Player User 47",
                    LastName = "Player User 47",
                    Email = "player47@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash47",
                    PhoneNumber = "0103000047",
                    Role = "Player"

                },
                new User
                {
                    Id = 61,
                    FirstName = "Player",
                    LastName = "User 48",
                    Email = "player48@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash48",
                    PhoneNumber = "0103000048",
                    Role = "Player"

                },
                new User
                {
                    Id = 62,
                    FirstName = "Player",
                    LastName = "User 49",
                    Email = "player49@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash49",
                    PhoneNumber = "0103000049",
                    Role = "Player"

                },
                new User
                {
                    Id = 63,
                    FirstName = "Player",
                    LastName = "User 50",
                    Email = "player50@sportsx.local",
                    PasswordHash = "AQAAAAEAACcQAAAAEPlayerSeedHash50",
                    PhoneNumber = "0103000050",
                    Role = "Player"
                }
            );
        }
    }
}

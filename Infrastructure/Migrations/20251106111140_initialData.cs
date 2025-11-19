using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedAt", "Email", "FullName", "IsActive", "PasswordHash", "Phone", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "admin@example.com", "Admin User", true, "admin123hashed", "0100000000", "Admin", new DateTime(2025, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2025, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "owner@example.com", "Playground Owner", true, "owner123hashed", "0101111111", "Owner", new DateTime(2025, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2025, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "player@example.com", "Regular Player", true, "player123hashed", "0102222222", "Player", new DateTime(2025, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Playgrounds",
                columns: new[] { "PlaygroundId", "CreatedAt", "ImageUrl", "IsAvailable", "Location", "Name", "OwnerId", "PricePerHour", "SportType" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/green-field.jpg", true, "Cairo, Nasr City", "Green Field Playground", 2, 150m, "Football" },
                    { 2, new DateTime(2025, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/tennis-court.jpg", true, "Alexandria, Smouha", "Elite Tennis Court", 2, 200m, "Tennis" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "BookingDate", "CreatedAt", "EndTime", "PlayerId", "PlaygroundId", "StartTime", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2025, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 16, 0, 0, 0), 3, 1, new TimeSpan(0, 14, 0, 0, 0), "Confirmed", 300m, new DateTime(2025, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "Comment", "CreatedAt", "IsApproved", "PlayerId", "PlaygroundId", "Rating" },
                values: new object[] { 1, "Amazing playground, very clean!", new DateTime(2025, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), true, 3, 1, 5 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BookingId", "PaymentMethod", "PaymentStatus", "TransactionDate", "TransactionId" },
                values: new object[] { 1, 300m, 1, "Cash", "Paid", new DateTime(2025, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "TXN-DEMO-111" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Playgrounds",
                keyColumn: "PlaygroundId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Playgrounds",
                keyColumn: "PlaygroundId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);
        }
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasData(
                new Payment
                {
                    PaymentId = 1,
                    BookingId = 1,
                    Amount = 206,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0001",
                    TransactionDate = new DateTime(2026, 2, 1, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 2,
                    BookingId = 2,
                    Amount = 154,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0002",
                    TransactionDate = new DateTime(2026, 2, 2, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 3,
                    BookingId = 3,
                    Amount = 222,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0003",
                    TransactionDate = new DateTime(2026, 2, 3, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 4,
                    BookingId = 4,
                    Amount = 170,
                    PaymentMethod = "Wallet",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0004",
                    TransactionDate = new DateTime(2026, 2, 4, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 5,
                    BookingId = 5,
                    Amount = 238,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0005",
                    TransactionDate = new DateTime(2026, 2, 5, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 6,
                    BookingId = 6,
                    Amount = 186,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0006",
                    TransactionDate = new DateTime(2026, 2, 6, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 7,
                    BookingId = 7,
                    Amount = 254,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0007",
                    TransactionDate = new DateTime(2026, 2, 7, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 8,
                    BookingId = 8,
                    Amount = 202,
                    PaymentMethod = "Wallet",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0008",
                    TransactionDate = new DateTime(2026, 2, 8, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 9,
                    BookingId = 9,
                    Amount = 270,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Failed",
                    TransactionId = "TXN-2026-0009",
                    TransactionDate = new DateTime(2026, 2, 9, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 10,
                    BookingId = 10,
                    Amount = 218,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0010",
                    TransactionDate = new DateTime(2026, 2, 10, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 11,
                    BookingId = 11,
                    Amount = 286,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0011",
                    TransactionDate = new DateTime(2026, 2, 11, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 12,
                    BookingId = 12,
                    Amount = 234,
                    PaymentMethod = "Wallet",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0012",
                    TransactionDate = new DateTime(2026, 2, 12, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 13,
                    BookingId = 13,
                    Amount = 302,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0013",
                    TransactionDate = new DateTime(2026, 2, 13, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 14,
                    BookingId = 14,
                    Amount = 250,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0014",
                    TransactionDate = new DateTime(2026, 2, 14, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 15,
                    BookingId = 15,
                    Amount = 198,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0015",
                    TransactionDate = new DateTime(2026, 2, 15, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 16,
                    BookingId = 16,
                    Amount = 146,
                    PaymentMethod = "Wallet",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0016",
                    TransactionDate = new DateTime(2026, 2, 16, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 17,
                    BookingId = 17,
                    Amount = 214,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0017",
                    TransactionDate = new DateTime(2026, 2, 17, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 18,
                    BookingId = 18,
                    Amount = 162,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Failed",
                    TransactionId = "TXN-2026-0018",
                    TransactionDate = new DateTime(2026, 2, 18, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 19,
                    BookingId = 19,
                    Amount = 230,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0019",
                    TransactionDate = new DateTime(2026, 2, 19, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 20,
                    BookingId = 20,
                    Amount = 178,
                    PaymentMethod = "Wallet",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0020",
                    TransactionDate = new DateTime(2026, 2, 20, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 21,
                    BookingId = 21,
                    Amount = 246,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0021",
                    TransactionDate = new DateTime(2026, 2, 21, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 22,
                    BookingId = 22,
                    Amount = 194,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0022",
                    TransactionDate = new DateTime(2026, 2, 22, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 23,
                    BookingId = 23,
                    Amount = 262,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0023",
                    TransactionDate = new DateTime(2026, 2, 23, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 24,
                    BookingId = 24,
                    Amount = 210,
                    PaymentMethod = "Wallet",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0024",
                    TransactionDate = new DateTime(2026, 2, 24, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 25,
                    BookingId = 25,
                    Amount = 278,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0025",
                    TransactionDate = new DateTime(2026, 2, 25, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 26,
                    BookingId = 26,
                    Amount = 226,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0026",
                    TransactionDate = new DateTime(2026, 2, 26, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 27,
                    BookingId = 27,
                    Amount = 294,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Failed",
                    TransactionId = "TXN-2026-0027",
                    TransactionDate = new DateTime(2026, 2, 27, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 28,
                    BookingId = 28,
                    Amount = 242,
                    PaymentMethod = "Wallet",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0028",
                    TransactionDate = new DateTime(2026, 2, 28, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 29,
                    BookingId = 29,
                    Amount = 310,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0029",
                    TransactionDate = new DateTime(2026, 2, 1, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 30,
                    BookingId = 30,
                    Amount = 138,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0030",
                    TransactionDate = new DateTime(2026, 2, 2, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 31,
                    BookingId = 31,
                    Amount = 206,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0031",
                    TransactionDate = new DateTime(2026, 2, 3, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 32,
                    BookingId = 32,
                    Amount = 154,
                    PaymentMethod = "Wallet",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0032",
                    TransactionDate = new DateTime(2026, 2, 4, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 33,
                    BookingId = 33,
                    Amount = 222,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0033",
                    TransactionDate = new DateTime(2026, 2, 5, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 34,
                    BookingId = 34,
                    Amount = 170,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0034",
                    TransactionDate = new DateTime(2026, 2, 6, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 35,
                    BookingId = 35,
                    Amount = 238,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0035",
                    TransactionDate = new DateTime(2026, 2, 7, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 36,
                    BookingId = 36,
                    Amount = 186,
                    PaymentMethod = "Wallet",
                    PaymentStatus = "Failed",
                    TransactionId = "TXN-2026-0036",
                    TransactionDate = new DateTime(2026, 2, 8, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 37,
                    BookingId = 37,
                    Amount = 254,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0037",
                    TransactionDate = new DateTime(2026, 2, 9, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 38,
                    BookingId = 38,
                    Amount = 202,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0038",
                    TransactionDate = new DateTime(2026, 2, 10, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 39,
                    BookingId = 39,
                    Amount = 270,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0039",
                    TransactionDate = new DateTime(2026, 2, 11, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 40,
                    BookingId = 40,
                    Amount = 218,
                    PaymentMethod = "Wallet",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0040",
                    TransactionDate = new DateTime(2026, 2, 12, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 41,
                    BookingId = 41,
                    Amount = 286,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0041",
                    TransactionDate = new DateTime(2026, 2, 13, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 42,
                    BookingId = 42,
                    Amount = 234,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0042",
                    TransactionDate = new DateTime(2026, 2, 14, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 43,
                    BookingId = 43,
                    Amount = 302,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0043",
                    TransactionDate = new DateTime(2026, 2, 15, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 44,
                    BookingId = 44,
                    Amount = 250,
                    PaymentMethod = "Wallet",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0044",
                    TransactionDate = new DateTime(2026, 2, 16, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 45,
                    BookingId = 45,
                    Amount = 198,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Failed",
                    TransactionId = "TXN-2026-0045",
                    TransactionDate = new DateTime(2026, 2, 17, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 46,
                    BookingId = 46,
                    Amount = 146,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0046",
                    TransactionDate = new DateTime(2026, 2, 18, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 47,
                    BookingId = 47,
                    Amount = 214,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0047",
                    TransactionDate = new DateTime(2026, 2, 19, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 48,
                    BookingId = 48,
                    Amount = 162,
                    PaymentMethod = "Wallet",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0048",
                    TransactionDate = new DateTime(2026, 2, 20, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 49,
                    BookingId = 49,
                    Amount = 230,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0049",
                    TransactionDate = new DateTime(2026, 2, 21, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 50,
                    BookingId = 50,
                    Amount = 178,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0050",
                    TransactionDate = new DateTime(2026, 2, 22, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 51,
                    BookingId = 51,
                    Amount = 246,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0051",
                    TransactionDate = new DateTime(2026, 2, 23, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 52,
                    BookingId = 52,
                    Amount = 194,
                    PaymentMethod = "Wallet",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0052",
                    TransactionDate = new DateTime(2026, 2, 24, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 53,
                    BookingId = 53,
                    Amount = 262,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0053",
                    TransactionDate = new DateTime(2026, 2, 25, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 54,
                    BookingId = 54,
                    Amount = 210,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Failed",
                    TransactionId = "TXN-2026-0054",
                    TransactionDate = new DateTime(2026, 2, 26, 12, 0, 0)
                },
                new Payment
                {
                    PaymentId = 55,
                    BookingId = 55,
                    Amount = 278,
                    PaymentMethod = "CreditCard",
                    PaymentStatus = "Paid",
                    TransactionId = "TXN-2026-0055",
                    TransactionDate = new DateTime(2026, 2, 27, 12, 0, 0)
                }
            );
        }
    }
}

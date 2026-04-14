using Domain.Entities;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.DatabaseContext
{
    public class RepositoryContext :DbContext
    {
        public RepositoryContext(DbContextOptions options):base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Playground> Playgrounds { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new PlaygroundConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new BookingConfiguration());

            // User
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Role).HasDefaultValue("Player");
            });

            // Playground
            modelBuilder.Entity<Playground>(entity =>
            {
                entity.Property(e => e.PricePerHour).HasPrecision(10, 2);

                entity.HasOne(p => p.Owner)
                    .WithMany(u => u.Playgrounds)
                    .HasForeignKey(p => p.OwnerId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Booking
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.TotalPrice).HasPrecision(10, 2);

                entity.HasOne(b => b.Player)
                    .WithMany(u => u.Bookings)
                    .HasForeignKey(b => b.PlayerId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(b => b.Playground)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(b => b.PlaygroundId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Payment
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.Amount).HasPrecision(10, 2);

                entity.HasOne(p => p.Booking)
                    .WithOne(b => b.Payment)
                    .HasForeignKey<Payment>(p => p.BookingId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Review
            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasOne(r => r.Player)
                    .WithMany(u => u.Reviews)
                    .HasForeignKey(r => r.PlayerId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(r => r.Playground)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(r => r.PlaygroundId)
                    .OnDelete(DeleteBehavior.Cascade);
            }
            );
            base.OnModelCreating(modelBuilder);

          
        }
    }

}


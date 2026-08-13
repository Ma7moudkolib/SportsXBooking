using Domain.Entities;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace Infrastructure.DatabaseContext
{
    public class RepositoryContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }
        public DbSet<Playground> Playgrounds { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new PlaygroundConfiguration());
//          modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new BookingConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());


            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<IdentityRole<int>>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<int>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserToken<int>>().ToTable("UserTokens");
            // User
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Role).HasDefaultValue("Player");
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
//              entity.Property(e => e.Phone).HasMaxLength(15);
                entity.Property(e=> e.PhoneNumber).HasColumnName("Phone")
                .HasMaxLength(15);

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


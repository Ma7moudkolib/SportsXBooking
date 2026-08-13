using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    internal class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<int>> builder)
        {
            builder.HasData(
                new IdentityRole<int>
                {
                    Id = 1,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "a1b2c3d4-0000-0000-0000-000000000001"
                },
                new IdentityRole<int>
                {
                    Id = 2,
                    Name = "Owner",
                    NormalizedName = "OWNER",
                    ConcurrencyStamp = "a1b2c3d4-0000-0000-0000-000000000002"
                },
                new IdentityRole<int>
                {
                    Id = 3,
                    Name = "Player",
                    NormalizedName = "PLAYER",
                    ConcurrencyStamp = "a1b2c3d4-0000-0000-0000-000000000003"
                }
            );
        }
    }
}

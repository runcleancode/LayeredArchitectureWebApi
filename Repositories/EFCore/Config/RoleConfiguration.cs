using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "8581D1F1-3F53-4D37-BE8B-BDC4037B21D7",
                    Name = "User",
                    NormalizedName = "USER"
                },
                new IdentityRole
                {
                    Id = "DF085BBB-938B-4158-B2E9-DAEDD8C2FEC3",
                    Name = "Editor",
                    NormalizedName = "EDITOR"
                },
                new IdentityRole
                {
                    Id = "6E254A2A-1CB7-443A-BE9E-B3758E2B7571",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
            );
        }
    }
}
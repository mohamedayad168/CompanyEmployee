using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {

            builder.HasData(new IdentityRole
            {
                Id = "4ac8240a-8498-4869-bc86-60e5dc982d27",
                ConcurrencyStamp = "ec511bd4-4853-426a-a2fc-751886560c9a",
                Name = "Manager",
                NormalizedName = "MANAGER"
            },
            new IdentityRole
            {
                Id = "562419f5-eed1-473b-bcc1-9f2dbab182b4",
                ConcurrencyStamp = "937e9988-9f49-4bab-a545-b422dde85016",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            });
        }
    }
}

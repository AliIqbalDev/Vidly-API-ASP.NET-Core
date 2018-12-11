using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vidly_RESTful_API.Models;

namespace Vidly_RESTful_API.Contexts.EntityConfigurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("IdentityUsers");

            builder.Property(u => u.FirstName).HasColumnType("varchar(100)").IsRequired();

            builder.Property(u => u.LastName).HasColumnType("varchar(100)").IsRequired();
        }
    }
}
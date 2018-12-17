using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vidly_RESTful_API.Models;

namespace Vidly_RESTful_API.Contexts.EntityConfigurations
{
    public class RentalConfiguration : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.DateOut).IsRequired();

            builder.Property(r => r.DateReturned).IsRequired();

            builder.Property(r => r.RentalFee).HasColumnType("decimal(18,2)").IsRequired();
        }
    }
}
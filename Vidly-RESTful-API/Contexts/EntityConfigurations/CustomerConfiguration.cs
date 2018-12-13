using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vidly_RESTful_API.Models;

namespace Vidly_RESTful_API.Contexts.EntityConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).HasColumnType("varchar(100)").IsRequired();

            builder.Property(c => c.Phone).HasColumnType("varchar(50)").IsRequired();
        }
    }
}
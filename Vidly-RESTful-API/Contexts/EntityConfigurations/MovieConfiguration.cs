using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vidly_RESTful_API.Models;

namespace Vidly_RESTful_API.Contexts.EntityConfigurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Title).HasMaxLength(255).IsRequired();

            builder.Property(m => m.DailyRentalRate).HasColumnType("decimal(18,2)").IsRequired();
        }
    }
}
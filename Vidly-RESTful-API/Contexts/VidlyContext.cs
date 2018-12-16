using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vidly_RESTful_API.Contexts.EntityConfigurations;
using Vidly_RESTful_API.Models;

namespace Vidly_RESTful_API.Contexts
{
    public class VidlyContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public VidlyContext(DbContextOptions options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRoleClaim<string>>().ToTable("IdentityRoleClaims");
            builder.Entity<IdentityUserClaim<string>>().ToTable("IdentityUserClaims");
            builder.Entity<IdentityUserRole<string>>().ToTable("IdentityUserRoles");
            builder.Entity<IdentityUserLogin<string>>().ToTable("IdentityUserLogins");
            builder.Entity<IdentityUserToken<string>>().ToTable("IdentityUserTokens");

            builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new GenreConfiguration());
            builder.ApplyConfiguration(new MovieConfiguration());
        }
    }
}
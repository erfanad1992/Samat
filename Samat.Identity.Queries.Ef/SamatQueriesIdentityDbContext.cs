using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Samat.Identity.Queries.Ef.Entities;

namespace Samat.Identity.Queries.Ef
{
    internal class SamatQueriesIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public SamatQueriesIdentityDbContext()
        {
        }

        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;

        public SamatQueriesIdentityDbContext(DbContextOptions<SamatQueriesIdentityDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

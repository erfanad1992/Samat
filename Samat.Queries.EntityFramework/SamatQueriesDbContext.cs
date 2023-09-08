using Microsoft.EntityFrameworkCore;
using Samat.Framework.Queries.EntityFramework;

namespace Samat.Queries.EntityFramework
{
    public partial class SamatQueriesDbContext : QueryDbContextBase
    {
        public SamatQueriesDbContext()
        {
        }

        public SamatQueriesDbContext(DbContextOptions<SamatQueriesDbContext> options)
            : base(options)
        {
        }

        //public virtual DbSet<Basket> Baskets { get; set; } = null!;
        //public virtual DbSet<BasketItem> BasketItems { get; set; } = null!;
        //public virtual DbSet<Customer> Customers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=SamatDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Basket>(entity =>
            //{
            //    entity.Property(e => e.Id).ValueGeneratedNever();
            //});

            //modelBuilder.Entity<Customer>(entity =>
            //{
            //    entity.Property(e => e.Id).ValueGeneratedNever();
            //});

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

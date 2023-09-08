using Microsoft.EntityFrameworkCore;
using Samat.Framework.Queries.EntityFramework;
using Samat.Queries.EntityFramework.Entities;

namespace Samat.Queries.EntityFramework;

public partial class SamatQueriesDbContext : QueryDbContextBase
{
    public SamatQueriesDbContext()
    {
    }

    public SamatQueriesDbContext(DbContextOptions<SamatQueriesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=SamatDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

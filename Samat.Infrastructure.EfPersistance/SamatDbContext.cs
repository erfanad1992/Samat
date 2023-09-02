using Microsoft.EntityFrameworkCore;
using Samat.Infrastructure.EfPersistance.Customers.EntityConfigurations;
using Samat.Infrastructure.EfPersistance.Orders.Entities;
using Samat.Infrastructure.EfPersistance.Orders.EntityConfigurations;
using Samat.Infrastructure.EfPersistance.Products.EntityConfigurations;

namespace Samat.Infrastructure.EfPersistance
{
    public class SamatDbContext : DbContext
    {
        public SamatDbContext(DbContextOptions<SamatDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrderEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerEntityConfiguration());

            base.OnModelCreating(modelBuilder);

        }

    }
}

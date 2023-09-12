using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Samat.Domains.Customers;
using Samat.Domains.Orders;
using Samat.Domains.Orders.Entities;
using Samat.Domains.Products;
using Samat.Infrastructure.EfPersistance.Customers.EntityConfigurations;
using Samat.Infrastructure.EfPersistance.Orders.Entities;
using Samat.Infrastructure.EfPersistance.Orders.EntityConfigurations;
using Samat.Infrastructure.EfPersistance.Products.EntityConfigurations;
using Smat.Identity.Domain.Entities;

namespace Samat.Infrastructure.EfPersistance
{
    public class SamatDbContext : IdentityDbContext<ApplicationUser> { 
        public SamatDbContext(DbContextOptions<SamatDbContext> options) : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
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

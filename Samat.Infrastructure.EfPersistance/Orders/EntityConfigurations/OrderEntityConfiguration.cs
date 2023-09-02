using Microsoft.EntityFrameworkCore;
using Samat.Domains.Customers;
using Samat.Domains.Orders;

namespace Samat.Infrastructure.EfPersistance.Orders.EntityConfigurations
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                   .ValueGeneratedNever();

            builder.OwnsOne(c => c.CustomerId,
                  c =>
                  {
                      c.HasOne(typeof(Customer))
                       .WithMany()
                       .HasForeignKey("Id").IsRequired(true).OnDelete(DeleteBehavior.Restrict);

                      c.Property(d => d.Id)
                       .HasColumnName("CustomerId").IsRequired(true);

                  });
            builder.Property(o => o.OrderDate);
 
            builder.ToTable(nameof(Order));
        }
    }
}

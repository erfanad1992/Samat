using Microsoft.EntityFrameworkCore;
using Samat.Domains.Orders;
using Samat.Domains.Orders.Entities;
using Samat.Domains.Products;

namespace Samat.Infrastructure.EfPersistance.Orders.Entities
{
    public class OrderItemEntityConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                   .ValueGeneratedNever();
            builder.HasOne<Order>().WithMany(s => s.OrderItems).HasForeignKey(t => t.OrderId);
            builder.OwnsOne(c => c.ProductId,
                            c =>
                            {
                                c.HasOne(typeof(Product))
                                 .WithMany()
                                 .HasForeignKey("Id").IsRequired(true).OnDelete(DeleteBehavior.Restrict);

                                c.Property(d => d.Id)
                                 .HasColumnName("ProductId").IsRequired(true);

                            });

            builder.Property(x => x.Quantity);
            builder.ToTable(nameof(OrderItem));
        }
    }
}

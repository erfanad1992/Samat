using Microsoft.EntityFrameworkCore;
using Samat.Domains.Products;

namespace Samat.Infrastructure.EfPersistance.Products.EntityConfigurations
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                   .ValueGeneratedNever();

            builder.Property(o => o.Name);

            builder.Property(o => o.Price).HasPrecision(18,2);

            builder.ToTable(nameof(Product));
        }
    }
}

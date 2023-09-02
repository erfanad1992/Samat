using Microsoft.EntityFrameworkCore;
using Samat.Domains.Customers;

namespace Samat.Infrastructure.EfPersistance.Customers.EntityConfigurations
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                   .ValueGeneratedNever();
            builder.Property(o => o.FirstName).HasMaxLength(200);
            builder.Property(o => o.LastName).HasMaxLength(200);
            builder.Property(o => o.NationalCode).HasMaxLength(100);
            builder.Property(o => o.LastPurchaseDate);
            builder.ToTable(nameof(Customer));
        }
    }
}

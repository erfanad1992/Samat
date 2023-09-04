using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Samat.Domains.Customers;
using Samat.Domains.Orders;
using Samat.Domains.Products;
using Samat.Infrastructure.EfPersistance.Customers;
using Samat.Infrastructure.EfPersistance.Orders;
using Samat.Infrastructure.EfPersistance.Products;

namespace Samat.Infrastructure.EfPersistance.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPersistenceEntityFrameworkServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<SamatDbContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlServerConnectionString"),
                    x => x.MigrationsHistoryTable("__EFMigrationsHistory"));

            });

            services.AddScoped<DbContext>((sp) => sp.GetRequiredService<SamatDbContext>());
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();


        }
    }
}

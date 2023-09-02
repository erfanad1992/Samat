using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            //services.AddTransient<IPersonInfoRepository, PersonInfoRepository>();


        }
    }
}

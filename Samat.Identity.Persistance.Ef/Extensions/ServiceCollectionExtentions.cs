
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Samat.Framework.Presistance.EF.Extensions;
using Smat.Identity.Domain;
using Smat.Identity.Domain.Entities;

namespace Samat.Identity.Persistance.Ef.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddIdentityPersistenceEntityFrameworkServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlServerConnectionString")
                , x => x.MigrationsHistoryTable("__EFMigrationsHistory"));
        });

        services.AddScoped<DbContext>((sp) => sp.GetRequiredService<ApplicationDbContext>());
        services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        services.AddUnitOfWorkByEntityFramework();


    }
}
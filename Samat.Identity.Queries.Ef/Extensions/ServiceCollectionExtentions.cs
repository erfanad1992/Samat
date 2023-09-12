using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Samat.Identity.Queries.Ef;

namespace Samat.Identity.Queries.Ef.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddQueriesEntityFrameworkServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SqlConnection");
        services.AddDbContext<SamatQueriesIdentityDbContext>(options => options.UseSqlServer(connectionString));
    }
}

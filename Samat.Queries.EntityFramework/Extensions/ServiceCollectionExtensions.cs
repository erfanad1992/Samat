using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Samat.Framework.Queries.EntityFramework.Extensions;

namespace Samat.Queries.EntityFramework.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddQueriesEntityFrameworkServices(this IServiceCollection services, string sqlServerQueryConnectionString)
    {
        services.AddQueryDbContext<SamatQueriesDbContext>(options =>
        {
            // options.LogTo((value)=>Console.WriteLine(value),Microsoft.Extensions.Logging.LogLevel.Trace);
            options.UseSqlServer(sqlServerQueryConnectionString);
        });
    }
}
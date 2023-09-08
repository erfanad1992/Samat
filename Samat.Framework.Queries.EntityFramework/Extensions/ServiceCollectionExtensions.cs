
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Samat.Framework.Queries.EntityFramework.Interceptors;

namespace Samat.Framework.Queries.EntityFramework.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddQueryDbContext<TContext>(this IServiceCollection serviceCollection, Action<DbContextOptionsBuilder>? optionsAction = null)
        where TContext : QueryDbContext‌Base
    {
        serviceCollection.AddDbContext<TContext>(optionsAction);

        return serviceCollection;
    }

    public static DbContextOptionsBuilder AddPersianYeKeCommandInterceptor(this DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new PersianYeKeCommandInterceptor());

        return optionsBuilder;
    }
}

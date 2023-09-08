using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Samat.Framework.Application.Behaviors;
using Samat.Framework.Application.Clocks;
using Samat.Framework.Application.CustomeMediatR;
using Samat.Framework.Domain;
using System.Reflection;

namespace Samat.Framework.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddMediatRServices(this IServiceCollection services, params Assembly[] assembles)
    {
        // services.AddMediatR(assembles);
        services.AddMediatR(options =>
        {
            options.MediatorImplementationType = typeof(CustomMediator);
            options.RegisterServicesFromAssemblies(assembles);
        });

        services.AddBehaviors();
    }

    public static void AddMediatRServices(this IServiceCollection services, params Type[] handlerAssemblyMarkerTypes)
    {
        services.AddMediatR(options =>
        {
            options.MediatorImplementationType = typeof(CustomMediator);
            options.RegisterServicesFromAssemblies(handlerAssemblyMarkerTypes.Select(c => c.Assembly).ToArray());
        });
        services.AddBehaviors();
    }

    public static void AddBehaviors(this IServiceCollection services)
    {
        var isExistSaveChangesBehavior = services.Any(c => c.ServiceType == typeof(IPipelineBehavior<,>) &&
             c.ImplementationType == typeof(SaveChangesBehavior<,>));

        if (!isExistSaveChangesBehavior)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(SaveChangesBehavior<,>));
        }

        var isExistLoggingBehavior = services.Any(c => c.ServiceType == typeof(IPipelineBehavior<,>) &&
           c.ImplementationType == typeof(LoggingBehavior<,>));

        if (!isExistLoggingBehavior)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        }

        // todo: add performance behavior
    }

    public static void AddClock(this IServiceCollection services)
    {
        services.AddScoped<IClock, SystemClock>();
    }
}
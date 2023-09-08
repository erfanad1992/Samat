using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Samat.Framework.Endpoints.Web.Results;
using System.Reflection;

namespace Samat.Framework.Endpoints.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddDefaultFrameworkServices(this IServiceCollection services, IConfiguration configuration) where T : class
    {

        //services.AddDefaultAuthentication(configuration);

        // services.AddDefaultSwaggerGen();
     //   services.AddControllersWithViews()
     //.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining(Assembly.GetExecutingAssembly()));

        RegisterFluentValidationValidators(services);

        services.PostConfigure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = actionContext
                       => new BadRequestApiResult(actionContext.ModelState);
        });
    }

    private static void RegisterFluentValidationValidators(IServiceCollection services)
    {
        Assembly assembly = Assembly.GetExecutingAssembly(); // Change to your assembly if necessary

        var validatorTypes = assembly.GetTypes()
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(AbstractValidator<>));

        foreach (var validatorType in validatorTypes)
        {
            var modelType = validatorType.BaseType.GenericTypeArguments[0];
            var validatorInterfaceType = typeof(IValidator<>).MakeGenericType(modelType);

            services.AddTransient(validatorInterfaceType, validatorType);
        }
    }
}

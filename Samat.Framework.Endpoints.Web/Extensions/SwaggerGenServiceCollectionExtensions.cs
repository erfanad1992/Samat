//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Options;
//using Microsoft.OpenApi.Models;
//using Swashbuckle.AspNetCore.SwaggerGen;

//namespace Samat.Framework.Endpoints.Web.Extensions;

//public static class SwaggerGenServiceCollectionExtensions
//{
//    public static IServiceCollection AddDefaultSwaggerGen(this IServiceCollection services, Action<SwaggerGenOptions> setupAction = null)
//    {
//        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerOptions>();

//        services.AddSwaggerGen(c =>
//        {
//            c.MapType<long>(() => new OpenApiSchema { Type = "string" });
//            c.OperationFilter<ClientVersionHeaderFilter>();
//        });

//        return services;
//    }
//}

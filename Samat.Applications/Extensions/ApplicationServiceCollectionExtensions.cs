using IdGen;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Samat.Framework.Application.Extensions;
using Samat.Framework.Domain;
using Samat.Framework.Utilities.Extensions;

namespace Samat.Applications.Extensions
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatRServices(typeof(ApplicationServiceCollectionExtensions).Assembly);
            services.AddUtilitiesServices();

        }
    }
}

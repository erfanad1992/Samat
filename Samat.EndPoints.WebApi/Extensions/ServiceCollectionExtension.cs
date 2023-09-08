using Microsoft.EntityFrameworkCore;
using Samat.Framework.Endpoints.Web.Extensions;
using Samat.Infrastructure.EfPersistance;
using Samat.Infrastructure.EfPersistance.Extensions;

namespace Samat.EndPoints.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddPersistenceEntityFrameworkServices(configuration);
            services.AddDefaultFrameworkServices(configuration);
            //services.AddTransient<IPersonInfoRepository, PersonInfoRepository>();


        }
    }
}

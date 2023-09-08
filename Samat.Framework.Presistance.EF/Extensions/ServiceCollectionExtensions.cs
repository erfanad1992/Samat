using Microsoft.Extensions.DependencyInjection;
using Samat.Framework.Domain;

namespace Samat.Framework.Presistance.EF.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddUnitOfWorkByEntityFramework(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}

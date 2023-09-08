using IdGen;
using Microsoft.Extensions.DependencyInjection;
using Samat.Framework.Domain;
using Samat.Framework.Utilities.IdGenerators;

namespace Samat.Framework.Utilities.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddUtilitiesServices(this IServiceCollection services)
        {
            services.AddSingleton<IIdGenerator, SnowflakeIdGenerator>();
            services.AddSingleton(sp => new IdGenerator(0));

        }
    }

}

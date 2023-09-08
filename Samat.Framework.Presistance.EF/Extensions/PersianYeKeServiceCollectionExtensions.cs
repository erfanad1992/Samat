using Microsoft.EntityFrameworkCore;
using Samat.Framework.Presistance.EF.PersianYeKe;

namespace Samat.Framework.Presistance.EF.Extensions
{
    public static class PersianYeKeServiceCollectionExtensions
    {
        public static DbContextOptionsBuilder AddPersianYeKeCommandInterceptor(this DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new PersianYeKeCommandInterceptor());

            return optionsBuilder;
        }
    }
}
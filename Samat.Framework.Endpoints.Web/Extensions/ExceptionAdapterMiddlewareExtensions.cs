using Microsoft.AspNetCore.Builder;
using Samat.Framework.Endpoints.Web.Middlewares;

namespace Samat.Framework.Endpoints.Web.Extensions;

public static class ExceptionAdapterMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionAdapter(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ExceptionAdapterMiddleware>();
    }
}

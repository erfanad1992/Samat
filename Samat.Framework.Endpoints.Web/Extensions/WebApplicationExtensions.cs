using Microsoft.AspNetCore.Builder;

namespace Samat.Framework.Endpoints.Web.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseSamatFramework(this WebApplication app)
    {
        app.UseExceptionAdapter();

        return app;
    }


}

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Samat.Framework.Application.Extensions;
using Samat.Identity.Application.Services;
using System.Text;

namespace Samat.Identity.Application.Extensions;

public static class ApplicationServiceCollectionExtensions
{
    public static void AddIdentityApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatRServices(typeof(ApplicationServiceCollectionExtensions).Assembly);
        services.AddTransient<IUserAuthentication, UserAuthentication>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })

// Adding Jwt Bearer  
        .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = configuration["JWT:ValidAudience"],
                ValidIssuer = configuration["JWT:ValidIssuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
            };
              });
              }
}
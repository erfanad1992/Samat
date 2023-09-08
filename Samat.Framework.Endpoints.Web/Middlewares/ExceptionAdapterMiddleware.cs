using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Samat.Framework.Domain;
using Samat.Framework.Endpoints.Web.Options;
using Samat.Framework.Endpoints.Web.Results;
using System.Net;
using System.Text.Json;

namespace Samat.Framework.Endpoints.Web.Middlewares;

public class ExceptionAdapterMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionAdapterMiddleware> _logger;
    private const string UnhandledExceptionMessage = "An unhandled exception has been occurred.";
    private const string UnhandledBusinessExceptionMessage = "An unhandled business exception has been occurred.";
    protected const string GeneralErrorCode = "1000";
    private readonly bool _errorExceptionInResult;

    public ExceptionAdapterMiddleware(RequestDelegate next,
        ILogger<ExceptionAdapterMiddleware> logger,
        IConfiguration configuration)
    {
        _next = next;
        _logger = logger;
        _errorExceptionInResult = configuration.GetSection(GeneralOptions.General)
            .GetValue<bool>(nameof(GeneralOptions.ErrorExceptionInResult));
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        await RollBackTransaction(context);

        _logger.LogError(exception, UnhandledBusinessExceptionMessage);

        ApiResult errorResult = CreateErrorResult(exception);

        await ReturnApiResultMessage(context, errorResult);
    }

    private async Task RollBackTransaction(HttpContext context)
    {
        try
        {
            var unitOfWork = context.RequestServices.GetService<IUnitOfWork>();
            if (unitOfWork != null)
                await unitOfWork.RollbackTransactionAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, UnhandledExceptionMessage);
        }
    }

    private async Task ReturnApiResultMessage(HttpContext context, ApiResult errorResult)
    {
        var serializedResult = SerializeResult(errorResult);
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = errorResult.StatusCode ?? (int)HttpStatusCode.OK;
        await context.Response.WriteAsync(serializedResult);
    }

    private ApiResult CreateErrorResult(Exception exception)
    {
        var errorResult = new ApiResult();

        if (exception is IBusinessException businessException)
        {
            errorResult.SetStatusAs400BadRequest();

            var code = businessException.GetCode();
            var message = businessException.GetMessage();
            errorResult.AppendError(message, code);
        }
        else if (exception is IUnauthorizedException unauthorizedException)
        {
            errorResult.SetStatusAs401Unauthorized();

            var code = unauthorizedException.GetCode();
            var message = unauthorizedException.GetMessage();
            errorResult.AppendError(message, code);
        }
        else if (exception is IForbiddenException forbiddenException)
        {
            errorResult.SetStatusAs403Forbidden();

            var code = forbiddenException.GetCode();
            var message = forbiddenException.GetMessage();
            errorResult.AppendError(message, code);
        }
        else
        {
            errorResult.SetStatusAs500InternalServerError(UnhandledExceptionMessage);
        }

        if (_errorExceptionInResult)
        {
            errorResult.AppendError(exception.ToString(), "exception");
        }

        return errorResult;
    }

    private static string SerializeResult(ApiResult result)
    {
        return JsonSerializer.Serialize(result, result.GetType(), new JsonSerializerOptions
        {
            WriteIndented = false,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        });
    }
}

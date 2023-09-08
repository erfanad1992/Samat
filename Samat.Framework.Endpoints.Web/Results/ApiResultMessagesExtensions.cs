using Microsoft.AspNetCore.Http;

namespace Samat.Framework.Endpoints.Web.Results;

public static class ApiResultMessagesExtensions
{
    public static void AppendSuccess(this ApiResult result, string message)
    {
        result.Messages.Add(new ApiResultMessage(ApiResultMessageType.Success, message));
    }

    public static void AppendWarning(this ApiResult result, string message)
    {
        result.Messages.Add(new ApiResultMessage(ApiResultMessageType.Warning, message));
    }

    public static void AppendInfo(this ApiResult result, string message)
    {
        result.Messages.Add(new ApiResultMessage(ApiResultMessageType.Info, message));
    }

    public static void AppendError(this ApiResult result, string message, string? code = null)
    {
        result.Messages.Add(new ApiResultMessage(ApiResultMessageType.Error, message, code));

    }

    public static void AppendSorryError(this ApiResult result)
    {
        //todo: localization message
        result.Messages.Add(new ApiResultMessage(ApiResultMessageType.Error, "متاسفانه خطایی پیش آمده است."));
    }

    public static void SetStatusAs200Ok(this ApiResult result)
    {
        result.StatusCode = StatusCodes.Status200OK;
    }

    public static void SetStatusAs400BadRequest(this ApiResult result)
    {
        result.StatusCode = StatusCodes.Status400BadRequest;
    }

    public static void SetStatusAs404NotFound(this ApiResult result)
    {
        result.StatusCode = StatusCodes.Status404NotFound;
    }

    public static void SetStatusAs404NotFound(this ApiResult result, string errorMessage)
    {
        result.StatusCode = StatusCodes.Status404NotFound;
        result.AppendError(errorMessage);
    }

    public static void SetStatusAs401Unauthorized(this ApiResult result)
    {
        result.StatusCode = StatusCodes.Status401Unauthorized;
    }

    public static void SetStatusAs403Forbidden(this ApiResult result)
    {
        result.StatusCode = StatusCodes.Status403Forbidden;
    }

    public static void SetStatusAs401Unauthorized(this ApiResult result, string errorMessage)
    {
        result.StatusCode = StatusCodes.Status401Unauthorized;
        result.AppendError(errorMessage);
    }

    public static void SetStatusAs500InternalServerError(this ApiResult result, string errorMessage)
    {
        result.StatusCode = StatusCodes.Status500InternalServerError;
        result.AppendError(errorMessage);
    }
}

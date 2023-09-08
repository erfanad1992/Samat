using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Samat.Framework.Endpoints.Web.Results;

[DefaultStatusCode(DefaultStatusCode)]

public class BadRequestApiResult : ObjectResult
{
    private const int DefaultStatusCode = StatusCodes.Status400BadRequest;

    public BadRequestApiResult(ModelStateDictionary modelState) :
        base(ToResult(modelState))
    {
        if (modelState == null)
        {
            throw new ArgumentNullException(nameof(modelState));
        }

        StatusCode = DefaultStatusCode;
    }

    private static ApiResult ToResult(ModelStateDictionary modelState)
    {
        if (modelState == null)
        {
            throw new ArgumentNullException(nameof(modelState));
        }

        var result = new ApiResult();

        result.AppendError("پارامترهای ارسالی صحیح نمی باشد. (تماس با پشتیبانی)", "");

        foreach ((string? key, ModelStateEntry? value) in modelState)
        {
            var errors = value.Errors;

            if (errors is { Count: > 0 })
            {
                foreach (var error in errors)
                {
                    var message = string.IsNullOrEmpty(error.ErrorMessage) ? "The input was not valid." : error.ErrorMessage;

                    var field = string.IsNullOrEmpty(key) ? null : key;

                    result.AppendError($"{field}:{message}", "BadRequest");
                }
            }
        }

        return result;
    }
}

using Microsoft.AspNetCore.Mvc;
using Samat.Framework.Endpoints.Web.Results;

namespace Samat.Framework.Endpoints.Web.Controllers;

public abstract class InternalControllerBase : ControllerBase
{
    [NonAction]
    public ApiResult ApiResult(ApiResult result)
    {
        ApplyStatusCode(result);
        return result;
    }

    [NonAction]
    public ApiResult<TData> ApiResult<TData>(ApiResult<TData> result)
    {
        ApplyStatusCode(result);
        return result;
    }

    [NonAction]
    public ApiResult OkApiResult(string? succeedMessage = null)
    {
        var result = new ApiResult();

        result.Succeed(succeedMessage);
        result.SetStatusAs200Ok();
        ApplyStatusCode(result);

        return result;
    }

    [NonAction]
    public ApiResult<TData> OkApiResult<TData>(TData data, string? succeedMessage = null)
    {
        var result = new ApiResult<TData>(data);

        result.Succeed(succeedMessage);
        result.SetStatusAs200Ok();
        ApplyStatusCode(result);

        return result;
    }



    [NonAction]
    public ApiResult NotFoundApiResult()
    {
        var result = new ApiResult();

        result.Succeed();
        result.SetStatusAs404NotFound();
        ApplyStatusCode(result);

        return result;
    }

    [NonAction]
    public ApiResult NotFoundApiResult(ApiResult result)
    {
        result.SetStatusAs404NotFound();
        ApplyStatusCode(result);

        return result;
    }

    [NonAction]
    public ApiResult BadRequestApiResult()
    {
        return BadRequestApiResult<object>();
    }

    [NonAction]
    public ApiResult<TData> BadRequestApiResult<TData>(TData data = default)
    {
        ApiResult<TData> apiResult = new(data);
        apiResult.SetStatusAs400BadRequest();
        ApplyStatusCode(apiResult);

        return apiResult;
    }

    [NonAction]
    public ApiResult<TData> UnauthorizedApiResult<TData>(TData data = default)
    {
        ApiResult<TData> apiResult = new(data);
        apiResult.SetStatusAs401Unauthorized();
        ApplyStatusCode(apiResult);

        return apiResult;
    }

    protected void ApplyStatusCode(ApiResult result)
    {
        if (result.StatusCode.HasValue && Response is not null)
        {
            Response.StatusCode = result.StatusCode.Value;
        }
    }
}

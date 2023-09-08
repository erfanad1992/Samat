using System.Text.Json.Serialization;

namespace Samat.Framework.Endpoints.Web.Results;

public class ApiResult
{
    public bool Success { get; set; }

    public ICollection<ApiResultMessage> Messages { get; } = new List<ApiResultMessage>();

    [JsonIgnore]
    public int? StatusCode { get; internal set; }

    public void Succeed(string? message = null)
    {
        Success = true;

        if (message != null)
        {
            Messages.Add(new ApiResultMessage(ApiResultMessageType.Success, message));
        }
    }
}

public class ApiResult<TData> : ApiResult
{
    public TData Data { get; }


    public ApiResult(TData data)
    {
        Data = data;
    }
}

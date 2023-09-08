namespace Samat.Framework.Endpoints.Web.Results;

public class ApiResultMessage
{
    public ApiResultMessage(ApiResultMessageType type, string message, string? code = null)
    {
        Type = type;
        Message = message;
        Code = code;
    }

    public string Message { get; }

    public string? Code { get; }

    public ApiResultMessageType Type { get; }
}

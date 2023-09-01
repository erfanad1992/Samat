namespace Samat.Framework.Domain;

public class UnauthorizedException : Exception, IUnauthorizedException
{
    public virtual string? Code { get; private set; }

    public UnauthorizedException()
    { }


    public UnauthorizedException(string? message = null, string? code = null)
         : base(message)
    {
        Code = code;
    }

    public UnauthorizedException(string message, Exception innerException)
        : base(message, innerException)
    { }

    public UnauthorizedException(string message, string code, Exception innerException)
    : base(message, innerException)
    {
        Code = code;
    }
    public string? GetCode()
    {
        return Code;
    }

    public string GetMessage()
    {

        return Message;
    }
}




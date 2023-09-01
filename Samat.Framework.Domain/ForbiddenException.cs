namespace Samat.Framework.Domain;

public class ForbiddenException : Exception, IForbiddenException
{
    public virtual string? Code { get; private set; }

    public ForbiddenException()
    { }


    public ForbiddenException(string? message = null, string? code = null)
         : base(message)
    {
        Code = code;
    }

    public ForbiddenException(string message, Exception innerException)
        : base(message, innerException)
    { }

    public ForbiddenException(string message, string code, Exception innerException)
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




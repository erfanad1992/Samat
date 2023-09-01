namespace Samat.Framework.Domain;

public interface IForbiddenException
{
    string? GetCode();
    string GetMessage();
}
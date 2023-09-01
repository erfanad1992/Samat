namespace Samat.Framework.Domain;

public interface IUnauthorizedException
{
    string? GetCode();
    string GetMessage();
}

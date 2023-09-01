namespace Samat.Framework.Domain;

public interface IBusinessException
{
    string? GetCode();
    string GetMessage();
}

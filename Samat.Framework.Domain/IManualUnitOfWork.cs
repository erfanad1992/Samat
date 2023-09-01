namespace Samat.Framework.Domain;

public interface IManualUnitOfWork
{
    IUnitOfWork GetUnitOfWork();
}
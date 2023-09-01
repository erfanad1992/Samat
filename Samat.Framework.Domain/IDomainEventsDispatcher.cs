namespace Samat.Framework.Domain;

public interface IDomainEventsDispatcher
{
    Task DispatchEventsAsync();
}

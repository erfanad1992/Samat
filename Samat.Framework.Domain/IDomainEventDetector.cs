using MediatR;

namespace Samat.Framework.Domain;

public interface IDomainEventDetector
{
    IEnumerable<INotification> GetAndClearDomainEvents();
}

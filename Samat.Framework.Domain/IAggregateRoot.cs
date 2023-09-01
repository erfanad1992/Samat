using MediatR;

namespace Samat.Framework.Domain
{
    public interface IAggregateRoot
    {
        IList<INotification> Events { get; }

        void ClearEvents();
        void RaiseEvent(INotification @event);
    }
}

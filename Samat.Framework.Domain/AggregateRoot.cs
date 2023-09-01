using MediatR;

namespace Samat.Framework.Domain
{
    public abstract class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot
    {
        private List<INotification> _events;

        public IList<INotification> Events => _events;

        public void RaiseEvent(INotification @event)
        {
            _events ??= new List<INotification>();

            _events.Add(@event);
        }


        public void ClearEvents()
        {
            _events?.Clear();
        }

    }
}

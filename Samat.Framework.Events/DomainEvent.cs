using MediatR;

namespace Samat.Framework.Events;

public abstract class DomainEvent : INotification
{
    protected DomainEvent()
    {
        OccurredOn = DateTimeOffset.Now;
    }

    protected DomainEvent(string aggregateId)
    {
        AggregateId = aggregateId;
        OccurredOn = DateTimeOffset.Now;
    }

    public DateTimeOffset OccurredOn { get; private set; }

    public string AggregateId { get; private set; }

    public void SetAggregateId(string aggregateId)
    {
        AggregateId = aggregateId;
    }
}
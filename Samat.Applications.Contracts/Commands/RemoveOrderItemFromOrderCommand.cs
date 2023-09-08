using MediatR;

namespace Samat.Applications.Contracts.Commands
{
    public class RemoveOrderItemFromOrderCommand : IRequest
    {
        public RemoveOrderItemFromOrderCommand(long orderId, long itemId)
        {
            OrderId = orderId;
            ItemId = itemId;
        }

        public long OrderId { get;private set; }
        public long ItemId { get;private set; }

    }
}

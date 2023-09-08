using MediatR;

namespace Samat.Applications.Contracts.Commands
{
    public class RemoveOrderCommand : IRequest
    {
        public RemoveOrderCommand(long orderId)
        {
            OrderId = orderId;
        }

        public long OrderId { get;private set; }

    }
}

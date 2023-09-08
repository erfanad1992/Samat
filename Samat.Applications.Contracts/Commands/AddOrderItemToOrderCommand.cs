using MediatR;

namespace Samat.Applications.Contracts.Commands
{
    public class AddOrderItemToOrderCommand : IRequest
    {
        public AddOrderItemToOrderCommand(long orderId, long productId, int quantity)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
        }

        public long OrderId { get; private set; }
        public long ProductId { get; set; }
        public int Quantity { get; private set; }
    }
}

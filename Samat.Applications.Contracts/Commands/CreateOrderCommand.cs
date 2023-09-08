using MediatR;

namespace Samat.Applications.Contracts.Commands
{
    public class CreateOrderCommand : IRequest
    {
        public CreateOrderCommand(long customerId, DateTime orderDate)
        {
            CustomerId = customerId;
            OrderDate = orderDate;
        }

        public long CustomerId { get; private set; }
        public DateTime OrderDate { get; private set; }
    }
}

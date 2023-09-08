using MediatR;
using Samat.Applications.Contracts.Commands;
using Samat.Domains.Orders;

namespace Samat.Applications.CommandHandlers
{
    public class RemoveOrderItemFromOrderCommandHandler : IRequestHandler<RemoveOrderItemFromOrderCommand>
    {
        private readonly IOrderRepository _repository;

        public RemoveOrderItemFromOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveOrderItemFromOrderCommand command, CancellationToken cancellationToken)
        {
           var order =await _repository.GetAsync(command.OrderId);
            if (order == null)
            {
                throw new Exception("سفارش مورد نظر موجود نیست");

            }
            order.RemoveItems(command.ItemId);
        }
    }
}

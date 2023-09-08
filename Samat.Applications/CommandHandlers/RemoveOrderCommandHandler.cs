using MediatR;
using Samat.Applications.Contracts.Commands;
using Samat.Domains.Orders;

namespace Samat.Applications.CommandHandlers
{
    public class RemoveOrderCommandHandler : IRequestHandler<RemoveOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public RemoveOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Handle(RemoveOrderCommand command, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsync(command.OrderId);
            if (order == null)
            {
                throw new Exception("سفارش یافت نشد");
            }
            await _orderRepository.RemoveOrderItems(order.Id);
            await _orderRepository.DeleteAsync(order.Id);
        }
    }
}

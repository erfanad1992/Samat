using MediatR;
using Samat.Applications.Contracts.Commands;
using Samat.Domains.Orders;
using Samat.Framework.Domain;

namespace Samat.Applications.CommandHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IIdGenerator _idGenerator;


        public CreateOrderCommandHandler(IOrderRepository orderRepository, IIdGenerator idGenerator)
        {
            _orderRepository = orderRepository;
            _idGenerator = idGenerator;
        }

        public async Task Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var id = _idGenerator.GetNewId();
            var customer = new Domains.Orders.ValueObjects.Customer(command.CustomerId);
            var order = new Order(id, customer, command.OrderDate);
            await _orderRepository.InsertAsync(order);
        }
    }
}

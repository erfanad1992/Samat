using MediatR;
using Samat.Applications.Contracts.Commands;
using Samat.Domains.Orders;
using Samat.Domains.Orders.Entities;
using Samat.Domains.Orders.Services;
using Samat.Framework.Domain;

namespace Samat.Applications.CommandHandlers
{
    public class AddOrderItemToOrderCommandHandler : IRequestHandler<AddOrderItemToOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IIdGenerator _idGenerator;
        private readonly IGetProductPriceDomainService _getProductPriceDomainService;


        public AddOrderItemToOrderCommandHandler(IOrderRepository orderRepository, IIdGenerator idGenerator, IGetProductPriceDomainService getProductPriceDomainService)
        {
            _orderRepository = orderRepository;
            _idGenerator = idGenerator;
            _getProductPriceDomainService = getProductPriceDomainService;
        }

        public async Task Handle(AddOrderItemToOrderCommand command, CancellationToken cancellationToken)
        {
            var order =await _orderRepository.GetOrder(command.OrderId);
   
            if (order == null)
            {
                throw new Exception("سفارش مورد نظر موجود نیست");
            }  
            var id = _idGenerator.GetNewId();
            var product = new Domains.Orders.ValueObjects.Product(command.ProductId);
            var orderItem = new OrderItem(id,product,command.Quantity,command.OrderId,_getProductPriceDomainService);
            order.AddItems(orderItem);

        }
    }
}

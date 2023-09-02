using Samat.Domains.Orders.Entities;
using Samat.Domains.Orders.ValueObjects;
using Samat.Framework.Domain;

namespace Samat.Domains.Orders
{
    public class Order : AggregateRoot<long>
    {
        private Order()
        {

        }
        public Order(long id ,Customer customerId, DateTime orderDate)
        {
            Id = id;
            CustomerId = customerId;
            OrderDate = orderDate;
        }

        public Customer CustomerId { get;private set; }

        public DateTime OrderDate { get; private set; }

        private List<OrderItem> _orderItems = new();

        public IEnumerable<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public void AddItems(OrderItem item)
        {
            _orderItems.Add(item);
        }

    }
}

using Samat.Domains.Orders.ValueObjects;
using Samat.Framework.Domain;

namespace Samat.Domains.Orders.Entities
{
    public class OrderItem : Entity<long>
    {
        public OrderItem(long id ,Product productId, int quantity)
        {
            Id = id;
            ProductId = productId;
            Quantity = quantity;
        }
        private OrderItem()
        {

        }
        public Product ProductId { get; set; }
        public int Quantity { get; private set; }
    }
}

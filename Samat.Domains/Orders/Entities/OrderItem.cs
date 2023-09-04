using Samat.Domains.Orders.ValueObjects;
using Samat.Framework.Domain;

namespace Samat.Domains.Orders.Entities
{
    public class OrderItem : Entity<long>
    {
        public OrderItem(long id, Product productId, int quantity, long orderId)
        {
            Id = id;
            ProductId = productId;
            Quantity = quantity;
            OrderId = orderId;
        }
        private OrderItem()
        {

        }
        public long OrderId { get; private set; }
        public decimal TotalPrice { get; private set; }
        public Product ProductId { get; set; }
        public int Quantity { get; private set; }

        private void SetTotalPrice()
        {
            TotalPrice = totalPrice;
        }
    }
}

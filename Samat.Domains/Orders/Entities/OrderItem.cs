using Samat.Domains.Orders.Services;
using Samat.Domains.Orders.ValueObjects;
using Samat.Framework.Domain;

namespace Samat.Domains.Orders.Entities
{
    public class OrderItem : Entity<long>
    {
        public OrderItem(long id, Product productId, int quantity, long orderId,IGetProductPriceDomainService getProductPriceDomainService)
        {
            Id = id;
            ProductId = productId;
            Quantity = quantity;
            OrderId = orderId;
            SetTotalPrice(getProductPriceDomainService);
        }
        private OrderItem()
        {

        }
        public long OrderId { get; private set; }
        public decimal TotalPrice { get; private set; }
        public Product ProductId { get; set; }
        public int Quantity { get; private set; }

        private void SetTotalPrice(IGetProductPriceDomainService getProductPriceDomainService)
        {
            var productPrice = getProductPriceDomainService.GetProductPrice(ProductId.Id).GetAwaiter().GetResult();
            if (productPrice != null)
            {
                TotalPrice = Quantity * productPrice;
            }
        
        }
    }
}

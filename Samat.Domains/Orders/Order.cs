using Samat.Domains.Orders.Entities;
using Samat.Domains.Orders.Services;
using Samat.Domains.Orders.ValueObjects;
using Samat.Framework.Domain;

namespace Samat.Domains.Orders
{
    public class Order : AggregateRoot<long>
    {
        private Order()
        {

        }
        public Order(long id, Customer customerId, DateTime orderDate, IGetCustomerLastPurchaseDateDomainService customerService)
        {
            Id = id;
            CustomerId = customerId;
           SetOrderDate(orderDate);
           SetTotalPurchaseAmount(customerService);
        }

        public Customer CustomerId { get; private set; }

        public DateTime OrderDate { get; private set; }

        private List<OrderItem> _orderItems = new();
        public decimal TotalPurchaseAmount { get;private set; }

        private void SetTotalPurchaseAmount(IGetCustomerLastPurchaseDateDomainService customerService)
        {
            if (_orderItems is not null)
            {
                TotalPurchaseAmount = _orderItems.Sum(item => item.TotalPrice);
                var lastPurchaseDate= customerService.GetCustomerPurchaseDate(CustomerId.Id).GetAwaiter().GetResult();

                ApplyDiscountIfEligible(lastPurchaseDate);
                
            }
            else
            {
                TotalPurchaseAmount = default;
            }
   
        }

        public void ApplyDiscountIfEligible(DateTime? lastPurchaseDate)
        {
            if (lastPurchaseDate.HasValue)
            {
                var daysSinceLastPurchase = (DateTime.Now - lastPurchaseDate.Value).Days;

                if (daysSinceLastPurchase < 7)
                {
                    // Apply a 20% discount up to 100,000 tomans
                    var discountAmount = Math.Min(100000, TotalPurchaseAmount * 0.20m);
                    TotalPurchaseAmount -= discountAmount;
                }
                else if (daysSinceLastPurchase < 14)
                {
                    // Apply a 15% discount up to 75,000 tomans
                    var discountAmount = Math.Min(75000, TotalPurchaseAmount * 0.15m);
                    TotalPurchaseAmount -= discountAmount;
                }
            }
        }

        public IEnumerable<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public void AddItems(OrderItem item)
        {
            _orderItems.Add(item);
            SetOrderDate(DateTime.Now);
        }
        private void SetOrderDate(DateTime date)
        {
            OrderDate = date;
        }

        public void RemoveItems(long itemId)
        {
            var orderItem = _orderItems.FirstOrDefault(x => x.Id == itemId);
            if (orderItem != null)
            {
                _orderItems.Remove(orderItem);
            }

        }

    }
}

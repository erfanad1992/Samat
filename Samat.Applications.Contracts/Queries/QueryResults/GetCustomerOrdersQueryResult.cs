using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Samat.Applications.Contracts.Queries.QueryResults
{
    public class GetCustomerOrdersQueryResult 
    {
        public long CustomerId { get; set; }
        public string CustomerFullName { get; set; }
        public OrderDto Orders { get; set; }
    }

    public class ProductDto
    {
        public long ProductId { get; set; }
        public long Name { get; set; }
    }
    public class OrderDto
    {
        public long CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public List<OrderItemDto> OrderItems { get; set; }
    }
    public class OrderItemDto
    {

        public long ItemId { get; set; }

        public long ProductId { get; set; }

        public int Quantity { get; set; }

    }
}

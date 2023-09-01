using Samat.Framework.Domain;

namespace Samat.Domains.Orders
{
    public class Order : AggregateRoot<long>
    {


        public List<OrderItem> _Items { get; private set; }
        public DateTime OrderDate { get; private set; }
    }
}

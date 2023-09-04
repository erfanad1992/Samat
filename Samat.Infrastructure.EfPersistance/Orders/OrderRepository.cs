using Hasti.Framework.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Samat.Domains.Orders;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace Samat.Infrastructure.EfPersistance.Orders
{
    public class OrderRepository : RepositoryBase<Order, long>, IOrderRepository
    {
        public OrderRepository(DbContext context) : base(context)
        {
        }

        protected override IList<Expression<Func<Order, object?>>> GetIncludes()
        {
            return new List<Expression<Func<Order, object>>>
                         {
                             x=> x.OrderItems,
                         };
        }
    }
}

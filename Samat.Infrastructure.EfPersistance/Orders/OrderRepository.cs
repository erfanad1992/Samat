using Microsoft.EntityFrameworkCore;
using Samat.Domains.Orders;
using Samat.Domains.Orders.Entities;
using Samat.Framework.Presistance.EF;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace Samat.Infrastructure.EfPersistance.Orders
{
    public class OrderRepository : RepositoryBase<Order, long>, IOrderRepository
    {
        private readonly SamatDbContext _samatContext;

        public OrderRepository(DbContext context, SamatDbContext samatContext) : base(context)
        {
            _samatContext = samatContext;
        }

        public async Task DeleteAsync(long id)
        {
            var order = await Context.Set<Order>().Include(x => x.OrderItems).FirstOrDefaultAsync(x => x.Id == id);
            if (order != null)
            {
                base.Remove(order);
            }

        }

        public async Task<Order> GetOrder(long id)
        {
            return await _samatContext.Orders.Include(x=>x.OrderItems).FirstOrDefaultAsync(x=>x.Id == id);
        }
        public async Task  RemoveOrderItems(long orderId)
        {
            var order =await Context.Set<Order>().Include(x => x.OrderItems).FirstOrDefaultAsync(x => x.Id == orderId);
            if (order is not null)
            {
                foreach (var orderItem in order.OrderItems)
                {
                    order.RemoveItems(orderItem.Id);
                }

                await Context.SaveChangesAsync();
            }
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

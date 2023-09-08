using Samat.Domains.Orders.Entities;
using System.Linq.Expressions;

namespace Samat.Domains.Orders
{
    public interface IOrderRepository
    {
 
        Task<Order> GetAsync(long id);
        Task<Order> GetAsync(Expression<Func<Order, bool>> predicate);
        Task<IList<Order>> GetListAsync(Expression<Func<Order, bool>> predicate);
        Task InsertAsync(Order order);
        Task<bool> IsExistsAsync(Expression<Func<Order, bool>> predicate);

        Task  RemoveOrderItems(long orderId);
        Task DeleteAsync(long id);

    }
}

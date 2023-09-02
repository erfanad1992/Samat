using Samat.Domains.Orders;
using System.Linq.Expressions;

namespace Samat.Domains.Products
{
    public interface IProductRepository
    {
        Task<Product> GetAsync(long id);
        Task<Product> GetAsync(Expression<Func<Product, bool>> predicate);
        Task<IList<Product>> GetListAsync(Expression<Func<Product, bool>> predicate);
        Task InsertAsync(Product order);
        Task<bool> IsExistsAsync(Expression<Func<Product, bool>> predicate);
        void Remove(Product product);
    }
}

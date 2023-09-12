using System.Linq.Expressions;

namespace Smat.Identity.Domain;

public interface IGenericRepository<T> where T : class
{
    //Task<T> GetByIdAsync(string Id);
    Task<T> GetAsync(Expression<Func<T, bool>> predicate);
    Task<IReadOnlyList<T>> GetListAsync(Expression<Func<T, bool>> predicate);
    Task<bool> IsExistsAsync(Expression<Func<T, bool>> predicate);

    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);

    Task SaveEntityChanges();
}

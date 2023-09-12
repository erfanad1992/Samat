using Microsoft.EntityFrameworkCore;
using Smat.Identity.Domain;
using System;
using System.Linq.Expressions;

namespace Samat.Identity.Persistance.Ef;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T> AddAsync(T entity)
    {
        _context.Add(entity);
        await SaveEntityChanges();
        return entity;
    }
    public async Task<T> UpdateAsync(T entity)
    {
        _context.Update(entity);
        await SaveEntityChanges();
        return entity;
    }
    public async Task<T> DeleteAsync(T entity)
    {
        _context.Remove(entity);
        await SaveEntityChanges();
        return entity;
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate);
    }

    public async Task<IReadOnlyList<T>> GetListAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public async Task<bool> IsExistsAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.AnyAsync(predicate);
    }

    public async Task SaveEntityChanges()
    {
        await _context.SaveChangesAsync();
    }

}

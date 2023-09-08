using Microsoft.EntityFrameworkCore;
using Samat.Domains.Customers;
using Samat.Framework.Presistance.EF;
using System.Linq.Expressions;

namespace Samat.Infrastructure.EfPersistance.Customers
{
    public class CustomerRepository : RepositoryBase<Customer, long>, ICustomerRepository
    {
        public CustomerRepository(DbContext context) : base(context)
        {
        }
        public async Task Create(Customer customer)
        {
            await DbSet.AddAsync(customer);
        }

        protected override IList<Expression<Func<Customer, object?>>> GetIncludes()
        {
            return new List<Expression<Func<Customer, object?>>>();
        }
    }
}

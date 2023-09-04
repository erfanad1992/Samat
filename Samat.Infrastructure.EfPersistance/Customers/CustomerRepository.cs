using Hasti.Framework.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Samat.Domains.Customers;
using System.Linq.Expressions;

namespace Samat.Infrastructure.EfPersistance.Customers
{
    public class CustomerRepository : RepositoryBase<Customer, long>, ICustomerRepository
    {
        public CustomerRepository(DbContext context) : base(context)
        {
        }

        protected override IList<Expression<Func<Customer, object?>>> GetIncludes()
        {
            return new List<Expression<Func<Customer, object?>>>();
        }
    }
}

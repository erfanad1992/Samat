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

        protected override IList<Expression<Func<Customer, object?>>> GetIncludes()
        {
            return new List<Expression<Func<Customer, object?>>>();
        }
    }
}

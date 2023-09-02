﻿using System.Linq.Expressions;

namespace Samat.Domains.Customers
{
    public interface ICustomerRepository
    {
        Task InsertAsync(Customer customer);
        Task<Customer?> GetAsync(Expression<Func<Customer, bool>> predicate);
        Task<Customer> GetAsync(long customerId);
        Task<bool> IsExistsAsync(Expression<Func<Customer, bool>> predicate);
        void Remove(Customer customer);

    }
}

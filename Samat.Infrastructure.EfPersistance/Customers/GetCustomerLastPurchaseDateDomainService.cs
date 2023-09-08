using Samat.Domains.Customers;
using Samat.Domains.Orders.Services;

namespace Samat.Infrastructure.EfPersistance.Customers
{
    public class GetCustomerLastPurchaseDateDomainService : IGetCustomerLastPurchaseDateDomainService
    {
        private readonly ICustomerRepository _customerRepository;
        public async Task<DateTime?> GetCustomerPurchaseDate(long customerId)
        {
            var customer = await _customerRepository.GetAsync(customerId);
            if (customer is not null)
            {
                if (customer.LastPurchaseDate.HasValue)
                {
                    return customer.LastPurchaseDate.Value;
                }else
                {
                    return null;
                }
            
            }
            return null;
        }
    }
}

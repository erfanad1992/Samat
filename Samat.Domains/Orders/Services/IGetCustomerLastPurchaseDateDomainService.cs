namespace Samat.Domains.Orders.Services
{
    public interface IGetCustomerLastPurchaseDateDomainService
    {
        Task<DateTime?> GetCustomerPurchaseDate(long customerId);
    }
}

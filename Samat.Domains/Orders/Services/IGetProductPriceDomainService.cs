using Samat.Domains.Products;

namespace Samat.Domains.Orders.Services
{
    public interface IGetProductPriceDomainService 
    {
        Task<decimal> GetProductPrice(long productId);
    }
}

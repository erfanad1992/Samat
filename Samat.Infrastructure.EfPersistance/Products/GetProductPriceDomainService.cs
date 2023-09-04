using Samat.Domains.Orders.Services;
using Samat.Domains.Products;

namespace Samat.Infrastructure.EfPersistance.Products
{
    public class GetProductPriceDomainService : IGetProductPriceDomainService
    {
        private readonly IProductRepository _productRepository;

        public GetProductPriceDomainService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<decimal> GetProductPrice(long productId)
        {
            var product =await _productRepository.GetAsync(productId);
            if (product!=null)
            {
                return product.Price;
            }
            return 0;
        }
    }
}

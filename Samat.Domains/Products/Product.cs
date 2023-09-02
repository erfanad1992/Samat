using Samat.Framework.Domain;

namespace Samat.Domains.Products
{
    public class Product : AggregateRoot<long>
    {
        private Product()
        {

        }
        public Product(long id ,string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public string Name { get;private set; }
        public decimal Price { get;private set; }

    }
}

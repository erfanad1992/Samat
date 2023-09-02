using Samat.Framework.Domain;

namespace Samat.Domains.Orders.ValueObjects
{
    public class Product : ValueObject
    {
        private Product()
        {

        }

        public Product(long id)
        {
            Id = id;
        }
   
        public long Id { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}

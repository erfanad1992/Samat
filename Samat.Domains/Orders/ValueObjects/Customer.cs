using Samat.Framework.Domain;

namespace Samat.Domains.Orders.ValueObjects
{
    public class Customer : ValueObject
    {
        public long Id { get; }
        private Customer()
        {

        }

        public Customer(long id)
        {
            Id = id;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}

using Samat.Framework.Domain;

namespace Samat.Domains.Customers
{
    public class Customer : AggregateRoot<long>
    {
        private readonly List<long> _orderIds = new();

        public Customer(
            string nationalCode,
            string firstName, 
            string lastName,
            DateTime lastPurchaseDate
            )
        {
            NationalCode = nationalCode;
            FirstName = firstName;
            LastName = lastName;
            LastPurchaseDate = lastPurchaseDate;
        }

        private Customer()
        {

        }
        public string NationalCode  { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get;private set; }
        public DateTime LastPurchaseDate { get; private set; }

        public void Update(string)
        {

        }
        public ICollection<long> OrderIds => _orderIds.AsReadOnly();

        public void AddOrderId(long orderId)
        {
            _orderIds.Add(orderId);
        }
    }
}

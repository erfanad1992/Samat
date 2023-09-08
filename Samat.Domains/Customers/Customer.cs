using Samat.Framework.Domain;

namespace Samat.Domains.Customers
{
    public class Customer : AggregateRoot<long>
    {

        public Customer(
            long id,
            string nationalCode,
            string firstName,
            string lastName,
            DateTime? lastPurchaseDate
            )
        {
            Id = id;
            NationalCode = nationalCode;
            FirstName = firstName;
            LastName = lastName;
            LastPurchaseDate = lastPurchaseDate;
        }

        private Customer()
        {

        }
        public static Customer Build(long id, string firstName, string lastName, string nationalCode, DateTime? lastPurchaseDate)
        {
            return new Customer(id, nationalCode, firstName, lastName, lastPurchaseDate);
        }
        public string NationalCode { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime? LastPurchaseDate { get; private set; }

        public void Update(string nationalCode, string firstName, string lastName, DateTime? lastPurchaseDate)
        {
            NationalCode = nationalCode;
            FirstName = firstName;
            LastName = lastName;
            LastPurchaseDate = lastPurchaseDate;
        }

    }
}

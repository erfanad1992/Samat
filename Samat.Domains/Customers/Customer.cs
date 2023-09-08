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


        //public void ApplyDiscountIfEligible()
        //{
        //    if (LastPurchaseDate.HasValue)
        //    {
        //        var daysSinceLastPurchase = (DateTime.Now - LastPurchaseDate.Value).Days;

        //        if (daysSinceLastPurchase < 7)
        //        {
        //            // Apply a 20% discount up to 100,000 tomans
        //            var discountAmount = Math.Min(100000, TotalPurchaseAmount * 0.20m);
        //            TotalPurchaseAmount -= discountAmount;
        //        }
        //        else if (daysSinceLastPurchase < 14)
        //        {
        //            // Apply a 15% discount up to 75,000 tomans
        //            var discountAmount = Math.Min(75000, TotalPurchaseAmount * 0.15m);
        //            TotalPurchaseAmount -= discountAmount;
        //        }
        //    }
        //}
        public void Update(string nationalCode, string firstName, string lastName, DateTime? lastPurchaseDate)
        {
            NationalCode = nationalCode;
            FirstName = firstName;
            LastName = lastName;
            LastPurchaseDate = lastPurchaseDate;
        }

    }
}

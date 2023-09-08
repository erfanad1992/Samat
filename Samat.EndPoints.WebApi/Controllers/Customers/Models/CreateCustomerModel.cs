using Samat.Applications.Contracts.Commands;

namespace Samat.EndPoints.WebApi.Controllers.Customers.Models
{
    public class CreateCustomerModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }

        internal CreateCustomerCommand ToCommand()
        {
            return new CreateCustomerCommand
                (
            
                FirstName = FirstName,
                LastName = LastName,
                NationalCode = NationalCode
                 );
        }
    }
}

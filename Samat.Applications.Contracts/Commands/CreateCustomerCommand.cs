using MediatR;

namespace Samat.Applications.Contracts.Commands
{
    public class CreateCustomerCommand : IRequest<long>
    {
        public string FirstName { get;private set; }
        public string LastName { get;private set;}
        public string NationalCode { get;private set; }


    }
}

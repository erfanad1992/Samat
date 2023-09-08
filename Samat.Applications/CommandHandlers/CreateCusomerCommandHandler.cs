using IdGen;
using MediatR;
using Samat.Applications.Contracts.Commands;
using Samat.Domains.Customers;
using Samat.Framework.Domain;

namespace Samat.Applications.CommandHandlers
{
    public class CreateCusomerCommandHandler : IRequestHandler<CreateCustomerCommand,long>
    {
        private readonly ICustomerRepository _repository;
        private readonly IIdGenerator _idGenerator;

        public CreateCusomerCommandHandler(IIdGenerator idGenerator, ICustomerRepository repository)
        {
            _idGenerator = idGenerator;
            _repository = repository;
        }

        public  async Task<long> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            var id = _idGenerator.GetNewId();
            var customer = Customer.Build(id, command.FirstName, command.LastName, command.NationalCode,null);
            await _repository.Create(customer);
            return id;

        }
    }
}

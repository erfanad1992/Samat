using MediatR;
using Samat.Applications.Contracts.Queries.QueryResults;

namespace Samat.Applications.Contracts.Queries.QueryFilters
{
    public class GetCustomerOrdersQueryFilter : IRequest<GetCustomerOrdersQueryResult>
    {

        public long CustomerId { get; set; }
    }
}

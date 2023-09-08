using MediatR;
using Microsoft.AspNetCore.Mvc;
using Samat.EndPoints.WebApi.Controllers.Customers.Models;
using Samat.EndPoints.WebApi.Controllers.Orders.Models;
using Samat.Framework.Endpoints.Web.Controllers;
using Samat.Framework.Endpoints.Web.Results;

namespace Samat.EndPoints.WebApi.Controllers.Orders
{

    [ApiController]

    [Route("Orders")]
    public class OrderController : ApiControllerBase
    {
        public OrderController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ApiResult> CreateOrder(CreateOrderModel model, CancellationToken cancellationToken)
        {
           
            var command = model.ToCommand();
            await Mediator.Send(command, cancellationToken);
            return OkApiResult();
        }
    }
}
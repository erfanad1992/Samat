using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Samat.Applications.Contracts.Commands;
using Samat.EndPoints.WebApi.Controllers.Customers.Models;
using Samat.EndPoints.WebApi.Controllers.OrderItems.Models;
using Samat.Framework.Endpoints.Web.Controllers;
using Samat.Framework.Endpoints.Web.Results;

namespace Samat.EndPoints.WebApi.Controllers.OrderItems
{
    [ApiController]
    [Route("OrderItems")]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class OrderItemController : ApiControllerBase
    {
        public OrderItemController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]

        public async Task<ApiResult> AddOrderItem(long orderId, AddOrderItemModel model, CancellationToken cancellationToken)
        {
            
            var command = model.ToCommand(orderId);
            await Mediator.Send(command, cancellationToken);
            return OkApiResult();
        }

        [HttpDelete("{orderId}/{orderItemId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ApiResult> RemoveOrderItem(long orderId, long orderItemId, CancellationToken cancellationToken)
        {

            var command = new RemoveOrderItemFromOrderCommand(orderId, orderItemId);
            await Mediator.Send(command, cancellationToken);
            return OkApiResult();
        }
    }
}
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Samat.Applications.Contracts.Commands;
using Samat.EndPoints.WebApi.Controllers.Customers.Models;
using Samat.Framework.Endpoints.Web.Controllers;
using Samat.Framework.Endpoints.Web.Results;

namespace Samat.EndPoints.WebApi.Controllers.Customers
{
    [ApiController]
    [Route("Customers")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CustomerController : ApiControllerBase
    {
        public CustomerController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ApiResult> Create(CreateCustomerModel model, CancellationToken cancellationToken)
        {
            var validator = new CreateCustomerModelValidator();
            var validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
            {
                // Handle validation errors
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequestApiResult(errors);
            }
            var command = model.ToCommand();
            var result = await Mediator.Send(command, cancellationToken);
            return OkApiResult(result);
        }
    }
}
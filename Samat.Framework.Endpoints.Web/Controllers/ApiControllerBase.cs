using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Samat.Framework.Endpoints.Web.Controllers;

[ApiController]
public abstract class ApiControllerBase : InternalControllerBase
{
    protected IMediator Mediator;

    public ApiControllerBase(IMediator mediator)
    {
        Mediator = mediator;
    }
}

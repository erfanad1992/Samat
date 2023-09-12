using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Samat.EndPoints.WebApi.Controllers.Identities.Dtos.authenticate;
using Samat.Identity.Application.Services;
using Samat.Identity.Application.Services.Dtos;

namespace Samat.EndPoints.WebApi.Controllers.Identities;

[ApiController]
[Route("[controller]/[action]")]
public class AuthenticateController : Controller
{

    private readonly IUserAuthentication _UserAuthentication;
    public AuthenticateController(IUserAuthentication userAuthentication)
    {
        _UserAuthentication = userAuthentication;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult> Login(
        [FromBody] LoginRequestDto requestDto
        , CancellationToken cancellationToken)
    {
        try
        {
            var result =await _UserAuthentication.Authorize(requestDto.Email, requestDto.Password);
            return Ok(result);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult> Register(
        [FromBody] RegisterRequestDto requestDto
        , CancellationToken cancellationToken)
    {
        try
        {
            RegisterDto model = new RegisterDto()
            {
                Email = requestDto.Email,
                Password = requestDto.Password,
                Username = requestDto.Username,
            };
           var result = await _UserAuthentication.Register(model);
            return Ok(result);
        }
        catch (Exception)
        {
            throw;
        }
    }


}

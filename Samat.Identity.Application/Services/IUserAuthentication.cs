using Microsoft.Extensions.Configuration;
using Samat.Identity.Application.Services.Dtos;
using System.Security.Claims;

namespace Samat.Identity.Application.Services;

public interface IUserAuthentication
{
    Task<LoginResponseDto> Authorize(string email, string password);
    Task<RegisterResponseDto> Register(RegisterDto model);


}



using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Samat.Identity.Application.Services.Dtos;
using Samat.Identity.Persistance.Ef;
using Smat.Identity.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Samat.Identity.Application.Services;

public class UserAuthentication : IUserAuthentication
{

    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IConfiguration _configuration;
    private readonly ApplicationDbContext _dbContext;


    public UserAuthentication(UserManager<ApplicationUser> userManager,
          IConfiguration configuration,
          ApplicationDbContext dbContext)
    {
        _userManager = userManager;
        _configuration = configuration;
        _dbContext = dbContext;
    }



    public async Task<LoginResponseDto> Authorize(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);
        var pass = await _userManager.CheckPasswordAsync(user, password);
        if (user != null && pass)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return new LoginResponseDto
            {
                code = 200,
                message = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }
        return new LoginResponseDto
        {
            code = 401,
            message = "UnAuthorized!"
        };
    }

    public async Task<RegisterResponseDto> Register(RegisterDto model)
    {
        var userExists = await _userManager.FindByNameAsync(model.Username);
        if (userExists != null)
            return new RegisterResponseDto
            {
                code = 500,
                message = "User Already Exists"
            };

        ApplicationUser user = new ApplicationUser()
        {
            Email = model.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = model.Username
        };
        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
            return new RegisterResponseDto
            {
                code = 500,
                message = "Failed"
            };

        return new RegisterResponseDto
        {
            code = 200,
            message = "User created successfully!"
        };

    }
}

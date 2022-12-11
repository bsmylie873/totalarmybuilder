using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TotalArmyBuilder.Api.Controllers.Base;
using TotalArmyBuilder.Api.ViewModels.AuthenticationRequest;
using TotalArmyBuilder.Service.DTOs;
using TotalArmyBuilder.Service.Interfaces;

namespace TotalArmyBuilder.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : TotalArmyBaseController
{
    private readonly IMapper _mapper;
    private readonly IAuthenticationService _service;

    public AuthenticationController(IMapper mapper, IAuthenticationService service)
    {
        (_mapper, _service) = (mapper, service);
    }
    
    [HttpPost]
    [AllowAnonymous]
    public ActionResult<AuthenticationResultViewModel> Authenticate([FromBody] AuthenticationRequestViewModel authenticationRequestViewModel)
    {
        var account =
            _service.Authenticate(authenticationRequestViewModel.Email, authenticationRequestViewModel.Password);

        if (account == null) return Unauthorized();

        return new AuthenticationResultViewModel
        {
            AccessToken = GenerateToken(account, 600)
        };
    }
    
    private string GenerateToken(AccountDto account, int expirationTimeInMinutes)
    {
        var secretKey = Encoding.UTF8.GetBytes("JWTMySonTheDayYouWereBorn");
        var securityKey = new SymmetricSecurityKey(secretKey);
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var expiryTime = DateTime.UtcNow.AddMinutes(expirationTimeInMinutes);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
             
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
                new Claim(ClaimTypes.Email, account.Email),
                new Claim(ClaimTypes.Role, "User")
            }),
            Expires = expiryTime,
            SigningCredentials = credentials
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
         
        var tokenString = tokenHandler.WriteToken(jwtToken);
        return tokenString;
    }
}
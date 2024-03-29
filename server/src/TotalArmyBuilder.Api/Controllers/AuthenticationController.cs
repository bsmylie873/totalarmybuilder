using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TotalArmyBuilder.Api.Authentication;
using TotalArmyBuilder.Api.Controllers.Base;
using TotalArmyBuilder.Api.ViewModels.AuthenticationRequest;
using TotalArmyBuilder.Service.DTOs;
using TotalArmyBuilder.Service.Interfaces;

namespace TotalArmyBuilder.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[EnableCors]
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
            AccessToken = GenerateToken(account, 20, TokenTypes.AccessToken), 
            RefreshToken = GenerateToken(account, 18000, TokenTypes.RefreshToken)
        };
    }
    
    [HttpGet("refresh")]
    public ActionResult<AuthenticationResultViewModel> Refresh([FromServices] IAuthorisedAccountProvider authorizedAccountProvider)
    {

        var account = authorizedAccountProvider.GetLoggedInAccount();
        
        if (account is null) return Unauthorized();
        
        return new AuthenticationResultViewModel
        {
            AccessToken = GenerateToken(account, 10, TokenTypes.AccessToken), 
            RefreshToken = GenerateToken(account, 18000, TokenTypes.RefreshToken)
        };
    }
    
    private string GenerateToken(AccountDto account, int expirationTimeInMinutes, TokenTypes tokenType)
    {
        var secretKey = Encoding.UTF8.GetBytes(tokenType == TokenTypes.AccessToken ? "JWTMySonTheDayYouWereBorn" : "JWTForestsWhisperedYourName");
        var securityKey = new SymmetricSecurityKey(secretKey);
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var expiryTime = DateTime.UtcNow.AddMinutes(expirationTimeInMinutes);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
             
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, account.Id.ToString()),
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
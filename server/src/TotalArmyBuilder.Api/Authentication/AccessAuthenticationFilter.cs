using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace TotalArmyBuilder.Api.Authentication;

public class AccessAuthenticationFilter : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly IHttpContextAccessor _contextAccessor;
    
    public AccessAuthenticationFilter(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IHttpContextAccessor contextAccessor) 
        : base(options, logger, encoder, clock)
    {
        _contextAccessor = contextAccessor;
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var header = _contextAccessor.HttpContext?.Request.Headers["accessToken"].ToString();
        var claims = new[] { new Claim(ClaimTypes.Upn, "brandon.smylie@unosquare.com"), new Claim(ClaimTypes.Name, "Brandon Smylie")};
        var identity = new ClaimsIdentity(claims, "AccessToken");
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, "AccessToken");

        //return Task.FromResult(AuthenticateResult.Success(ticket));
        return Task.FromResult(AuthenticateResult.Fail("Failed"));
    }
}
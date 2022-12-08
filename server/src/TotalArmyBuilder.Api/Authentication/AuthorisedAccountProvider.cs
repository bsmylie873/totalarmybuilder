using System.Security.Claims;
using TotalArmyBuilder.Service.DTOs;
using TotalArmyBuilder.Service.Interfaces;

namespace TotalArmyBuilder.Api.Authentication;

public class AuthorisedAccountProvider : IAuthorisedAccountProvider
{
    private AccountDto? _account;
    private readonly IAccountService _accountService;
    private readonly IHttpContextAccessor _contextAccessor;

    public AuthorisedAccountProvider(IAccountService accountService, IHttpContextAccessor contextAccessor)
    {
        _accountService = accountService;
        _contextAccessor = contextAccessor;
    }
    
    public AccountDto GetLoggedInAccount()
    {
        if (_account != null) return _account;

        var identifier = _contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrWhiteSpace(identifier)) return null;

        _account = _accountService.GetAccountById(int.Parse(identifier));

        return _account;
    }
}

public interface IAuthorisedAccountProvider
{
    AccountDto GetLoggedInAccount();
}
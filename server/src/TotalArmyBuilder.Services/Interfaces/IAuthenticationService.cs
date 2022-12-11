using TotalArmyBuilder.Service.DTOs;

namespace TotalArmyBuilder.Service.Interfaces;

public interface IAuthenticationService
{
    AccountDto Authenticate(string email, string password);
}
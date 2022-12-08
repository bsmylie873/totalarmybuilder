using TotalArmyBuilder.Service.DTOs;

namespace TotalArmyBuilder.Service.Interfaces;

public interface IAuthenticateService
{
    AccountDto Authenticate(string email, string password);
}
using TotalArmyBuilder.Service.DTOs;

namespace TotalArmyBuilder.Service.Interfaces;

public interface IAccountService
{
    IList<AccountDto> GetAccounts(string? username = null, string? email = null);
    void UpdateAccount(int id, AccountDto accountDto);
}
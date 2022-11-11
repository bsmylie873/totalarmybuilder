using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Service.DTOs;

namespace TotalArmyBuilder.Service.Interfaces;

public interface IAccountService
{
    IList<AccountDto> GetAccounts(string? username = null, string? email = null);
    IList<AccountDto> GetAccountById(int id);
    void CreateAccount(Account account);
    void UpdateAccount(int id, AccountDto accountDto);
    void DeleteAccount(int id);
}
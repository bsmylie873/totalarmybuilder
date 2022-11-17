using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Service.DTOs;

namespace TotalArmyBuilder.Service.Interfaces;

public interface IAccountService
{
    IList<AccountDto> GetAccounts(string? username = null, string? email = null);
    AccountDto GetAccountById(int id);
    IList<CompositionDto> GetAccountCompositions(int id);
    void CreateAccount(AccountDto account);
    void UpdateAccount(int id, AccountDto accountDto);
    void DeleteAccount(int id);
}
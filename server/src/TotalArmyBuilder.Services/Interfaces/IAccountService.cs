using TotalArmyBuilder.Service.DTOs;

namespace TotalArmyBuilder.Service.Interfaces;

public interface IAccountService
{
    IList<AccountDTO> GetAccounts();
}
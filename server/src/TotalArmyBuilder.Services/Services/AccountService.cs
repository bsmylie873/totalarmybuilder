using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using TotalArmyBuilder.Dal.Interfaces;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Service.DTOs;
using TotalArmyBuilder.Service.Interfaces;

namespace TotalArmyBuilder.Service.Services;

public class AccountService : IAccountService
{
    private readonly ITotalArmyDatabase _database;
    public AccountService(ITotalArmyDatabase database) => _database = database;

    public IList<AccountDTO> GetAccounts()
    {
        var accounts = _database.Get<Account>().ToList();
        //TODO: Use automapper to map to DTOs
        
    }
}



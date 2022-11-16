using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using TotalArmyBuilder.Dal.Interfaces;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Dal.Specifications.Accounts;
using TotalArmyBuilder.Dal.Specifications.Compositions;
using TotalArmyBuilder.Service.DTOs;
using TotalArmyBuilder.Service.Interfaces;
using Unosquare.EntityFramework.Specification.Common.Extensions;

namespace TotalArmyBuilder.Service.Services;

public class AccountService : IAccountService
{
    private readonly ITotalArmyDatabase _database;
    private readonly IMapper _mapper;
    public AccountService(ITotalArmyDatabase database, IMapper mapper) => 
        (_database, _mapper) = (database, mapper);

    public IList<AccountDto> GetAccounts(string? username, string? email)
    {
        var accountQuery = _database
            .Get<Account>()
            .Where(new AccountSearchSpec(username, email));

        return _mapper
            .ProjectTo<AccountDto>(accountQuery)
            .ToList(); ;
    }

    public AccountDto GetAccountById(int id)
    {
        var accountQuery = _database
            .Get<Account>()
            .Where(new AccountByIdSpec(id));

        return _mapper
            .ProjectTo<AccountDto>(accountQuery)
            .SingleOrDefault(); ;
    }
    
    public IList<CompositionDto> GetCompositionsByAccount(int id)
    {
        var compositionsQuery = _database
            .Get<Composition>()
            .Where(new CompositionByAccountSpec(id));

        return _mapper
            .ProjectTo<CompositionDto>(compositionsQuery)
            .ToList(); ;
    }
    
    public void CreateAccount(AccountDto account)
    {
        var newAccount = new Account(); 
        _mapper.Map(account, newAccount);
        _database.Add(newAccount);
        _database.SaveChanges();
    }


    public void UpdateAccount(int id, AccountDto account)
    {
        var currentAccount = _database
            .Get<Account>()
            .FirstOrDefault(new AccountByIdSpec(id));

        if (currentAccount == null) throw new Exception("Not Found");

        _mapper.Map(account, currentAccount);
        currentAccount.Id = id;
        _database.SaveChanges();
    }
    
    public void DeleteAccount(int id)
    {
        var currentAccount = _database
            .Get<Account>()
            .FirstOrDefault(new AccountByIdSpec(id));

        if (currentAccount == null) throw new Exception("Not Found");
        
        _database.Delete(currentAccount);
        _database.SaveChanges();
    }
}



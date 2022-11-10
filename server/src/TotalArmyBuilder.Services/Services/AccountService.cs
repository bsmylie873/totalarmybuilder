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

    public IList<AccountDTO> GetAccounts()
    {
        var accounts = _mapper.ProjectTo<AccountDTO>(
            _database.Get<Account>()
        ).ToList();

        return (accounts);
    }

    public IList<AccountDTO> GetAccountById(int id)
    {
        var account = _mapper.ProjectTo<AccountDTO>(
            _database
                .Get<Account>()
                .Where(new AccountByIdSpec(id))
        );
        return(account);
    }

    public IList<AccountDTO> TestMethod
    {
        get { throw new NotImplementedException(); }
        set { throw new NotImplementedException(); }
    }
}



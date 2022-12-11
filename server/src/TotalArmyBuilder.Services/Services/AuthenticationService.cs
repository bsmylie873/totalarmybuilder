using System.Security.Claims;
using System.Text;
using AutoMapper;
using TotalArmyBuilder.Dal.Interfaces;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Dal.Specifications.Accounts;
using TotalArmyBuilder.Service.DTOs;
using TotalArmyBuilder.Service.Interfaces;
using Unosquare.EntityFramework.Specification.Common.Extensions;

namespace TotalArmyBuilder.Service.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly ITotalArmyDatabase _database;
    private readonly IMapper _mapper;

    public AuthenticationService(ITotalArmyDatabase database, IMapper mapper)
    {
        (_database, _mapper) = (database, mapper);
    }

    public AccountDto? Authenticate(string email, string password)
    {
        var account = _database.Get<Account>().Where(new AccountByEmailSpec(email)).SingleOrDefault();

        if (account == null || !BCrypt.Net.BCrypt.Verify(password, account.Password)) return null;

        return _mapper.Map<AccountDto>(account);
    }

}
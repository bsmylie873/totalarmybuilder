using AutoFixture.Xunit2;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using TotalArmyBuilder.Dal.Interfaces;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Service.DTOs;
using TotalArmyBuilder.Service.Interfaces;
using TotalArmyBuilder.Service.Profiles;
using TotalArmyBuilder.Service.Services;


namespace TotalArmyBuilder.Services.Test.Services;

public class AccountServiceTests
{
    private readonly ITotalArmyDatabase _database;
    private readonly IMapper _mapper;
    
    private IAccountService RetrieveService()
    {
        return new AccountService(_database, _mapper);
    }

    private static IMapper GetMapper()
    {
        var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<AccountProfile>();
            });
            return new Mapper(config);
    }

    public AccountServiceTests()
    {
        _database = Substitute.For<ITotalArmyDatabase>();
        _mapper = GetMapper();
    }

    [Fact]
    public void GetAccountById_WhenAccountExist_ReturnsAccount()
    {
        // Arrange
        const int id = 1;
        const int id2 = 2;

        var account = new Account
        {
            Id = id
        };
        
        var account2 = new Account
        {
            Id = id2
        };

        var accountList = new List<Account>
        {
            account, account2
        };
        

        _database.Get<Account>().Returns(accountList.AsQueryable());

        var service = RetrieveService();

        // Act
        var result = service.GetAccountById(id);

        // Assert
        result.Should().BeEquivalentTo(account, options => options.ExcludingMissingMembers());
    }
    
    [Theory, AutoData]
    public void GetAccounts_WhenAccountsExist_ReturnsAccount(string username, string email)
    {
        // Arrange
        const int id = 1;
        const int id2 = 2;

        var account = new Account
        {
            Id = id,
            Username = username,
            Email = email
        };
        
        var account2 = new Account
        {
            Id = id2,
            Username = username,
            Email = email
        };

        var accountList = new List<Account>
        {
            account, account2
        };

        _database.Get<Account>().Returns(accountList.AsQueryable());

        var service = RetrieveService();

        // Act
        var result = service.GetAccounts();

        // Assert
        result.Should().BeEquivalentTo(accountList, options => options.ExcludingMissingMembers());
    }

    /*[Fact]
    public void GetAccountCompositions_WhenAccountCompositionsExist_ReturnsCompositions()
    {
        // Arrange
        const int id = 1;
        const int id2 = 2;

        var account = new Account
        {
            Id = id
        };
        
        var composition = new Composition
        {
            Id = id,
        };
        
        var composition2 = new Composition
        {
            Id = id2,
        };

        var compositionList = new List<Composition>
        {
            composition, composition2
        };

        _database.Get<Composition>().Returns(compositionList.AsQueryable());

        var service = RetrieveService();

        // Act
        var result = service.GetAccountCompositions(id);

        // Assert
        result.Should().BeEquivalentTo(compositionList, options => options.ExcludingMissingMembers());
    }*/
    
    [Theory, AutoData]
    public void CreateAccount_MappedAndSaved(string username, string email, string password)
    {
        // Arrange
        const int id = 1;

        var account = new Account
        {
            Id = id,
            Username = username,
            Email = email,
            Password = password
        };

        var accountDto = new AccountDto();
        _mapper.Map(account,accountDto);
        _database.Add(accountDto);

        var service = RetrieveService();
        
        // Act
        service.CreateAccount(accountDto);
        var result = service.GetAccountById(id);
        
        // Assert
        result.Should().BeEquivalentTo(account, options => options.ExcludingMissingMembers());
    }
}
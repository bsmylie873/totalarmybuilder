using AutoFixture;
using AutoFixture.Xunit2;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using TotalArmyBuilder.Dal.Interfaces;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Dal.Specifications.Accounts;
using TotalArmyBuilder.Service.DTOs;
using TotalArmyBuilder.Service.Interfaces;
using TotalArmyBuilder.Service.Profiles;
using TotalArmyBuilder.Service.Services;
using TotalArmyBuilder.Services.Test.Customisations;


namespace TotalArmyBuilder.Services.Test.Services;

public class AccountServiceTests
{
    private readonly ITotalArmyDatabase _database;
    private readonly IMapper _mapper;
    private readonly IFixture _fixture;

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
        _fixture = new Fixture();
    }

    [Fact]
    public void GetAccountById_WhenAccountExist_ReturnsAccount()
    {
        // Arrange
        _fixture.Customize(new AccountCustomisation("test"));
        var accountList = _fixture.CreateMany<Account>(5);
        _database.Get<Account>().Returns(accountList.AsQueryable());

        var service = RetrieveService();

        // Act
        var result = service.GetAccountById(accountList.First().Id);

        // Assert
        result.Should().BeEquivalentTo(accountList.First(), options => options.ExcludingMissingMembers());
    }

    [Fact]
    public void GetAccounts_WhenAccountsExist_ReturnsAccount()
    {
        // Arrange
        _fixture.Customize(new AccountCustomisation("test"));
        var accountList = _fixture.CreateMany<Account>(5);
        _database.Get<Account>().Returns(accountList.AsQueryable());

        var service = RetrieveService();

        // Act
        var result = service.GetAccounts();

        // Assert
        result.Should().BeEquivalentTo(accountList, options => options.ExcludingMissingMembers());
    }

    [Fact]
    public void CreateAccount_MappedAndSaved()
    {
        // Arrange
        _fixture.Customize(new AccountCustomisation("test"));
        var account = _fixture.Create<Account>();
        var service = RetrieveService();

        // Act
        service.CreateAccount(_mapper.Map<AccountDto>(account));

        // Assert
        _database.Received(1).SaveChanges();
        _database.Received(1).Add(Arg.Is<Account>(x => x.Username == account.Username));
    }
    
    [Fact]
    public void UpdateAccount_MappedAndSaved()
    {
        // Arrange
        _fixture.Customize(new AccountCustomisation("test"));
        var accountList = _fixture.CreateMany<Account>(5);
        var accountDto = _mapper.Map<AccountDto>(accountList.First());
        
        _database.Get<Account>().Returns(accountList.AsQueryable());
        
        var service = RetrieveService();

        // Act
        service.UpdateAccount(accountList.First().Id, accountDto);

        // Assert
        _database.Received(1).Get<Account>();
        _database.Received(1).SaveChanges();
    }
}
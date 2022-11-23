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
    private readonly IMapper _compositionMapper;
    private readonly IFixture _fixture;

    private IAccountService RetrieveService()
    {
        return new AccountService(_database, _mapper);
    }
    
    private IAccountService RetrieveServiceComposition()
    {
        return new AccountService(_database, _compositionMapper);
    }

    private static IMapper GetMapper()
    {
        var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<AccountProfile>();
            });
            return new Mapper(config);
    }
    
    private static IMapper GetCompositionMapper()
    {
        var config = new MapperConfiguration(cfg => {
            cfg.AddProfile<CompositionProfile>();
        });
        return new Mapper(config);
    }
    
    private void HandleFixtureRecursion()
    {
        _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => _fixture.Behaviors.Remove(b));
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));
    }

    public AccountServiceTests()
    {
        _database = Substitute.For<ITotalArmyDatabase>();
        _mapper = GetMapper();
        _compositionMapper = GetCompositionMapper();
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
    public void GetAccountCompositions_WhenCompositionsExist_ReturnsCompositions()
    {
        // Arrange
        HandleFixtureRecursion();
        _fixture.Customize(new AccountCustomisation("test"));
        var accountList = _fixture.Build<Account>().CreateMany(5);
        _database.Get<Account>().Returns(accountList.AsQueryable());
        
        
        _fixture.Customize(new CompositionCustomisation("test"));
        var compositionList = _fixture.CreateMany<Composition>(5);
        _database.Get<Composition>().Returns(compositionList.AsQueryable());
        
        var service = RetrieveServiceComposition();
        

        // Act
        var result = service.GetAccountCompositions(accountList.First().Id);

        // Assert
        result.Should().BeEquivalentTo(compositionList, options => options.ExcludingMissingMembers());
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
        var accountList = _fixture.CreateMany<Account>(5).AsQueryable();
        var accountDto = _fixture
            .Build<AccountDto>()
            .Without(x=> x.Compositions)
            .With(x=> x.Id, accountList.First().Id)
            .Create();

        _database.Get<Account>().Returns(accountList);
        
        var service = RetrieveService();

        _database.When(x=> x.SaveChanges()).Do(x =>
        {
            accountList.First()
                .Should()
                .BeEquivalentTo(accountDto, o=>o.ExcludingMissingMembers());
        });
        
        // Act
        service.UpdateAccount(accountList.First().Id, accountDto);

        // Assert
        _database.Received(1).Get<Account>();
        _database.Received(1).SaveChanges();
    }
    
    [Fact]
    public void DeleteAccount_MappedAndSaved()
    {
        // Arrange
        _fixture.Customize(new AccountCustomisation("test"));
        var accountList = _fixture.CreateMany<Account>(5);

        _database.Get<Account>().Returns(accountList.AsQueryable());
        
        var service = RetrieveService();

        // Act
        service.DeleteAccount(accountList.First().Id);

        // Assert
        _database.Received(1).Get<Account>();
        _database.Received(1).Delete(accountList.First());
        _database.Received(1).SaveChanges();
    }
}
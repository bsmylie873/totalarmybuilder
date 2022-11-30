using AutoFixture;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using TotalArmyBuilder.Dal.Interfaces;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Service.DTOs;
using TotalArmyBuilder.Service.Interfaces;
using TotalArmyBuilder.Service.Profiles;
using TotalArmyBuilder.Service.Services;
using TotalArmyBuilder.Service.Services.Exceptions;
using TotalArmyBuilder.Services.Test.Customisations;
using TotalArmyBuilder.Services.Test.Extensions;

namespace TotalArmyBuilder.Services.Test.Services;

public class AccountServiceTests
{
    private readonly ITotalArmyDatabase _database;
    private readonly IFixture _fixture;
    private readonly IMapper _mapper;

    public AccountServiceTests()
    {
        _database = Substitute.For<ITotalArmyDatabase>();
        _mapper = GetMapper();
        _fixture = new Fixture();

        _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => _fixture.Behaviors.Remove(b));
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));
    }

    private IAccountService RetrieveService()
    {
        return new AccountService(_database, _mapper);
    }

    private static IMapper GetMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<AccountProfile>();
            cfg.AddProfile<CompositionProfile>();
        });
        return new Mapper(config);
    }

    [Fact]
    public void GetAccountById_WhenAccountExist_ReturnsAccount()
    {
        const int accountId = 1;

        var accountIds = _fixture.MockWithOne(accountId);

        // Arrange
        _fixture.Customize(new AccountCustomisation());
        var accountList = _fixture
            .Build<Account>()
            .With(x => x.Id, accountIds.GetValue)
            .CreateMany(5)
            .AsQueryable();
        _database.Get<Account>().Returns(accountList);

        var service = RetrieveService();

        // Act
        var result = service.GetAccountById(accountId);

        // Assert
        result.Should().BeEquivalentTo(accountList.First(), options => options.ExcludingMissingMembers());
    }

    [Fact]
    public void GetAccounts_WhenAccountsExist_ReturnsAccount()
    {
        // Arrange
        _fixture.Customize(new AccountCustomisation());
        var accountList = _fixture.CreateMany<Account>(5).AsQueryable();
        _database.Get<Account>().Returns(accountList);

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
        const int accountId = 1;
        const int compositionId = 1;

        var accountIds = _fixture.MockWithOne(accountId);

        var accountCompositionList = _fixture
            .Build<AccountComposition>()
            .With(x => x.AccountId, accountIds.GetValue)
            .With(x => x.CompositionId, compositionId)
            .CreateMany(5)
            .ToList();

        var compositionList = _fixture
            .Build<Composition>()
            .With(x => x.Id, compositionId)
            .With(x => x.AccountCompositions, accountCompositionList)
            .CreateMany(5)
            .AsQueryable();

        _database.Get<Composition>().Returns(compositionList);

        var service = RetrieveService();

        // Act
        var result = service.GetAccountCompositions(accountId);

        // Assert
        result.Should().BeEquivalentTo(compositionList, options => options.ExcludingMissingMembers());
    }

    [Fact]
    public void CreateAccount_MappedAndSaved()
    {
        // Arrange
        _fixture.Customize(new AccountCustomisation());
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
        const int accountId = 1;

        var accountIds = _fixture.MockWithOne(accountId);

        _fixture.Customize(new AccountCustomisation());
        var accountList = _fixture
            .Build<Account>()
            .With(x => x.Id, accountIds.GetValue)
            .CreateMany(5)
            .AsQueryable();

        var accountDto = _fixture
            .Build<AccountDto>()
            .Without(x => x.Compositions)
            .With(x => x.Id, accountId)
            .Create();

        _database.Get<Account>().Returns(accountList);

        var service = RetrieveService();

        _database.When(x => x.SaveChanges()).Do(x =>
        {
            accountList.First()
                .Should()
                .BeEquivalentTo(accountDto, o => o.ExcludingMissingMembers());
        });

        // Act
        service.UpdateAccount(accountId, accountDto);

        // Assert
        _database.Received(1).Get<Account>();
        _database.Received(1).SaveChanges();
    }

    [Fact]
    public void UpdateAccount_AccountDoesNotExist_ThrowsNotFoundException()
    {
        // Arrange
        const int accountId = 1;

        var accountIds = _fixture.MockWithOne(accountId);

        _fixture.Customize(new AccountCustomisation());
        var accountList = _fixture
            .Build<Account>()
            .With(x => x.Id, accountIds.GetValue)
            .CreateMany(0)
            .AsQueryable();

        var accountDto = _fixture
            .Build<AccountDto>()
            .Without(x => x.Compositions)
            .With(x => x.Id, accountId)
            .Create();

        _database.Get<Account>().Returns(accountList);

        var service = RetrieveService();

        // Act & Assert
        Assert.Throws<NotFoundException>(() => service.UpdateAccount(accountId, accountDto));
    }

    [Fact]
    public void DeleteAccount_MappedAndSaved()
    {
        // Arrange
        const int accountId = 1;

        var accountIds = _fixture.MockWithOne(accountId);

        _fixture.Customize(new AccountCustomisation());
        var accountList = _fixture
            .Build<Account>()
            .With(x => x.Id, accountIds.GetValue)
            .CreateMany(5)
            .AsQueryable();

        _database.Get<Account>().Returns(accountList);

        var service = RetrieveService();

        // Act
        service.DeleteAccount(accountId);

        // Assert
        _database.Received(1).Get<Account>();
        _database.Received(1).Delete(accountList.First());
        _database.Received(1).SaveChanges();
    }

    [Fact]
    public void DeleteAccount_AccountDoesNotExist_ThrowsNotFoundException()
    {
        // Arrange
        const int accountId = 1;
        const int wrongId = 2;

        var accountIds = _fixture.MockWithOne(accountId);

        _fixture.Customize(new AccountCustomisation());
        var accountList = _fixture
            .Build<Account>()
            .With(x => x.Id, accountIds.GetValue)
            .CreateMany(1)
            .AsQueryable();

        _database.Get<Account>().Returns(accountList);

        var service = RetrieveService();

        // Act & Assert
        Assert.Throws<NotFoundException>(() => service.DeleteAccount(wrongId));
    }
}
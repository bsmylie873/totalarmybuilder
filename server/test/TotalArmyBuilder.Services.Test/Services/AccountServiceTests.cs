﻿using AutoFixture;
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

    [Fact]
    public void GetAccounts_WhenAccountsExist_ReturnsAccount()
    {
        // Arrange
        var accountList = _fixture.Build<Account>().Without(x => x.AccountCompositions).CreateMany(5);
        _database.Get<Account>().Returns(accountList.AsQueryable());

        var service = RetrieveService();

        // Act
        var result = service.GetAccounts();

        // Assert
        result.Should().BeEquivalentTo(accountList, options => options.ExcludingMissingMembers());
    }

    [Theory, AutoData]
    public void CreateAccount_MappedAndSaved(string username, string email, string password)
    {
        // Arrange
        const int id = 1;

        var account = new AccountDto
        {
            Id = id,
            Username = username,
            Email = email,
            Password = password
        };
        
        var service = RetrieveService();

        // Act
        service.CreateAccount(account);

        // Assert
        _database.Received(1).SaveChanges();
        _database.Received(1).Add(Arg.Is<Account>(x => x.Username == account.Username));
    }
}
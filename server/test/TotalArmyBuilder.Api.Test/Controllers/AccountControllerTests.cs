using System.Net;
using AutoFixture.Xunit2;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using TotalArmyBuilder.Api.Controllers;
using TotalArmyBuilder.Api.Test.Extensions;
using TotalArmyBuilder.Api.ViewModels.Accounts;
using TotalArmyBuilder.Api.ViewModels.Compositions;
using TotalArmyBuilder.Service.DTOs;
using TotalArmyBuilder.Service.Interfaces;

namespace TotalArmyBuilder.Api.Test.Controllers;

public class AccountControllerTests
{
    private readonly IMapper _mapper;
    private readonly IAccountService _service;

    public AccountControllerTests()
    {
        _mapper = Substitute.For<IMapper>();
        _service = Substitute.For<IAccountService>();
    }

    private AccountsController RetrieveController()
    {
        return new AccountsController(_mapper, _service);
    }

    [Theory]
    [AutoData]
    public void GetAccounts_MappedAndReturned(string username, string email)
    {
        // Arrange
        const int id = 1;
        var account = new AccountDto
        {
            Id = id,
            Username = username,
            Email = email
        };

        const int id2 = 2;
        var account2 = new AccountDto
        {
            Id = id2,
            Username = username,
            Email = email
        };

        var accountList = new List<AccountDto>
        {
            account, account2
        };

        var accountViewModels = new List<AccountViewModel>
        {
            new()
        };

        _service.GetAccounts(username, email).Returns(accountList);
        _mapper.Map<IList<AccountViewModel>>(accountList).Returns(accountViewModels);

        var controller = RetrieveController();

        // Act
        var actionResult = controller.GetAccounts(username, email);

        // Assert
        var result = actionResult.AssertObjectResult<IList<AccountViewModel>, OkObjectResult>();

        result.Should().BeSameAs(accountViewModels);

        _service.Received(1).GetAccounts(username, email);
        _mapper.Received(1).Map<IList<AccountViewModel>>(accountList);
    }

    [Fact]
    public void GetAccountById_WhenAccountFound_MappedAndReturned()
    {
        // Arrange
        const int id = 1;
        var account = new AccountDto
        {
            Id = id
        };

        var accountDetailViewModel = new AccountDetailViewModel();

        _service.GetAccountById(id).Returns(account);
        _mapper.Map<AccountDetailViewModel>(account).Returns(accountDetailViewModel);

        var controller = RetrieveController();

        // Act
        var actionResult = controller.GetAccountById(id);

        // Assert
        var result = actionResult.AssertObjectResult<AccountDetailViewModel, OkObjectResult>();

        result.Should().BeSameAs(accountDetailViewModel);

        _service.Received(1).GetAccountById(id);
        _mapper.Received(1).Map<AccountDetailViewModel>(account);
    }

    [Fact]
    public void GetAccountCompositions_WhenCompositionsFound_MappedAndReturned()
    {
        // Arrange
        const int id = 1;

        var composition = new CompositionDto
        {
            Id = id
        };

        const int id2 = 2;
        var composition2 = new CompositionDto
        {
            Id = id2
        };

        var compositionList = new List<CompositionDto>
        {
            composition, composition2
        };

        var account = new AccountDto
        {
            Id = id,
            Compositions = compositionList
        };


        var compositionViewModels = new List<CompositionViewModel>
        {
            new()
        };

        _service.GetAccountCompositions(account.Id).Returns(account.Compositions);
        _mapper.Map<IList<CompositionViewModel>>(account.Compositions).Returns(compositionViewModels);

        var controller = RetrieveController();

        // Act
        var actionResult = controller.GetAccountCompositions(account.Id);

        // Assert
        var result = actionResult.AssertObjectResult<IList<CompositionViewModel>, OkObjectResult>();

        result.Should().BeSameAs(compositionViewModels);

        _service.Received(1).GetAccountCompositions(account.Id);
        _mapper.Received(1).Map<IList<CompositionViewModel>>(account.Compositions);
    }

    [Theory]
    [AutoData]
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

        var createAccountViewModel = new CreateAccountViewModel();

        _mapper.Map<AccountDto>(createAccountViewModel).Returns(account);

        var controller = RetrieveController();

        // Act
        var actionResult = controller.CreateAccount(createAccountViewModel);

        // Assert
        actionResult.AssertResult<StatusCodeResult>(HttpStatusCode.Created);

        _service.Received(1).CreateAccount(account);
        _mapper.Received(1).Map<AccountDto>(createAccountViewModel);
    }

    [Theory]
    [AutoData]
    public void UpdateAccount_WhenCalledWithValidViewModel_MappedAndSaved(string username, string email)
    {
        // Arrange
        const int id = 2;
        var account = new AccountDto
        {
            Username = username,
            Email = email
        };

        var updateAccountViewModel = new UpdateAccountViewModel
        {
            Username = "test",
            Email = "test"
        };

        _mapper.Map<AccountDto>(updateAccountViewModel).Returns(account);

        var controller = RetrieveController();

        // Act
        var actionResult = controller.UpdateAccount(id, updateAccountViewModel);

        // Assert
        actionResult.AssertResult<NoContentResult>();

        _service.Received(1).UpdateAccount(id, account);
        _mapper.Received(1).Map<AccountDto>(updateAccountViewModel);
    }

    [Fact]
    public void DeleteAccount_WhenCalledWithValidId_DeletedAndSaved()
    {
        // Arrange
        const int id = 1;

        var controller = RetrieveController();

        // Act
        var actionResult = controller.DeleteAccount(id);

        // Assert
        actionResult.AssertResult<NoContentResult>();

        _service.Received(1).DeleteAccount(id);
    }
}
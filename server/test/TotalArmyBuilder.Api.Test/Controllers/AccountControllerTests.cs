using System.Collections;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using TotalArmyBuilder.Api.Controllers;
using TotalArmyBuilder.Api.Test.Extensions;
using TotalArmyBuilder.Api.ViewModels.Accounts;
using TotalArmyBuilder.Dal.Interfaces;
using TotalArmyBuilder.Dal.Specifications.Accounts;
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
    
    [Theory]
    [InlineData("username", "email")]
    [InlineData(null, null)]
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

        var accountViewModels = new List<AccountViewModel>();

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
    
    private AccountsController RetrieveController()
    {
        return new AccountsController(_mapper, _service);
    }
}
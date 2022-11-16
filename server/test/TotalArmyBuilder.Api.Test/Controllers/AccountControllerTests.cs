using System.Collections;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using TotalArmyBuilder.Api.Controllers;
using TotalArmyBuilder.Api.Test.Extensions;
using TotalArmyBuilder.Api.ViewModels.Accounts;
using TotalArmyBuilder.Dal.Interfaces;
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
    public void GetAccounts_WhenAccountFound_MappedAndReturned()
    {
        // Arrange
        const int id = 1;
        const string username = "username";
        const string email = "example@email.com";
        var account = new AccountDto
        {
            Id = id,
            Username = username,
            Email = email
        };
        
        const int id2 = 2;
        const string username2 = "username2";
        const string email2 = "example2@email.com";
        var account2 = new AccountDto
        {
            Id = id2,
            Username = username2,
            Email = email2
        };

        IList<AccountDto> accountList = new List<AccountDto>();
        accountList.Add(account);
        accountList.Add(account2);

        var accountViewModel = new AccountViewModel();

        _service.GetAccounts().Returns(accountList);

        var controller = RetrieveController();
        _mapper.Map<AccountViewModel>(accountList[0]).Returns(accountViewModel);
        _mapper.Map<AccountViewModel>(accountList[1]).Returns(accountViewModel);
        
        // Act
        var actionResult = controller.GetAccounts(null,null);
        
        // Assert
        var result = actionResult.AssertObjectResult<IList<AccountViewModel>, OkObjectResult>();
        
       // result.Should().BeSameAs(accountViewModel);

        _service.Received(1).GetAccountById(id);
        _mapper.Received(1).Map<AccountViewModel>(account);
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


    private AccountsController RetrieveController()
    {
        return new AccountsController(_mapper, _service);
    }
}
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
    public void GetAccountById_WhenAccountFound_MapsAndReturned()
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

        result.Should().BeSameAs(AccountDetailViewModel);

        _service.Received(1).GetAccountById(id);
        _mapper.Received(1).Map<AccountDetailViewModel>(account);
    }


    private AccountsController RetrieveController()
    {
        return new AccountsController(_mapper, _service);
    }
}
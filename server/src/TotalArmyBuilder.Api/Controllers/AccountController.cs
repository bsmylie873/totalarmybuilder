using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using TotalArmyBuilder.Api.Controllers.Base;
using TotalArmyBuilder.Api.ViewModels.Accounts;
using TotalArmyBuilder.Api.ViewModels.Compositions;
using TotalArmyBuilder.Service.DTOs;
using TotalArmyBuilder.Service.Interfaces;

namespace TotalArmyBuilder.Api.Controllers;

[Route("api/[controller]")]
public class AccountsController : TotalArmyBaseController
{
    private readonly IMapper _mapper;
    private readonly IAccountService _service;

    public AccountsController(IMapper mapper, IAccountService service)
    {
        (_mapper, _service) = (mapper, service);
    }

    [HttpGet]
    public ActionResult<IList<AccountViewModel>> GetAccounts([FromQuery] string? username, [FromQuery] string? email)
    {
        var accounts = _service.GetAccounts(username, email);
        return OkOrNoContent(_mapper.Map<IList<AccountViewModel>>(accounts));
    }

    [HttpGet("{id}", Name = "GetAccountById")]
    [AllowAnonymous]
    public ActionResult<AccountDetailViewModel> GetAccountById(int id)
    {
        var account = _service.GetAccountById(id);
        return OkOrNoNotFound(_mapper.Map<AccountDetailViewModel>(account));
    }

    [HttpGet("{id}/compositions/", Name = "GetAccountCompositions")]
    public ActionResult<IList<CompositionViewModel>> GetAccountCompositions(int id)
    {
        var accountCompositions = _service.GetAccountCompositions(id);
        return OkOrNoContent(_mapper.Map<IList<CompositionViewModel>>(accountCompositions));
    }

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public ActionResult CreateAccount([FromBody] CreateAccountViewModel accountDetails)
    {
        var account = _mapper.Map<AccountDto>(accountDetails);
        account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
        _service.CreateAccount(account);
        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpPatch]
    [AllowAnonymous]
    [Route("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public ActionResult UpdateAccount(int id, [FromBody] UpdateAccountViewModel accountDetails)
    {
        var account = _mapper.Map<AccountDto>(accountDetails);
        _service.UpdateAccount(id, account);
        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public ActionResult DeleteAccount(int id)
    {
        _service.DeleteAccount(id);
        return NoContent();
    }
}
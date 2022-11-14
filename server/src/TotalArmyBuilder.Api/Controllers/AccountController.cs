using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TotalArmyBuilder.Api.ViewModels.Accounts;
using TotalArmyBuilder.Api.ViewModels.Compositions;
using TotalArmyBuilder.Dal.Interfaces;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Dal.Specifications.Accounts;
using TotalArmyBuilder.Dal.Specifications.Compositions;
using TotalArmyBuilder.Service.DTOs;
using TotalArmyBuilder.Service.Interfaces;
using Unosquare.EntityFramework.Specification.Common.Extensions;

namespace TotalArmyBuilder.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountsController : Controller
{
    private readonly ITotalArmyDatabase _database;
    private readonly IAccountService _service;
    private readonly IMapper _mapper;
    public AccountsController(ITotalArmyDatabase database, IMapper mapper, IAccountService service) => 
        (_database, _mapper, _service) = (database, mapper, service);
    
    [HttpGet]
    public ActionResult<IList<AccountViewModel>> GetAccounts([FromQuery] string username, [FromQuery] string email)
    {
        var accounts = _service.GetAccounts(username, email);
        return Ok(_mapper.Map<IList<AccountViewModel>>(accounts));
    }
    
    [HttpGet("{id}", Name = "GetAccountById")]
    public ActionResult<AccountDetailViewModel> GetAccountById(int id)
    {
        var account = _service.GetAccountById(id);

        return Ok(new {account});
    }

    [HttpGet("{id}/compositions/", Name = "GetAccountCompositions")]
    public ActionResult<CompositionViewModel> GetAccountCompositions(int id)
    {
        var accountCompositions = _service.GetCompositionsByAccount(id);
        return Ok(new {accountCompositions});
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public ActionResult CreateAccount([FromForm] CreateAccountViewModel accountDetails)
    {
        var account = _mapper.Map<Account>(accountDetails);
        _service.CreateAccount(account);
        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public ActionResult UpdateAccount(int id, [FromForm] UpdateAccountViewModel accountDetails)
    {
        var account = _mapper.Map<AccountDto>(accountDetails);
        _service.UpdateAccount(id, account);
        return StatusCode((int)HttpStatusCode.NoContent);
    }
    
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public ActionResult UpdateAccount(int id)
    {
        _service.DeleteAccount(id);
        return StatusCode((int)HttpStatusCode.NoContent);
    }
}

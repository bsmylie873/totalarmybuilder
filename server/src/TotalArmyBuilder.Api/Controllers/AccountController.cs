using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TotalArmyBuilder.Api.Controllers.Base;
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

[Route("[controller]")]
public class AccountsController : TotalArmyBaseController
{
    private readonly IAccountService _service;
    private IMapper _mapper;
    
    public AccountsController(IMapper mapper, IAccountService service) => 
        (_mapper, _service) = (mapper, service);
    
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
        var model = _mapper.Map<AccountDetailViewModel>(account);
        return Ok(model);
    }

    /*[HttpGet("{id}/compositions/", Name = "GetAccountCompositions")]
    public ActionResult<CompositionViewModel> GetAccountCompositions(int id)
    {
        var accountCompositions = _service.GetCompositionsByAccount(id);
        return Ok(new {accountCompositions});
    
    }*/

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public ActionResult CreateAccount([FromBody] CreateAccountViewModel accountDetails)
    {
        var account = _mapper.Map<AccountDto>(accountDetails);
        _service.CreateAccount(account);
        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpPatch]
    [Route("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public ActionResult UpdateAccount(int id, [FromBody] UpdateAccountViewModel accountDetails)
    {
        var account = _mapper.Map<AccountDto>(accountDetails);
        _service.UpdateAccount(id, _mapper.Map<AccountDto>(account));
        return StatusCode((int)HttpStatusCode.NoContent);
    }
    
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public ActionResult DeleteAccount(int id)
    {
        _service.DeleteAccount(id);
        return StatusCode((int)HttpStatusCode.NoContent);
    }
}

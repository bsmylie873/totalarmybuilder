using System.Net;
using Microsoft.AspNetCore.Mvc;
using TotalArmyBuilder.Api.ViewModels.Accounts;
using TotalArmyBuilder.Api.ViewModels.Compositions;
using TotalArmyBuilder.Dal.Interfaces;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Dal.Specifications.Accounts;
using TotalArmyBuilder.Dal.Specifications.Compositions;
using TotalArmyBuilder.Service.Interfaces;
using Unosquare.EntityFramework.Specification.Common.Extensions;

namespace TotalArmyBuilder.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountsController : Controller
{
    private readonly IAccountService _service;
    public AccountsController(IAccountService service) => _service = service;
    
    [HttpGet]
    public ActionResult<AccountDetailViewModel> GetAccounts()
    {
        var accounts = _service.GetAccounts();
        return Ok(new {accounts});
    }
    
    [HttpGet("{id}", Name = "GetAccountById")]
    public ActionResult<AccountDetailViewModel> GetAccountById(int id)
    {
        var account = _service.GetAccounts();
        if (account == null)
        {
            return NotFound();
        }
        
        return Ok(new {account});
    }
    
    [HttpGet("{username}", Name = "GetAccountByUsername")]
    public ActionResult<AccountDetailViewModel> GetAccountByUsername(string username)
    {
        var account = _database
            .Get<Account>()
            .Where(new AccountByUsernameSpec(username))
            .FirstOrDefault();
        if (account == null)
        {
            return NotFound();
        }
        return Ok(new { account.Id, account.Username, account.Email});
    }
    
    [HttpGet("{email}", Name = "GetAccountByEmail")]
    public ActionResult<AccountDetailViewModel> GetAccountByEmail(string email)
    {
        var account = _database
            .Get<Account>()
            .Where(new AccountByEmailSpec(email))
            .FirstOrDefault();
        if (account == null)
        {
            return NotFound();
        }
        return Ok(new { account.Id, account.Username, account.Email});
    }
    
    
    [HttpGet("{id}/compositions/", Name = "GetAccountCompositions")]
    public ActionResult<CompositionViewModel> GetAccountCompositions(int id)
    {
        var compositions = _database
            .Get<AccountComposition>()
            .Where(new CompositionByAccountSpec(id))
            .ToList();
        return Ok(new {compositions});
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public ActionResult CreateAccount([FromForm]CreateAccountViewModel accountDetails)
    {
        _database.Add(new Account{Email = accountDetails.Email, Username = accountDetails.Username, 
            Password = accountDetails.Password});
        _database.SaveChanges();
        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public ActionResult UpdateAccount(int id, [FromForm] UpdateAccountViewModel accountDetails)
    {   
        var account = _database
            .Get<Account>()
            .Where(new AccountByIdSpec(id))
            .FirstOrDefault();
        account.Username = accountDetails.Username;
        _database.SaveChanges();
        return NoContent();
    }
    
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public ActionResult UpdateAccount(int id)
    {
        var account = _database
            .Get<Account>()
            .Where(new AccountByIdSpec(id))
            .FirstOrDefault();
        _database.Delete(account);
        _database.SaveChanges();
        return NoContent();
    }
}

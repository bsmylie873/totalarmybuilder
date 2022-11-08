using System.Net;
using Microsoft.AspNetCore.Mvc;
using TotalArmyBuilder.Api.ViewModels.Accounts;
using TotalArmyBuilder.Api.ViewModels.Compositions;
using TotalArmyBuilder.Dal.Interfaces;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Dal.Specifications.Accounts;
using Unosquare.EntityFramework.Specification.Common.Extensions;

namespace TotalArmyBuilder.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountsController : Controller
{
    private readonly ITotalArmyDatabase _database;
    public AccountsController(ITotalArmyDatabase database) => _database = database;
    
    [HttpGet]
    public ActionResult<AccountDetailViewModel> GetAccounts()
    {
        var accounts = _database.Get<Account>().ToList();
        return Ok(new {accounts});
    }
    
    [HttpGet("{id}", Name = "GetAccount")]
    public ActionResult<AccountDetailViewModel> GetAccount(int id)
    {
        var account = _database
            .Get<Account>()
            .FirstOrDefault(new AccountByIdSpec(id).Or(new AccountByEmailSpec("hello@email.com")));
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
            .Where(x => x.AccountId == id)
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
        var account = _database.Get<Account>().FirstOrDefault(x => x.Id == id);
        account.Username = accountDetails.Username;
        _database.SaveChanges();
        return NoContent();
    }
    
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public ActionResult UpdateAccount(int id)
    {
        var account = _database.Get<Account>().FirstOrDefault(x => x.Id == id);
        _database.Delete(account);
        _database.SaveChanges();
        return NoContent();
    }
}

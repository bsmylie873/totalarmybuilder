using System.Net;
using Microsoft.AspNetCore.Mvc;
using TotalArmyBuilder.Api.ViewModels.Accounts;
using TotalArmyBuilder.Api.ViewModels.Compositions;
using TotalArmyBuilder.Dal.Interfaces;
using TotalArmyBuilder.Dal.Models;
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
        var account = _database.Get<Account>().FirstOrDefault(x => x.Id == id);
        if (account == null)
        {
            return NotFound();
        }
        return Ok(new { Id = account.Id, Username = account.Username});
    }
    
    [HttpGet("{id}/compositions/", Name = "GetAccountCompositions")]
    public ActionResult<CompositionViewModel> GetAccountCompositions(int id)
    {
        var compositions = _database.Get<Account_Composition>().All
            (x => x.AccountId == id);
        
        return Ok(new {compositions});
    }
    
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public ActionResult CreateAccount(CreateAccountViewModel AccountDetails)
    {
        _database.Add(new Account{Email = AccountDetails.Email, Username = AccountDetails.Username});
        _database.SaveChanges();
        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public ActionResult UpdateAccount(int id, [FromBody] UpdateAccountViewModel accountDetails)
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

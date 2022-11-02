using System.Net;
using Microsoft.AspNetCore.Mvc;
using TotalArmyBuilder.Api.ViewModels.Accounts;
using TotalArmyBuilder.Api.ViewModels.Compositions;

namespace TotalArmyBuilder.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountsController : Controller
{
    
    [HttpGet("{id}", Name = "GetAccount")]
    public ActionResult<AccountViewModel> GetAccount(int id)
    {
        return Ok(new { Id = 108, Email = "user123@email.com", Username = "user123"});
    }
    
    [HttpGet("{id}/Compositions/", Name = "GetAccountCompositions")]
    public ActionResult<CompositionViewModel> GetAccountCompositions(int id)
    {
        return Ok(new { Id = 1, Name  = "Khorne Rush", Battle_Type = 0, Faction_Id = 12, Avatar_Id = 76 });
    }
    
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public ActionResult CreateAccount(object accountDetails)
    {
        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public ActionResult UpdateAccount(int id, [FromBody] object accountDetails)
    {
        return NoContent();
    }
    
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public ActionResult UpdateAccount(int id)
    {
        return NoContent();
    }
}

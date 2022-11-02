using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace TotalArmyBuilder.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountsController : Controller
{

    [HttpGet("{id}", Name = "GetAccount")]
    public ActionResult GetAccount(int id)
    {
        return Ok(new { Amount = 108, Message = "Hello" });
    }
    
    [HttpGet("{id}/Compositions/", Name = "GetAccountCompositions")]
    public ActionResult GetAccountCompositions(int id)
    {
        return Ok(new { Amount = 108, Message = "Hello" });
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

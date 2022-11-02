using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace TotalArmyBuilder.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CompositionsController : Controller
{
    [HttpGet]
    public ActionResult GetCompositions()
    {
        var compositions = new List<object>
        {
            new { id = 1, name = "Khorne Rush", battle_type = "Land Battle"},
            new { id = 2, name = "Wood Elf Rush", battle_type = "Domination"},
        };
        
        return Ok(compositions);
    }
    
    [HttpGet("{id}", Name = "GetComposition")]
    public ActionResult GetComposition(int id)
    {
        return Ok(new { id = 1, name = "Khorne Rush", battle_type = "Land Battle"});
    }
    
    /*[HttpGet("{id}", Name = "GetCompositionUnits")]
    public ActionResult GetCompositionUnits(int id)
    {
        var compositionUnits = new List<object>
        {
            new { id = 11, name = "Tzar Guard", cost = 1100, avatar = "avatar_details" },
            new { id = 11, name = "Tzar Guard", cost = 1100, avatar = "avatar_details" }
        };
        return Ok(compositionUnits);
    }*/
    
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public ActionResult CreateAccountComposition(object compositionDetails)
    {
        return StatusCode((int)HttpStatusCode.Created);
    }
    
    [HttpPatch]
    [Route("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public ActionResult UpdateComposition(int id, [FromBody] object compositionDetails)
    {
        return NoContent();
    }
    
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public ActionResult UpdateComposition(int id)
    {
        return NoContent();
    }
}


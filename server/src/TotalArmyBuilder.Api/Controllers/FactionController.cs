using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace TotalArmyBuilder.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FactionsController : Controller
{
    [HttpGet]
    public ActionResult GetFactions()
    {
        var factions = new List<object>
        {
            new { id = 1, name = "Beastmen"},
            new { id = 2, name = "Bretonnia"},
        };
        
        return Ok(factions);
    }
    
    [HttpGet("{id}", Name = "GetFaction")]
    public ActionResult GetFaction(int id)
    {
        return Ok(new { id = 13, name = "Norsca"});
    }
    
    [HttpGet("{id}/Units/", Name = "GetFactionUnits")]
    public ActionResult GetFactionUnits(int id)
    {
        var factionUnits = new List<object>
        {
            new { id = 28, name = "Lord Magistrate", cost = 1300, avatar = "avatar_details" },
            new { id = 29, name = "Dragon-blooded Shugengan Lord (Yin)", cost = 2062, avatar = "avatar_details" }
        };
        return Ok(factionUnits);
    }
}
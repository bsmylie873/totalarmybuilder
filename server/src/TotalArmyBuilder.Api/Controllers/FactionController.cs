using System.Net;
using Microsoft.AspNetCore.Mvc;
using TotalArmyBuilder.Api.ViewModels.Factions;
using TotalArmyBuilder.Api.ViewModels.Units;
using TotalArmyBuilder.Dal.Interfaces;
using TotalArmyBuilder.Dal.Models;
namespace TotalArmyBuilder.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FactionsController : Controller
{
    private readonly ITotalArmyDatabase _database;
    public FactionsController(ITotalArmyDatabase database) => _database = database;
        
    [HttpGet]
    public ActionResult<FactionDetailViewModel> GetAccounts(int id)
    {
        var factions = _database.Get<Faction>().ToList();
        return Ok(new {factions});
    }
    
    [HttpGet("{id}", Name = "GetFaction")]
    public ActionResult<FactionDetailViewModel> GetFaction(int id)
    {

        var faction = _database.Get<Faction>().FirstOrDefault(x => x.Id == id);
        if (faction == null)
        {
            return NotFound();
        }
        return Ok(new { faction.Id, faction.Name});
    }
    
    [HttpGet("{id}/Units/", Name = "GetFactionUnits")]
    public ActionResult<UnitViewModel> GetFactionUnits(int id)
    {
        var factionUnits = _database
            .Get<Unit>()
            .Where(x => x.Id == id)
            .ToList();
        return Ok(factionUnits);
    }
}
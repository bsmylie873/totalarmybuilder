using System.Net;
using Microsoft.AspNetCore.Mvc;
using TotalArmyBuilder.Api.ViewModels.Factions;
using TotalArmyBuilder.Api.ViewModels.Units;

namespace TotalArmyBuilder.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FactionsController : Controller
{
    [HttpGet]
    public ActionResult GetFactions()
    {
        List<FactionViewModel> Factions = new List<FactionViewModel>
        {
            new FactionViewModel{ Id = 1, Name = "Beastmen"},
            new FactionViewModel{ Id = 2, Name = "Bretonnia"}
        };
        
        return Ok(Factions);
    }
    
    [HttpGet("{id}", Name = "GetFaction")]
    public ActionResult<FactionDetailViewModel> GetFaction(int id)
    {
        return Ok(new { id = 13, name = "Norsca"});
    }
    
    [HttpGet("{id}/Units/", Name = "GetFactionUnits")]
    public ActionResult<UnitViewModel> GetFactionUnits(int id)
    {
        List<UnitViewModel> factionUnits = new List<UnitViewModel>
        {
            new UnitViewModel{ Id = 28, Name = "Lord Magistrate", Cost = 1300, AvatarId = 28 },
            new UnitViewModel{ Id = 29, Name = "Dragon-blooded Shugengan Lord (Yin)", Cost = 2062, AvatarId = 28 }
        };
        return Ok(factionUnits);
        
    }
}
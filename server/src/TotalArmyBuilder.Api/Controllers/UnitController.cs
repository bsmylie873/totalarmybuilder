using System.Net;
using Microsoft.AspNetCore.Mvc;
using TotalArmyBuilder.Api.ViewModels.Factions;
using TotalArmyBuilder.Api.ViewModels.Units;
using TotalArmyBuilder.Dal.Interfaces;
using TotalArmyBuilder.Dal.Models;
namespace TotalArmyBuilder.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UnitsController : Controller
{
    private readonly ITotalArmyDatabase _database;
    public UnitsController(ITotalArmyDatabase database) => _database = database;
    
    [HttpGet("{id}", Name = "GetUnit")]
    public ActionResult<UnitDetailViewModel> GetUnit(int id)
    {
        var unit = _database.Get<Unit>().FirstOrDefault(x => x.Id == id);
        if (unit == null)
        {
            return NotFound();
        }
        return Ok(new { Id = unit.Id, Name = unit.Name, Cost = unit.Cost, AvatarId = unit.AvatarId});
    }
    
}
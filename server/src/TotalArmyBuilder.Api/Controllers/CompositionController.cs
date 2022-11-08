using System.Net;
using Microsoft.AspNetCore.Mvc;
using TotalArmyBuilder.Api.ViewModels.Compositions;
using TotalArmyBuilder.Api.ViewModels.Units;
using TotalArmyBuilder.Dal.Interfaces;
using TotalArmyBuilder.Dal.Models;

namespace TotalArmyBuilder.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CompositionsController : Controller
{
    private readonly ITotalArmyDatabase _database;
    public CompositionsController(ITotalArmyDatabase database) => _database = database;
    
    [HttpGet]
    public ActionResult<CompositionViewModel> GetCompositions()
    {
        var compositions = _database.Get<Composition>().ToList();
        return Ok(new {compositions});
    }

    [HttpGet("{id}", Name = "GetComposition")]
    public ActionResult<CompositionDetailViewModel> GetComposition(int id)
    {
        var composition = _database.Get<Composition>().FirstOrDefault(x => x.Id == id);
        if (composition == null)
        {
            return NotFound();
        }
        return Ok(new
        {composition.Id, composition.Name, composition.BattleType, composition.FactionId,composition.AvatarId });
    }
    
    [HttpGet("{id}/units/", Name = "GetCompositionUnits")]
    public ActionResult<CompositionDetailViewModel> GetCompositionUnits(int id)
    {
        var compositionUnits = _database
            .Get<Unit>()
            .Where(x => x.Id == id)
            .ToList();
        return Ok(new {compositionUnits});
    }
    
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public ActionResult CreateAccountComposition([FromForm] CreateCompositionViewModel compositionDetails)
    {
        _database.Add(new Composition{Name = compositionDetails.Name, BattleType = compositionDetails.Battle_Type, 
            FactionId = compositionDetails.Faction_Id, AvatarId = compositionDetails.Avatar_Id});
        _database.SaveChanges();
        return StatusCode((int)HttpStatusCode.Created);
    }
    
    [HttpPatch]
    [Route("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public ActionResult UpdateComposition(int id, [FromForm] UpdateCompositionViewModel compositionDetails)
    {
        var composition = _database.Get<Composition>().FirstOrDefault(x => x.Id == id);
        composition.Name = compositionDetails.Name;
        composition.BattleType = compositionDetails.Battle_Type;
        composition.FactionId = compositionDetails.Faction_Id;
        composition.AvatarId = compositionDetails.Avatar_Id;
        _database.SaveChanges();
        return NoContent();
    }
    
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public ActionResult UpdateComposition(int id)
    {
        var composition = _database.Get<Composition>().FirstOrDefault(x => x.Id == id);
        _database.Delete(composition);
        _database.SaveChanges();
        return NoContent();
    }
}


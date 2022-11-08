using System.Net;
using Microsoft.AspNetCore.Mvc;
using TotalArmyBuilder.Api.ViewModels.Compositions;
using TotalArmyBuilder.Api.ViewModels.Units;
using TotalArmyBuilder.Dal.Interfaces;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Dal.Specifications.Compositions;
using TotalArmyBuilder.Dal.Specifications.Units;
using Unosquare.EntityFramework.Specification.Common.Extensions;

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

    [HttpGet("{id}", Name = "GetCompositionById")]
    public ActionResult<CompositionDetailViewModel> GetCompositionById(int id)
    {
        var composition = _database
            .Get<Composition>()
            .Where(new CompositionByIdSpec(id))
            .FirstOrDefault();
        if (composition == null)
        {
            return NotFound();
        }
        return Ok(new
        {composition.Id, composition.Name, composition.BattleType, composition.FactionId,composition.AvatarId });
    }
    
    [HttpGet("{name}", Name = "GetCompositionByName")]
    public ActionResult<CompositionDetailViewModel> GetCompositionByName(string name)
    {
        var composition = _database
            .Get<Composition>()
            .Where(new CompositionByNameSpec(name))
            .ToList();
        if (composition == null)
        {
            return NotFound();
        }
        return Ok(composition);
    }
    
    [HttpGet("{faction}", Name = "GetCompositionByFaction")]
    public ActionResult<CompositionDetailViewModel> GetCompositionByFaction(int faction)
    {
        var composition = _database
            .Get<Composition>()
            .Where(new CompositionByFactionSpec(faction))
            .ToList();
        if (composition == null)
        {
            return NotFound();
        }
        return Ok(composition);
    }
    
    [HttpGet("{battleType}", Name = "GetCompositionByBattleType")]
    public ActionResult<CompositionDetailViewModel> GetCompositionByBattleType(int battleType)
    {
        var composition = _database
            .Get<Composition>()
            .Where(new CompositionByBattleTypeSpec(battleType))
            .ToList();
        if (composition == null)
        {
            return NotFound();
        }
        return Ok(composition);
    }
    
    [HttpGet("{id}/units/", Name = "GetCompositionUnits")]
    public ActionResult<CompositionDetailViewModel> GetCompositionUnits(int id)
    {
        var compositionUnits = _database
            .Get<Unit>()
            .Where(new UnitByIdSpec(id))
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
        var composition = _database
            .Get<Composition>()
            .Where(new CompositionByIdSpec(id))
            .FirstOrDefault();
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
        var composition = _database
            .Get<Composition>()
            .Where(new CompositionByIdSpec(id))
            .FirstOrDefault();
        _database.Delete(composition);
        _database.SaveChanges();
        return NoContent();
    }
}


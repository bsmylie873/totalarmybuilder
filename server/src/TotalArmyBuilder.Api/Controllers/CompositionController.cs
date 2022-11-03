using System.Net;
using Microsoft.AspNetCore.Mvc;
using TotalArmyBuilder.Api.ViewModels.Compositions;
using TotalArmyBuilder.Api.ViewModels.Units;

namespace TotalArmyBuilder.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CompositionsController : Controller
{
    [HttpGet]
    public ActionResult<CompositionViewModel> GetCompositions()
    {
        List<CompositionViewModel> Compositions = new List<CompositionViewModel>
        {
            new CompositionViewModel{Name = "Khorne Rush", Battle_Type = 0, Faction_Id = 12, Avatar_Id = 76},
            new CompositionViewModel{Name = "Wood Elf Rush", Battle_Type = 1, Faction_Id = 23, Avatar_Id = 678}
        };
        return Ok(Compositions);
    }
    
    [HttpGet("{id}", Name = "GetComposition")]
    public ActionResult<CompositionDetailViewModel> GetComposition(int id)
    {
        List<UnitDetailViewModel> Unit_List = new List<UnitDetailViewModel>
        {
            new UnitDetailViewModel { Id = 11, Name = "Tzar Guard", Cost = 1100, AvatarId = 11 },
            new UnitDetailViewModel { Id = 11, Name = "Tzar Guard", Cost = 1100, AvatarId = 11 }
        };
        CompositionDetailViewModel Composition = new CompositionDetailViewModel
        {
            Id = 44, Name = "Tzar Guard Rush", Battle_Type = 0,
            Faction_Id = 12, Avatar_Id = 76, Unit_List = Unit_List
        };
        return Ok(Composition);
    }
    
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public ActionResult CreateAccountComposition(CreateCompositionViewModel compositionDetails)
    {
        return StatusCode((int)HttpStatusCode.Created);
    }
    
    [HttpPatch]
    [Route("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public ActionResult UpdateComposition(int id, [FromBody] UpdateCompositionViewModel compositionDetails)
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


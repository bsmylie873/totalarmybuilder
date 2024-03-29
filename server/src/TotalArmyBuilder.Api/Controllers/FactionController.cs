using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TotalArmyBuilder.Api.Controllers.Base;
using TotalArmyBuilder.Api.ViewModels.Factions;
using TotalArmyBuilder.Api.ViewModels.Units;
using TotalArmyBuilder.Service.Interfaces;

namespace TotalArmyBuilder.Api.Controllers;

[Route("api/[controller]")]
public class FactionsController : TotalArmyBaseController
{
    private readonly IMapper _mapper;
    private readonly IFactionService _service;

    public FactionsController(IMapper mapper, IFactionService service)
    {
        (_mapper, _service) = (mapper, service);
    }

    [HttpGet]
    public ActionResult<IList<FactionViewModel>> GetFactions([FromQuery] string? name)
    {
        var factions = _service.GetFactions(name);
        return OkOrNoContent(_mapper.Map<IList<FactionViewModel>>(factions));
    }

    [HttpGet("{id}", Name = "GetFactionById")]
    public ActionResult<FactionDetailViewModel> GetFactionById(int id)
    {
        var faction = _service.GetFactionById(id);
        return OkOrNoNotFound(_mapper.Map<FactionDetailViewModel>(faction));
    }

    [HttpGet("{id}/units/", Name = "GetFactionUnits")]
    public ActionResult<IList<UnitViewModel>> GetFactionUnits(int id)
    {
        var factionUnits = _service.GetFactionUnits(id);
        return OkOrNoContent(_mapper.Map<IList<UnitViewModel>>(factionUnits));
    }
}
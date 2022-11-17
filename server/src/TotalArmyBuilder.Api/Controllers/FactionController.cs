using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TotalArmyBuilder.Api.Controllers.Base;
using TotalArmyBuilder.Api.ViewModels.Accounts;
using TotalArmyBuilder.Api.ViewModels.Factions;
using TotalArmyBuilder.Api.ViewModels.Units;
using TotalArmyBuilder.Dal.Interfaces;
using TotalArmyBuilder.Dal.Specifications.Factions;
using TotalArmyBuilder.Dal.Specifications.Units;
using TotalArmyBuilder.Service.DTOs;
using TotalArmyBuilder.Service.Interfaces;
using Unosquare.EntityFramework.Specification.Common.Extensions;

namespace TotalArmyBuilder.Api.Controllers;

[Route("[controller]")]
public class FactionsController : TotalArmyBaseController
{
    private readonly IFactionService _service;
    private readonly IMapper _mapper;
    public FactionsController(IMapper mapper, IFactionService service) => 
        (_mapper, _service) = (mapper, service);
        
    [HttpGet]
    public ActionResult<IList<FactionViewModel>> GetFactions([FromQuery] string name)
    {
        var factions = _service.GetFactions(name);
        return Ok(_mapper.Map<IList<FactionViewModel>>(factions));
    }
    
    [HttpGet("{id}", Name = "GetFactionById")]
    public ActionResult<FactionDetailViewModel> GetFactionById(int id)
    {
        var faction = _service.GetFactionById(id);

        return OkOrNoContent(_mapper.Map<FactionDetailViewModel>(faction));
    }
    
    [HttpGet("{id}/units/", Name = "GetFactionUnits")]
    public ActionResult<IList<UnitViewModel>> GetFactionUnits(int id)
    {
        var factionUnits = _service.GetFactionUnits(id);
        return Ok(_mapper.Map<IList<UnitViewModel>>(factionUnits));
    }
}
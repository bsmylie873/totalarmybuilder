using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TotalArmyBuilder.Api.Controllers.Base;
using TotalArmyBuilder.Api.ViewModels.Factions;
using TotalArmyBuilder.Api.ViewModels.Units;
using TotalArmyBuilder.Dal.Interfaces;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Service.Interfaces;

namespace TotalArmyBuilder.Api.Controllers;

[Route("[controller]")]
public class UnitsController : TotalArmyBaseController
{
    private readonly IUnitService _service;
    private readonly IMapper _mapper;
    public UnitsController(IMapper mapper, IUnitService service) => 
        (_mapper, _service) = (mapper, service);
        
    [HttpGet]
    public ActionResult<IList<UnitViewModel>> GetUnits([FromQuery] string? name, [FromQuery] int? cost)
    {
        var units = _service.GetUnits(name, cost);
        return OkOrNoContent(_mapper.Map<IList<UnitViewModel>>(units));
    }
    
    [HttpGet("{id}", Name = "GetUnitById")]
    public ActionResult<UnitDetailViewModel> GetUnitById(int id)
    {
        var unit = _service.GetUnitById(id);

        return OkOrNoContent(_mapper.Map<UnitDetailViewModel>(unit));
    }
    
    [HttpGet("{id}/factions/", Name = "GetUnitFactions")]
    public ActionResult<IList<FactionViewModel>> GetUnitFactions(int id)
    {
        var unitFactions = _service.GetUnitFactions(id);
        return OkOrNoContent(_mapper.Map<IList<FactionViewModel>>(unitFactions));
    }
    
    [HttpGet("lords/", Name = "GetUnitLords")]
    public ActionResult<IList<UnitViewModel>> GetUnitLords()
    {
        var unitLords = _service.GetUnitLords();
        return OkOrNoContent(_mapper.Map<IList<UnitViewModel>>(unitLords));
    }
    
    [HttpGet("heroes/", Name = "GetUnitHeroes")]
    public ActionResult<IList<UnitViewModel>> GetUnitHeroes()
    {
        var unitHeroes = _service.GetUnitHeroes();
        return OkOrNoContent(_mapper.Map<IList<UnitViewModel>>(unitHeroes));
    }

}
using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TotalArmyBuilder.Api.ViewModels.Factions;
using TotalArmyBuilder.Api.ViewModels.Units;
using TotalArmyBuilder.Dal.Interfaces;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Service.Interfaces;

namespace TotalArmyBuilder.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UnitsController : Controller
{
    private readonly ITotalArmyDatabase _database;
    private readonly IUnitService _service;
    private readonly IMapper _mapper;
    public UnitsController(ITotalArmyDatabase database, IMapper mapper, IUnitService service) => 
        (_database, _mapper, _service) = (database, mapper, service);
        
    [HttpGet]
    public ActionResult<IList<UnitViewModel>> GetUnits([FromQuery] string name, [FromQuery] int cost)
    {
        var units = _service.GetUnits(name, cost);
        return Ok(_mapper.Map<IList<UnitViewModel>>(units));
    }
    
    [HttpGet("{id}", Name = "GetUnitById")]
    public ActionResult<UnitDetailViewModel> GetUnitById(int id)
    {
        var unit = _service.GetUnitById(id);

        return Ok(new {unit});
    }
    
}
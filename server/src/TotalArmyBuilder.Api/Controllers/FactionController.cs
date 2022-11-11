using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TotalArmyBuilder.Api.ViewModels.Accounts;
using TotalArmyBuilder.Api.ViewModels.Factions;
using TotalArmyBuilder.Api.ViewModels.Units;
using TotalArmyBuilder.Dal.Interfaces;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Dal.Specifications.Factions;
using TotalArmyBuilder.Service.Interfaces;
using Unosquare.EntityFramework.Specification.Common.Extensions;

namespace TotalArmyBuilder.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FactionsController : Controller
{
    private readonly ITotalArmyDatabase _database;
    private readonly IFactionService _service;
    private readonly IMapper _mapper;
    public FactionsController(ITotalArmyDatabase database, IMapper mapper, IFactionService service) => 
        (_database, _mapper, _service) = (database, mapper, service);
        
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

        return Ok(new {faction});
    }
}
using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TotalArmyBuilder.Api.ViewModels.Accounts;
using TotalArmyBuilder.Api.ViewModels.Compositions;
using TotalArmyBuilder.Api.ViewModels.Units;
using TotalArmyBuilder.Dal.Interfaces;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Dal.Specifications.Compositions;
using TotalArmyBuilder.Dal.Specifications.Units;
using TotalArmyBuilder.Service.DTOs;
using TotalArmyBuilder.Service.Interfaces;
using Unosquare.EntityFramework.Specification.Common.Extensions;

namespace TotalArmyBuilder.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CompositionsController : Controller
{
    private readonly ITotalArmyDatabase _database;
    private readonly ICompositionService _service;
    private readonly IMapper _mapper;
    public CompositionsController(ITotalArmyDatabase database, IMapper mapper, ICompositionService service) => 
        (_database, _mapper, _service) = (database, mapper, service);
    
    [HttpGet]
    public ActionResult<IList<CompositionViewModel>> GetCompositions([FromQuery] string name, [FromQuery] int factionId, [FromQuery] int avatarId)
    {
        var compositions = _service.GetCompositions(name, factionId, avatarId);
        return Ok(_mapper.Map<IList<CompositionViewModel>>(compositions));
    }

    [HttpGet("{id}", Name = "GetCompositionById")]
    public ActionResult<CompositionDetailViewModel> GetCompositionById(int id)
    {
        var composition = _service.GetCompositionById(id);

        return Ok(new {composition});
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
        var composition = _mapper.Map<Composition>(compositionDetails);
        _service.CreateComposition(composition);
        return StatusCode((int)HttpStatusCode.Created);
    }
    
    [HttpPatch]
    [Route("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public ActionResult UpdateComposition(int id, [FromForm] UpdateCompositionViewModel compositionDetails)
    {
        var composition = _mapper.Map<CompositionDto>(compositionDetails);
        _service.UpdateComposition(id, composition);
        return StatusCode((int)HttpStatusCode.NoContent);
    }
    
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public ActionResult UpdateComposition(int id)
    {
        _service.DeleteComposition(id);
        return StatusCode((int)HttpStatusCode.NoContent);
    }
}


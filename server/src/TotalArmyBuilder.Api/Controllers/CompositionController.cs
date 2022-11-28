using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TotalArmyBuilder.Api.Controllers.Base;
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

[Route("[controller]")]
public class CompositionsController : TotalArmyBaseController
{
    private readonly ICompositionService _service;
    private readonly IMapper _mapper;
    public CompositionsController(IMapper mapper, ICompositionService service) => 
        (_mapper, _service) = (mapper, service);
    
    [HttpGet]
    public ActionResult<IList<CompositionViewModel>> GetCompositions([FromQuery] string? name, [FromQuery] int? battleTypeId, [FromQuery] int? factionId)
    {
        var compositions = _service.GetCompositions(name, battleTypeId, factionId);
        return Ok(_mapper.Map<IList<CompositionViewModel>>(compositions));
    }

    [HttpGet("{id}", Name = "GetCompositionById")]
    public ActionResult<CompositionDetailViewModel> GetCompositionById(int id)
    {
        var composition = _service.GetCompositionById(id);

        return OkOrNoContent(_mapper.Map<CompositionDetailViewModel>(composition));
    }

    [HttpGet("{id}/units/", Name = "GetCompositionUnits")]
    public ActionResult<IList<UnitViewModel>> GetCompositionUnits(int id)
    {
        var compositionUnits = _service.GetCompositionUnits(id);
        return Ok(_mapper.Map<IList<UnitViewModel>>(compositionUnits));
    }
    
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public ActionResult CreateComposition([FromBody] CreateCompositionViewModel compositionDetails)
    {
        var composition = _mapper.Map<CompositionDto>(compositionDetails);
        _service.CreateComposition(composition);
        return StatusCode((int)HttpStatusCode.Created);
    }
    
    [HttpPatch]
    [Route("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public ActionResult UpdateComposition(int id, [FromBody] UpdateCompositionViewModel compositionDetails)
    {
        var composition = _mapper.Map<CompositionDto>(compositionDetails);
        _service.UpdateComposition(id, composition);
        return NoContent();
    }
    
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public ActionResult DeleteComposition(int id)
    {
        _service.DeleteComposition(id);
        return NoContent();
    }
}


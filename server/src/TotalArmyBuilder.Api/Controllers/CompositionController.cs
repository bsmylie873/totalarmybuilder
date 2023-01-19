using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TotalArmyBuilder.Api.Controllers.Base;
using TotalArmyBuilder.Api.ViewModels.Compositions;
using TotalArmyBuilder.Api.ViewModels.Units;
using TotalArmyBuilder.Service.DTOs;
using TotalArmyBuilder.Service.Interfaces;

namespace TotalArmyBuilder.Api.Controllers;

[Route("api/[controller]")]
public class CompositionsController : TotalArmyBaseController
{
    private readonly IMapper _mapper;
    private readonly ICompositionService _service;

    public CompositionsController(IMapper mapper, ICompositionService service)
    {
        (_mapper, _service) = (mapper, service);
    }

    [HttpGet]
    public ActionResult<IList<CompositionViewModel>> GetCompositions([FromQuery] string? name,
        [FromQuery] int? battleTypeId, [FromQuery] int? factionId)
    {
        var compositions = _service.GetCompositions(name, battleTypeId, factionId);
        return OkOrNoContent(_mapper.Map<IList<CompositionViewModel>>(compositions));
    }

    [HttpGet("{id}", Name = "GetCompositionById")]
    public ActionResult<CompositionDetailViewModel> GetCompositionById(int id)
    {
        var composition = _service.GetCompositionById(id);
        return OkOrNoNotFound(_mapper.Map<CompositionDetailViewModel>(composition));
    }

    [HttpGet("{id}/units/", Name = "GetCompositionUnits")]
    public ActionResult<IList<UnitViewModel>> GetCompositionUnits(int id)
    {
        var compositionUnits = _service.GetCompositionUnits(id);
        return OkOrNoContent(_mapper.Map<IList<UnitViewModel>>(compositionUnits));
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
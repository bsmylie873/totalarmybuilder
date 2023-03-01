using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using TotalArmyBuilder.Dal.Interfaces;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Dal.Specifications.Compositions;
using TotalArmyBuilder.Dal.Specifications.CompositionUnits;
using TotalArmyBuilder.Dal.Specifications.Units;
using TotalArmyBuilder.Service.DTOs;
using TotalArmyBuilder.Service.Interfaces;
using TotalArmyBuilder.Service.Services.Exceptions;
using Unosquare.EntityFramework.Specification.Common.Extensions;

namespace TotalArmyBuilder.Service.Services;

public class CompositionService : ICompositionService
{
    private readonly ITotalArmyDatabase _database;
    private readonly IMapper _mapper;

    public CompositionService(ITotalArmyDatabase database, IMapper mapper)
    {
        (_database, _mapper) = (database, mapper);
    }

    public IList<CompositionDto> GetCompositions(string? name, string? battleType, int? factionId, int? budget)
    {
        var compositionQuery = _database
            .Get<Composition>()
            .Where(new CompositionSearchSpec(name, battleType, factionId, budget));

        return _mapper
            .ProjectTo<CompositionDto>(compositionQuery)
            .ToList();
    }

    public CompositionDto GetCompositionById(int id)
    {
        var compositionQuery = _database
            .Get<Composition>()
            .Where(new CompositionByIdSpec(id));

        return _mapper
            .ProjectTo<CompositionDto>(compositionQuery)
            .SingleOrDefault();
    }

    public IList<UnitDto> GetCompositionUnits(int id)
    {
        var unitQuery = _database
            .Get<Unit>()
            .Where(new UnitByCompositionSpec(id));

        return _mapper
            .ProjectTo<UnitDto>(unitQuery)
            .ToList();
        ;
    }

    public void CreateComposition(CompositionDto composition)
    {
        var newComposition = _mapper.Map<Composition>(composition);
        _database.Add(newComposition);
        _database.SaveChanges();
    }
    
    public void UpdateComposition(int id, CompositionDto composition)
    {
        var currentComposition = _database
            .Get<Composition>()
            .FirstOrDefault(new CompositionByIdSpec(id));

        if (currentComposition == null) throw new NotFoundException("Composition Not Found");

        DeleteCompositionUnits(id);
        
        _mapper.Map(composition, currentComposition);
        _database.SaveChanges();
    }

    public void DeleteComposition(int id)
    {
        var currentComposition = _database
            .Get<Composition>()
            .FirstOrDefault(new CompositionByIdSpec(id));
        
        if (currentComposition == null) throw new NotFoundException("Composition Not Found");
        
        _database.Delete(currentComposition);
        _database.SaveChanges();
    }

    private void DeleteCompositionUnits(int id)
    {
        var currentCompositionUnits = _database
            .Get<CompositionUnit>()
            .Where(new CompositionUnitByCompositionIdSpec(id));

        foreach (var compUnit in currentCompositionUnits)
        {
            _database.Delete(compUnit);
        }
    }
}
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using TotalArmyBuilder.Dal.Interfaces;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Dal.Specifications.Compositions;
using TotalArmyBuilder.Service.DTOs;
using TotalArmyBuilder.Service.Interfaces;
using Unosquare.EntityFramework.Specification.Common.Extensions;

namespace TotalArmyBuilder.Service.Services;

public class CompositionService : ICompositionService
{
    private readonly ITotalArmyDatabase _database;
    private readonly IMapper _mapper;
    public CompositionService(ITotalArmyDatabase database, IMapper mapper) => 
        (_database, _mapper) = (database, mapper);

    public IList<CompositionDto> GetCompositions(string? name, int? battleType, int? factionId)
    {
        var compositionQuery = _database
            .Get<Composition>()
            .Where(new CompositionSearchSpec(name, battleType, factionId));

        return _mapper
            .ProjectTo<CompositionDto>(compositionQuery)
            .ToList();
    }
    
    public IList<CompositionDto> GetCompositionById(int id)
    {
        var compositionQuery = _database
            .Get<Composition>()
            .Where(new CompositionByIdSpec(id));

        return _mapper
            .ProjectTo<CompositionDto>(compositionQuery)
            .ToList(); ;
    }
    
    public void CreateComposition(CompositionDto composition)
    {
        _database.Add(composition);
        _database.SaveChanges();
    }


    public void UpdateComposition(int id, CompositionDto composition)
    {
        var currentComposition = _database
            .Get<Composition>()
            .FirstOrDefault(new CompositionByIdSpec(id));

        if (currentComposition == null) throw new Exception("Not Found");

        _mapper.Map(composition, currentComposition);

        _database.SaveChanges();
    }
    
    public void DeleteComposition(int id)
    {
        var currentComposition = _database
            .Get<Composition>()
            .FirstOrDefault(new CompositionByIdSpec(id));

        if (currentComposition == null) throw new Exception("Not Found");
        
        _database.Delete(currentComposition);
        _database.SaveChanges();
    }
}
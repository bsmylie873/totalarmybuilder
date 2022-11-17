using AutoMapper;
using TotalArmyBuilder.Dal.Interfaces;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Dal.Specifications.Factions;
using TotalArmyBuilder.Dal.Specifications.Units;
using TotalArmyBuilder.Service.DTOs;
using TotalArmyBuilder.Service.Interfaces;
using Unosquare.EntityFramework.Specification.Common.Extensions;

namespace TotalArmyBuilder.Service.Services;

public class UnitService : IUnitService
{
    private readonly ITotalArmyDatabase _database;
    private readonly IMapper _mapper;
    public UnitService(ITotalArmyDatabase database, IMapper mapper) => 
        (_database, _mapper) = (database, mapper);

    public IList<UnitDto> GetUnits(string? name, int? cost)
    {
        var unitQuery = _database
            .Get<Unit>()
            .Where(new UnitSearchSpec(name, cost));

        return _mapper
            .ProjectTo<UnitDto>(unitQuery)
            .ToList();
    }
    
    public UnitDto GetUnitById(int id)
    {
        var unitQuery = _database
            .Get<Unit>()
            .Where(new UnitByIdSpec(id));

        return _mapper
            .ProjectTo<UnitDto>(unitQuery)
            .SingleOrDefault(); ;
    }
    
    public IList<FactionDto> GetUnitFactions(int id)
    {
        var factionQuery = _database
            .Get<Faction>()
            .Where(new FactionByUnitSpec(id));

        return _mapper
            .ProjectTo<FactionDto>(factionQuery)
            .ToList(); ;
    }
}
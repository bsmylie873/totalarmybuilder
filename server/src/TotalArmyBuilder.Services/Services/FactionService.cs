using AutoMapper;
using TotalArmyBuilder.Dal.Interfaces;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Dal.Specifications.Factions;
using TotalArmyBuilder.Dal.Specifications.Units;
using TotalArmyBuilder.Service.DTOs;
using TotalArmyBuilder.Service.Interfaces;
using Unosquare.EntityFramework.Specification.Common.Extensions;

namespace TotalArmyBuilder.Service.Services;

public class FactionService : IFactionService
{
    private readonly ITotalArmyDatabase _database;
    private readonly IMapper _mapper;
    public FactionService(ITotalArmyDatabase database, IMapper mapper) => 
        (_database, _mapper) = (database, mapper);

    public IList<FactionDto> GetFactions(string? name)
    {
        var factionQuery = _database
            .Get<Faction>()
            .Where(new FactionSearchSpec(name));

        return _mapper
            .ProjectTo<FactionDto>(factionQuery)
            .ToList();
    }
    
    public FactionDto GetFactionById(int id)
    {
        var factionQuery = _database
            .Get<Faction>()
            .Where(new FactionByIdSpec(id));

        return _mapper
            .ProjectTo<FactionDto>(factionQuery)
            .SingleOrDefault(); ;
    }
    
    public IList<UnitDto> GetFactionUnits(int id)
    {
        var unitQuery = _database
            .Get<Unit>()
            .Where(new UnitByFactionSpec(id));

        return _mapper
            .ProjectTo<UnitDto>(unitQuery)
            .ToList(); ;
    }
}
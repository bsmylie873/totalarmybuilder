using TotalArmyBuilder.Dal.Interfaces;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Service.DTOs;
using TotalArmyBuilder.Service.Interfaces;

namespace TotalArmyBuilder.Service.Services;

public class FactionService : IFactionService
{
    private readonly ITotalArmyDatabase _database;
    public FactionService(ITotalArmyDatabase database) => _database = database;

    public IList<FactionDto> GetFactions()
    {
        var factions = _database.Get<Faction>().ToList();
        //TODO: Use automapper to map to DTOs

        return null;
    }
}
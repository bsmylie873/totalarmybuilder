using TotalArmyBuilder.Dal.Interfaces;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Service.DTOs;
using TotalArmyBuilder.Service.Interfaces;

namespace TotalArmyBuilder.Service.Services;

public class UnitService : IUnitService
{
    private readonly ITotalArmyDatabase _database;
    public UnitService(ITotalArmyDatabase database) => _database = database;

    public IList<UnitDto> GetUnits()
    {
        var units = _database.Get<Unit>().ToList();
        //TODO: Use automapper to map to DTOs

        return null;
    }
}
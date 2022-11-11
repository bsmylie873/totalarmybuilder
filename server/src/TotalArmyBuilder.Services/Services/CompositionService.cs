using TotalArmyBuilder.Dal.Interfaces;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Service.DTOs;
using TotalArmyBuilder.Service.Interfaces;

namespace TotalArmyBuilder.Service.Services;

public class CompositionService : ICompositionService
{
    private readonly ITotalArmyDatabase _database;
    public CompositionService(ITotalArmyDatabase database) => _database = database;

    public IList<CompositionDto> GetCompositions()
    {
        var compositions = _database.Get<Composition>().ToList();
        //TODO: Use automapper to map to DTOs

        return null;
    }
}
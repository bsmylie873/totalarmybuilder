using TotalArmyBuilder.Service.DTOs;

namespace TotalArmyBuilder.Service.Interfaces;

public interface ICompositionService
{
    IList<CompositionDto> GetCompositions(string? name = null, string? battleType = null, int? factionId = null, int? budget = null);
    CompositionDto GetCompositionById(int id);
    IList<UnitDto> GetCompositionUnits(int id);
    IList<UnitDto> GetCompositionUnits2(int id);
    void CreateComposition(CompositionDto composition);
    void UpdateComposition(int id, CompositionDto compositionDto);
    void DeleteComposition(int id);
}
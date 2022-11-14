using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Service.DTOs;

namespace TotalArmyBuilder.Service.Interfaces;

public interface ICompositionService
{
    IList<CompositionDto> GetCompositions(string? name = null, int? battleType = null, int? factionId = null);
    IList<CompositionDto> GetCompositionById(int id);
    IList<CompositionUnit> GetUnitsByComposition(int id);
    void CreateComposition(Composition composition);
    void UpdateComposition(int id, CompositionDto compositionDto);
    void DeleteComposition(int id);
}
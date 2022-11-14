using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Service.DTOs;

namespace TotalArmyBuilder.Service.Interfaces;

public interface IFactionService
{
    IList<FactionDto> GetFactions(string? name = null);
    FactionDto GetFactionById(int id);
}
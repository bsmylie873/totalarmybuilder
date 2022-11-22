using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Service.DTOs;

namespace TotalArmyBuilder.Service.Interfaces;

public interface IUnitService
{
    IList<UnitDto> GetUnits(string? name = null, int? cost = null);
    UnitDto GetUnitById(int id);
    IList<FactionDto> GetUnitFactions(int id);
    IList<UnitDto> GetUnitLords();
    IList<UnitDto> GetUnitHeroes();
}
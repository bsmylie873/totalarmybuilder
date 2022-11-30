namespace TotalArmyBuilder.Service.DTOs;

public class UnitDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? Cost { get; set; }
    public int? AvatarId { get; set; }

    public IList<CompositionDto> Compositions { get; set; }
    public IList<FactionDto> Factions { get; set; }
}
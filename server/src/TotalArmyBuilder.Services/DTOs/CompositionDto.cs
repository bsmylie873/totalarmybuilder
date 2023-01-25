namespace TotalArmyBuilder.Service.DTOs;

public class CompositionDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? BattleType { get; set; }
    public int? FactionId { get; set; }
    public int? AvatarId { get; set; }
    public int? Budget { get; set; }
    public DateTime DateCreated { get; set; }
    public int? Wins { get; set; }
    public int? Losses { get; set; }

    public IList<AccountDto> Accounts { get; set; }
    public IList<UnitDto>? Units { get; set; }
}
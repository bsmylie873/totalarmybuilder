namespace TotalArmyBuilder.Service.DTOs;

public class FactionDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    
    public IList<UnitDto> Units { get; set; }
}
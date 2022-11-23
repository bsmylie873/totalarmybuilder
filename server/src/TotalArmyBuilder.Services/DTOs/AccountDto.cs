namespace TotalArmyBuilder.Service.DTOs;

public class AccountDto
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public IList<CompositionDto>? Compositions { get; set; }
}
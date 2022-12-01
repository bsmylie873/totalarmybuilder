using FluentValidation;

namespace TotalArmyBuilder.Api.ViewModels.Compositions;

public class CompositionViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int BattleType { get; set; }
    public int FactionId { get; set; }
    public int AvatarId { get; set; }
    public DateTime DateCreated { get; set; }
    public int Wins { get; set; }
    public int Losses { get; set; }
}

public class CompositionViewModelValidator : AbstractValidator<CompositionViewModel>
{
    public CompositionViewModelValidator()
    {
        RuleFor(x => x.Id).NotNull();
        When(x => !string.IsNullOrWhiteSpace(x.Name), () => { RuleFor(x => x.Name).Length(5, 100).NotEmpty().WithMessage("Username must be between 5 and 100 characters long."); });
        RuleFor(x => x.BattleType).InclusiveBetween(0, 2).NotNull().WithMessage("Battle Type must be valid.");
        RuleFor(x => x.FactionId).NotNull().WithMessage("Faction Id must not be null.");
        RuleFor(x => x.AvatarId).NotNull().WithMessage("Avatar Id must not be null.");
        RuleFor(x => x.DateCreated).NotNull().WithMessage("Date of creation should not be null.");
        RuleFor(x => x.Wins).GreaterThanOrEqualTo(0).NotNull().WithMessage("Win count must not be negative or null.");
        RuleFor(x => x.Losses).GreaterThanOrEqualTo(0).NotNull().WithMessage("Win count must not be negative or null.");
        ;
    }
}
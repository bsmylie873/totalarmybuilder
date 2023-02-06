using FluentValidation;
using TotalArmyBuilder.Api.ViewModels.Accounts;
using TotalArmyBuilder.Api.ViewModels.Units;

namespace TotalArmyBuilder.Api.ViewModels.Compositions;

public class CreateCompositionViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string BattleType { get; set; }
    public int FactionId { get; set; }
    public int AvatarId { get; set; }
    public int Budget { get; set;}
    public DateTime DateCreated { get; set; }
    public int Wins { get; set; }
    public int Losses { get; set; }

    public IList<UnitViewModel>? Units { get; set; }
}

public class CreateCompositionViewModelValidator : AbstractValidator<CreateCompositionViewModel>
{
    public CreateCompositionViewModelValidator()
    {
        RuleFor(x => x.Id).NotNull();
        When(x => !string.IsNullOrWhiteSpace(x.Name), () => { RuleFor(x => x.Name).Length(5, 100).NotEmpty().WithMessage("Name must be between 5 and 100 characters long."); });
        RuleFor(x => x.BattleType).NotNull().WithMessage("Battle Type must be valid.");
        RuleFor(x => x.FactionId).NotNull().WithMessage("Faction Id must not be null.");
        RuleFor(x => x.AvatarId).NotNull().WithMessage("Avatar Id must not be null.");
        RuleFor(x => x.Budget).GreaterThanOrEqualTo(0).NotNull().WithMessage("Budget must not be negative or null.");
        RuleFor(x => x.DateCreated).NotNull().WithMessage("Date of creation should not be null.");
        RuleFor(x => x.Wins).GreaterThanOrEqualTo(0).NotNull().WithMessage("Win count must not be negative or null.");
        RuleFor(x => x.Losses).GreaterThanOrEqualTo(0).NotNull().WithMessage("Win count must not be negative or null.");
    }
}
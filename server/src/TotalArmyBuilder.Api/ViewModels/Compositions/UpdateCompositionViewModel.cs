using FluentValidation;

namespace TotalArmyBuilder.Api.ViewModels.Compositions;

public class UpdateCompositionViewModel : CompositionViewModel
{
}

public class UpdateCompositionViewModelValidator : AbstractValidator<UpdateCompositionViewModel>
{
    public UpdateCompositionViewModelValidator()
    {
        RuleFor(x => x.Id).NotNull();
        When(x => !string.IsNullOrWhiteSpace(x.Name), () => { RuleFor(x => x.Name).Length(0, 50).NotEmpty(); });
        RuleFor(x => x.BattleType).InclusiveBetween(0, 2).NotNull();
        RuleFor(x => x.FactionId).NotNull();
        RuleFor(x => x.AvatarId).NotNull();
        RuleFor(x => x.DateCreated).NotNull();
        RuleFor(x => x.Wins).GreaterThanOrEqualTo(0).NotNull();
        RuleFor(x => x.Losses).GreaterThanOrEqualTo(0).NotNull();
    }
}
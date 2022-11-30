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
        RuleFor(x => x.Name).Length(0, 50);
        RuleFor(x => x.BattleType).InclusiveBetween(0, 2).NotNull();
        RuleFor(x => x.FactionId).NotNull();
        RuleFor(x => x.AvatarId).NotNull();
        RuleFor(x => x.DateCreated).NotNull();
        RuleFor(x => x.Wins).GreaterThanOrEqualTo(0).NotNull();
        ;
        RuleFor(x => x.Losses).GreaterThanOrEqualTo(0).NotNull();
        ;
    }
}
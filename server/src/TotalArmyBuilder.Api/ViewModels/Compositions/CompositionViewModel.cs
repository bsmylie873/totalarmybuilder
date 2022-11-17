namespace TotalArmyBuilder.Api.ViewModels.Compositions;
using FluentValidation;

public class CompositionViewModel
{
    public string Name { get; set; }
    public int BattleType { get; set; }
    public int FactionId { get; set; }
    public int AvatarId { get; set; }
}

public class CompositionViewModelValidator : AbstractValidator<CompositionViewModel> 
{
    public CompositionViewModelValidator() 
    {
        RuleFor(x => x.Name).Length(0,50);
        RuleFor(x => x.BattleType).InclusiveBetween(0,1).NotNull();
        RuleFor(x => x.FactionId).NotNull();
        RuleFor(x => x.AvatarId).NotNull();
    }
}
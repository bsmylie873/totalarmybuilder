namespace TotalArmyBuilder.Api.ViewModels.Compositions;
using FluentValidation;

public class CompositionViewModel
{
    public string Name { get; set; }
    public int Battle_Type { get; set; }
    public int Faction_Id { get; set; }
    public int Avatar_Id { get; set; }
}

public class CompositionViewModelValidator : AbstractValidator<CompositionViewModel> 
{
    public CompositionViewModelValidator() 
    {
        RuleFor(x => x.Name).Length(0,50);
        RuleFor(x => x.Battle_Type).InclusiveBetween(0,1);
        RuleFor(x => x.Faction_Id).NotNull();
        RuleFor(x => x.Avatar_Id).NotNull();
    }
}
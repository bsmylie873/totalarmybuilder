namespace TotalArmyBuilder.Api.ViewModels.Factions;
using FluentValidation;

public class FactionViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class FactionViewModelValidator : AbstractValidator<FactionViewModel> 
{
    public FactionViewModelValidator() 
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.Name).Length(0, 50);
    }
}
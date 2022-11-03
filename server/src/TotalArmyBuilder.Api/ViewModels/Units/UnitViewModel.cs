namespace TotalArmyBuilder.Api.ViewModels.Units;
using FluentValidation;

public class UnitViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Cost { get; set; }
    public int AvatarId { get; set; }
}

public class UnitViewModelValidator : AbstractValidator<UnitViewModel> 
{
    public UnitViewModelValidator() 
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.Name).Length(0, 50);
        RuleFor(x => x.Cost).NotNull();
        RuleFor(x => x.AvatarId).NotNull();
    }
}
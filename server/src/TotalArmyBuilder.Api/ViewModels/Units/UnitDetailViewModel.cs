namespace TotalArmyBuilder.Api.ViewModels.Units;
using FluentValidation;

public class UnitDetailViewModel : UnitViewModel
{
    public int Id { get; set; }
}

public class UnitDetailViewModelValidator : AbstractValidator<UnitDetailViewModel> 
{
    public UnitDetailViewModelValidator() 
    {
        RuleFor(x => x.Id).NotNull();
    }
}
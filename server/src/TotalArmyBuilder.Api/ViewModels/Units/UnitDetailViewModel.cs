namespace TotalArmyBuilder.Api.ViewModels.Units;
using FluentValidation;

public class UnitDetailViewModel : UnitViewModel
{
}

public class UnitDetailViewModelValidator : AbstractValidator<UnitDetailViewModel> 
{
    public UnitDetailViewModelValidator() 
    {
    }
}
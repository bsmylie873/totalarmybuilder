namespace TotalArmyBuilder.Api.ViewModels.Factions;
using FluentValidation;
public class FactionDetailViewModel : FactionViewModel
{
    
}

public class FactionDetailViewModelValidator : AbstractValidator<FactionDetailViewModel> 
{
    public FactionDetailViewModelValidator() 
    {
    }
}
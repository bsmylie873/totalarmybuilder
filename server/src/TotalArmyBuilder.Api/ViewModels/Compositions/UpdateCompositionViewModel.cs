namespace TotalArmyBuilder.Api.ViewModels.Compositions;
using FluentValidation;
public class UpdateCompositionViewModel : CompositionDetailViewModel
{
    
}

public class UpdateCompositionViewModelValidator : AbstractValidator<UpdateCompositionViewModel> 
{
    public UpdateCompositionViewModelValidator() 
    {
    }
}
namespace TotalArmyBuilder.Api.ViewModels.Compositions;
using FluentValidation;

public class CreateCompositionViewModel : CompositionDetailViewModel
{
    
}

public class CreateCompositionViewModelValidator : AbstractValidator<CreateCompositionViewModel> 
{
    public CreateCompositionViewModelValidator() 
    {
    
    }
}
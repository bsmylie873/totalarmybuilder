namespace TotalArmyBuilder.Api.ViewModels.Accounts;
using FluentValidation;

public class UpdateAccountViewModel : AccountViewModel
{
    
}

public class UpdateAccountViewModelValidator : AbstractValidator<UpdateAccountViewModel> 
{
    public UpdateAccountViewModelValidator() 
    {
        
    }
}
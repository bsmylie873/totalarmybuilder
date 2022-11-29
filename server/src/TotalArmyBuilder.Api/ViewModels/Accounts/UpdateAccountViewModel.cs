namespace TotalArmyBuilder.Api.ViewModels.Accounts;
using FluentValidation;

public class UpdateAccountViewModel : AccountViewModel
{
    
}

public class UpdateAccountViewModelValidator : AbstractValidator<UpdateAccountViewModel> 
{
    public UpdateAccountViewModelValidator() 
    {
        When(x => !string.IsNullOrWhiteSpace(x.Username), () =>
        {
            RuleFor(x => x.Username).Length(0, 50).NotEmpty();
        });
        
        When(x => !string.IsNullOrWhiteSpace(x.Email), () =>
        {
            RuleFor(x => x.Email).EmailAddress().NotNull();
        });
    }
}
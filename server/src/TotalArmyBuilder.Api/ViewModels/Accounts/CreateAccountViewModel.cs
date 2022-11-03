namespace TotalArmyBuilder.Api.ViewModels.Accounts;
using FluentValidation;
public class CreateAccountViewModel : AccountDetailViewModel
{
    public string Email { get; set; }
}

public class CreateAccountViewModelValidator : AbstractValidator<CreateAccountViewModel> 
{
    public CreateAccountViewModelValidator() 
    {
        RuleFor(x => x.Email).EmailAddress();
    }
}
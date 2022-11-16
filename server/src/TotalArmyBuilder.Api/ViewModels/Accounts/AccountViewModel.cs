namespace TotalArmyBuilder.Api.ViewModels.Accounts;
using FluentValidation;

public class AccountViewModel
{
    public string Username { get; set; }
    public string Email { get; set; }
}

public class AccountViewModelValidator : AbstractValidator<AccountViewModel> 
{
    public AccountViewModelValidator() 
    {
        RuleFor(x => x.Username).Length(0, 50);
        RuleFor(x => x.Email).EmailAddress();
    }
}
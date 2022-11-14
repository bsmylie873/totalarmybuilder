namespace TotalArmyBuilder.Api.ViewModels.Accounts;
using FluentValidation;
public class CreateAccountViewModel : AccountViewModel
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class CreateAccountViewModelValidator : AbstractValidator<CreateAccountViewModel> 
{
    public CreateAccountViewModelValidator()
    {
        RuleFor(x => x.Email);
        RuleFor(x => x.Password).Length(0, 50);
    }
}
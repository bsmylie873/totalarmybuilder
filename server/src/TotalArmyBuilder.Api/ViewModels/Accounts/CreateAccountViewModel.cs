using FluentValidation;

namespace TotalArmyBuilder.Api.ViewModels.Accounts;

public class CreateAccountViewModel 
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

public class CreateAccountViewModelValidator : AbstractValidator<CreateAccountViewModel>
{
    public CreateAccountViewModelValidator()
    {
        RuleFor(x => x.Username).Length(5, 100).NotEmpty().WithMessage("Username must be between 5 and 100 characters long."); 
        RuleFor(x => x.Email).EmailAddress().NotEmpty().WithMessage("Email must be in the correct format.");
        RuleFor(x => x.Password).Length(8, 30).NotEmpty().WithMessage("Password must be between 8 and 50 characters long.");
    }
}
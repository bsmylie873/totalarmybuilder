using FluentValidation;

namespace TotalArmyBuilder.Api.ViewModels.Accounts;

public class AccountViewModel
{
    public string Username { get; set; }
    public string Email { get; set; }
}

public class AccountViewModelValidator : AbstractValidator<AccountViewModel>
{
    public AccountViewModelValidator()
    {
        RuleFor(x => x.Username).Length(5, 100).NotNull().NotEmpty().WithMessage("Username must be at least 5 characters long and less than 100.");
        RuleFor(x => x.Email).EmailAddress().NotNull().EmailAddress().NotEmpty().WithMessage("Email must be in the correct format.");
    }
}
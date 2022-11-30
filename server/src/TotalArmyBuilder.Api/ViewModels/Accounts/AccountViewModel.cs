using FluentValidation;

namespace TotalArmyBuilder.Api.ViewModels.Accounts;

public class AccountViewModel
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
}

public class AccountViewModelValidator : AbstractValidator<AccountViewModel>
{
    public AccountViewModelValidator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.Username).Length(0, 50).NotNull();
        RuleFor(x => x.Email).EmailAddress().NotNull();
    }
}
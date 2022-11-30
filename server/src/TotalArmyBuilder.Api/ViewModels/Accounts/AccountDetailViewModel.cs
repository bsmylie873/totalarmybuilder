using FluentValidation;

namespace TotalArmyBuilder.Api.ViewModels.Accounts;

public class AccountDetailViewModel : AccountViewModel
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
}

public class AccountDetailViewModelValidator : AbstractValidator<AccountDetailViewModel>
{
    public AccountDetailViewModelValidator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.Username).Length(0, 50).NotNull();
        RuleFor(x => x.Email).EmailAddress().NotNull();
    }
}
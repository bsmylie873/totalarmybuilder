using FluentValidation;
using TotalArmyBuilder.Api.ViewModels.Compositions;

namespace TotalArmyBuilder.Api.ViewModels.Accounts;

public class AccountDetailViewModel
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public IList<CompositionViewModel>? Compositions { get; set; }
}

public class AccountDetailViewModelValidator : AbstractValidator<AccountDetailViewModel>
{
    public AccountDetailViewModelValidator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.Username).Length(5, 100).NotNull().NotEmpty().WithMessage("Username must be at least 5 characters long and less than 100.");
        RuleFor(x => x.Email).EmailAddress().NotEmpty().WithMessage("Email must be in the correct format.");
    }
}
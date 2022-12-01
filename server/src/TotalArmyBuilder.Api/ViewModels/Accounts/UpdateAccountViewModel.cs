using FluentValidation;

namespace TotalArmyBuilder.Api.ViewModels.Accounts;

public class UpdateAccountViewModel
{
    public string? Username { get; set; }
    public string? Email { get; set; }
}

public class UpdateAccountViewModelValidator : AbstractValidator<UpdateAccountViewModel>
{
    public UpdateAccountViewModelValidator()
    {
        RuleFor(x => x).Must(x => x.Username != null && x.Email != null).WithMessage("At least one parameter required.").WithName("NoValue");
        When(x => x.Username != null, () => { RuleFor(x => x.Username).Length(5, 100).NotEmpty().WithMessage("Username must be between 5 and 100 characters long."); });
        When(x => x.Email != null, () => { RuleFor(x => x.Email).EmailAddress().NotEmpty().WithMessage("Email must be in the correct format."); });
    }
}
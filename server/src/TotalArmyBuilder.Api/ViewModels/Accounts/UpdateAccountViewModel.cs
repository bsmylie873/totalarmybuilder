using FluentValidation;

namespace TotalArmyBuilder.Api.ViewModels.Accounts;

public class UpdateAccountViewModel : AccountViewModel
{
    public string? Password { get; set; }
}

public class UpdateAccountViewModelValidator : AbstractValidator<UpdateAccountViewModel>
{
    public UpdateAccountViewModelValidator()
    {
        When(x => !string.IsNullOrWhiteSpace(x.Username), () => { RuleFor(x => x.Username).Length(0, 50).NotEmpty(); });

        When(x => !string.IsNullOrWhiteSpace(x.Email), () => { RuleFor(x => x.Email).EmailAddress().NotNull(); });
        When(x => !string.IsNullOrWhiteSpace(x.Password), () => { RuleFor(x => x.Password).EmailAddress().NotNull(); });
    }
}
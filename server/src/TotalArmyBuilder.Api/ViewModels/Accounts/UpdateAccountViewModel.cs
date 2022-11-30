using FluentValidation;

namespace TotalArmyBuilder.Api.ViewModels.Accounts;

public class UpdateAccountViewModel : AccountViewModel
{
    public string? Username { get; set; }
    public string? Email { get; set; }
}

public class UpdateAccountViewModelValidator : AbstractValidator<UpdateAccountViewModel>
{
    public UpdateAccountViewModelValidator()
    {
        RuleFor(x => x).Must(x => x.Username != null && x.Email != null);
        When(x => x.Username != null, () => { RuleFor(x => x.Username).Length(0, 50).NotEmpty(); });
        When(x => x.Email != null, () => { RuleFor(x => x.Email).EmailAddress().NotNull(); });
    }
}
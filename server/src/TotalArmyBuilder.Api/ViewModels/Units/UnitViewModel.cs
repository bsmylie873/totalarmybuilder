using FluentValidation;

namespace TotalArmyBuilder.Api.ViewModels.Units;

public class UnitViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Cost { get; set; }
    public int AvatarId { get; set; }
}

public class UnitViewModelValidator : AbstractValidator<UnitViewModel>
{
    public UnitViewModelValidator()
    {
        RuleFor(x => x.Id).NotNull().WithMessage("Id must not be null.");
        RuleFor(x => x.Name).Length(1, 101).NotNull().NotEmpty().WithMessage("Name must be at least 1 character long and less than 100.");
        RuleFor(x => x.Cost).GreaterThanOrEqualTo(0).NotNull().WithMessage("Cost must not be negative or null.");
        RuleFor(x => x.AvatarId).NotNull().WithMessage("Avatar Id must not be null.");
    }
}
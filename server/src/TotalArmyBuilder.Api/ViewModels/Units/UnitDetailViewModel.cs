using FluentValidation;

namespace TotalArmyBuilder.Api.ViewModels.Units;

public class UnitDetailViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Cost { get; set; }
    public int AvatarId { get; set; }
}

public class UnitDetailViewModelValidator : AbstractValidator<UnitDetailViewModel>
{
    public UnitDetailViewModelValidator()
    {
        RuleFor(x => x.Id).NotNull().WithMessage("Id must not be null.");
        RuleFor(x => x.Name).Length(0, 50);
        RuleFor(x => x.Cost).GreaterThanOrEqualTo(0).NotNull();
        RuleFor(x => x.AvatarId).NotNull();
    }
}
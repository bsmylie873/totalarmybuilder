using FluentValidation;

namespace TotalArmyBuilder.Api.ViewModels.Factions;

public class FactionDetailViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class FactionDetailViewModelValidator : AbstractValidator<FactionDetailViewModel>
{
    public FactionDetailViewModelValidator()
    {
        RuleFor(x => x.Id).NotNull().WithMessage("Id must not be null.");
        RuleFor(x => x.Name).Length(2, 50).NotNull().NotEmpty().WithMessage("Name must be at least 2 characters long and less than 50.");
    }
}
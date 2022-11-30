using FluentValidation;

namespace TotalArmyBuilder.Api.ViewModels.Factions;

public class FactionDetailViewModel : FactionViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class FactionDetailViewModelValidator : AbstractValidator<FactionDetailViewModel>
{
    public FactionDetailViewModelValidator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.Name).Length(0, 50);
    }
}
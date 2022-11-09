using TotalArmyBuilder.Api.ViewModels.Units;
using FluentValidation;

namespace TotalArmyBuilder.Api.ViewModels.Compositions;

public class CompositionDetailViewModel : CompositionViewModel
{
    public List<UnitDetailViewModel> Unit_List { get; set; }
}

public class CompositionDetailViewModelValidator : AbstractValidator<CompositionDetailViewModel> 
{
    public CompositionDetailViewModelValidator() 
    {
        RuleFor(x => x.Unit_List).NotNull();
    }
}
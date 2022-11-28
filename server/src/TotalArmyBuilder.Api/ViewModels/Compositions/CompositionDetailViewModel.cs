using TotalArmyBuilder.Api.ViewModels.Units;
using FluentValidation;

namespace TotalArmyBuilder.Api.ViewModels.Compositions;

public class CompositionDetailViewModel : CompositionViewModel
{
    public int Id { get; set; }
    public DateTime DateCreated { get; set; }
    public int Wins { get; set; }
    public int Losses { get; set; }
    public List<UnitDetailViewModel> Unit_List { get; set; }
}

public class CompositionDetailViewModelValidator : AbstractValidator<CompositionDetailViewModel> 
{
    public CompositionDetailViewModelValidator() 
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.DateCreated).NotNull();
        RuleFor(x => x.Unit_List).NotEmpty();
    }
}
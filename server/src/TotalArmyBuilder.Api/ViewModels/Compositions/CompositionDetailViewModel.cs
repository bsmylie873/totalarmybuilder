using TotalArmyBuilder.Api.ViewModels.Units;

namespace TotalArmyBuilder.Api.ViewModels.Compositions;

public class CompositionDetailViewModel : CompositionViewModel
{
    public List<UnitDetailViewModel> Unit_List { get; set; }
}
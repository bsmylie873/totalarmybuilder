using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TotalArmyBuilder.Dal.Specifications.Compositions;

public class CompositionByBudgetSpec : Specification<Composition>
{
    private readonly int? _budget;

    public CompositionByBudgetSpec(int? budget)
    {
        _budget = budget;
    }

    public override Expression<Func<Composition, bool>> BuildExpression()
    {
        if (_budget == null) return ShowAll;
        return x => x.Budget == _budget;
    }
}
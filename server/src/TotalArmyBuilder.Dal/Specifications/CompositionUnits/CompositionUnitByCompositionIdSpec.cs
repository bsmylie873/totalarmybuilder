using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TotalArmyBuilder.Dal.Specifications.CompositionUnits;

public class CompositionUnitByCompositionIdSpec : Specification<CompositionUnit>
{
    private readonly int _compositionId;

    public CompositionUnitByCompositionIdSpec(int id)
    {
        _compositionId = id;
    }

    public override Expression<Func<CompositionUnit, bool>> BuildExpression()
    {
        if (_compositionId <= 0) return ShowNone;

        return x => x.CompositionId == _compositionId;
    }
}
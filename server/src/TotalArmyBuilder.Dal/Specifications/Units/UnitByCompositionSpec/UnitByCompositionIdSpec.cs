using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TotalArmyBuilder.Dal.Specifications.Units;

public class UnitByCompositionIdSpec : Specification<CompositionUnit>
{
    private readonly int _compositionId;

    public UnitByCompositionIdSpec(int id)
    {
        _compositionId = id;
    }

    public override Expression<Func<CompositionUnit, bool>> BuildExpression()
    {
        if (_compositionId <= 0) return ShowNone;

        return x => x.CompositionId == _compositionId;
    }
}
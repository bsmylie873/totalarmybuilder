using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TotalArmyBuilder.Dal.Specifications.CompositionUnits;

public class CompositionUnit2ByCompositionIdSpec : Specification<CompositionUnit2>
{
    private readonly int _compositionId;

    public CompositionUnit2ByCompositionIdSpec(int id)
    {
        _compositionId = id;
    }

    public override Expression<Func<CompositionUnit2, bool>> BuildExpression()
    {
        if (_compositionId <= 0) return ShowNone;

        return x => x.CompositionId == _compositionId;
    }
}
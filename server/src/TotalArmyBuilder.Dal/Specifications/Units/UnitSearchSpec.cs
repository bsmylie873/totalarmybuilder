using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Extensions;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TotalArmyBuilder.Dal.Specifications.Units;

public class UnitSearchSpec : Specification<Unit>
{
    private readonly Specification<Unit> _spec;

    public UnitSearchSpec(string? name, int? cost)
    {
        _spec = new UnitByNameSpec(name)
            .Or(new UnitByCostSpec(cost));
    }

    public override Expression<Func<Unit, bool>> BuildExpression() => _spec.BuildExpression();
}
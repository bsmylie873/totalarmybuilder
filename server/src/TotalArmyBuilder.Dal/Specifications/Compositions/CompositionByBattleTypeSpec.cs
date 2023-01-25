using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TotalArmyBuilder.Dal.Specifications.Compositions;

public class CompositionByBattleTypeSpec : Specification<Composition>
{
    private readonly string? _battleType;

    public CompositionByBattleTypeSpec(string? battleType)
    {
        _battleType = battleType;
    }

    public override Expression<Func<Composition, bool>> BuildExpression()
    {
        if (_battleType == null) return ShowAll;
        return x => x.BattleType.StartsWith(_battleType);
    }
}
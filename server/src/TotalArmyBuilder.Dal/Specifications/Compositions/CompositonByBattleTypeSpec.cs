using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TotalArmyBuilder.Dal.Specifications.Compositions;

public class CompositionByBattleType : Specification<Composition>
{
    private readonly int _battleType;
    public CompositionByBattleType(int battleType) => _battleType = battleType;

    public override Expression<Func<Composition, bool>> BuildExpression() =>
        x => x.BattleType == _battleType;
}
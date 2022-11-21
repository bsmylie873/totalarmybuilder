using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TotalArmyBuilder.Dal.Specifications.Compositions;

public class CompositionByBattleTypeSpec : Specification<Composition>
{
    private readonly int? _battleType;
    public CompositionByBattleTypeSpec(int? battleType) => _battleType = battleType;

    public override Expression<Func<Composition, bool>> BuildExpression()
    { 
        if (_battleType == null) return ShowAll;
        return x => x.BattleType == _battleType;
    }
        
}
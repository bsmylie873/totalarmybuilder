using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TotalArmyBuilder.Dal.Specifications.Units;

public class UnitByCostSpec : Specification<Unit>
{
    private readonly int? _cost;
    public UnitByCostSpec(int? cost) => _cost = cost;
    
    public override Expression<Func<Unit, bool>> BuildExpression()
    {
        if (_cost == null || _cost == 0) return ShowAll;
        return x => x.Cost == _cost;
    }
}
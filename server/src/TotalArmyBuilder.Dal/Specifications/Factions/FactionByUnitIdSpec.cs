using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TotalArmyBuilder.Dal.Specifications.Factions;

public class FactionByUnitIdSpec : Specification<UnitFaction>
{
    private readonly int _unitId;
    
    public FactionByUnitIdSpec(int id) => _unitId = id;

    public override Expression<Func<UnitFaction, bool>> BuildExpression()
    {
        if (_unitId <= 0) return ShowNone;

        return x => x.UnitId == _unitId;
    }
}
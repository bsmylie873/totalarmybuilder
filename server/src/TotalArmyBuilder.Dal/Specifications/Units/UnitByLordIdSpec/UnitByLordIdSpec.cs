using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TotalArmyBuilder.Dal.Specifications.Units;

public class UnitByLordIdSpec : Specification<LordUnit>
{
    private readonly int _unitId;
    
    public UnitByLordIdSpec(int id) => _unitId = id;

    public override Expression<Func<LordUnit, bool>> BuildExpression()
    {
        if (_unitId <= 0) return ShowNone;

        return x => x.UnitId == _unitId;
    }
}
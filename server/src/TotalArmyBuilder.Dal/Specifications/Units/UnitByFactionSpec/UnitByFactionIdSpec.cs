using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TotalArmyBuilder.Dal.Specifications.Units;

public class UnitByFactionIdSpec : Specification<UnitFaction>
{
    private readonly int _factionId;
    
    public UnitByFactionIdSpec(int id) => _factionId = id;

    public override Expression<Func<UnitFaction, bool>> BuildExpression()
    {
        if (_factionId <= 0) return ShowNone;

        return x => x.FactionId == _factionId;
    }
}
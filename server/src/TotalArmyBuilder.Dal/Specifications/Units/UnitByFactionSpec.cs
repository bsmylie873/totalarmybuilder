using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TotalArmyBuilder.Dal.Specifications.Units;

public class UnitByFactionSpec : Specification<UnitFaction>
{
    private readonly int _factionId;
    public UnitByFactionSpec(int factionId) => _factionId = factionId;

    public override Expression<Func<UnitFaction, bool>> BuildExpression() =>
        x => x.FactionId == _factionId;
}
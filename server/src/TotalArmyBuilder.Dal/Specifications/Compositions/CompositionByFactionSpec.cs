using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TotalArmyBuilder.Dal.Specifications.Compositions;

public class CompositionByFactionSpec : Specification<Composition>
{
    private readonly int? _factionId;

    public CompositionByFactionSpec(int? factionId)
    {
        _factionId = factionId;
    }

    public override Expression<Func<Composition, bool>> BuildExpression()
    {
        if (_factionId == null) return ShowAll;
        return x => x.FactionId == _factionId;
    }
}
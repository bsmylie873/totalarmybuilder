using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TotalArmyBuilder.Dal.Specifications.Factions;

public class FactionSearchSpec : Specification<Faction>
{
    private readonly Specification<Faction> _spec;

    public FactionSearchSpec(string? name)
    {
        _spec = new FactionByNameSpec(name);
    }

    public override Expression<Func<Faction, bool>> BuildExpression()
    {
        return _spec.BuildExpression();
    }
}
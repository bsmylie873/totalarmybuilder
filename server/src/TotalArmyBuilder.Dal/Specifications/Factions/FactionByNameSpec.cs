using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TotalArmyBuilder.Dal.Specifications.Factions;

public class FactionByNameSpec : Specification<Faction>
{
    private readonly string _name;

    public FactionByNameSpec(string name)
    {
        _name = name;
    }

    public override Expression<Func<Faction, bool>> BuildExpression()
    {
        if (string.IsNullOrWhiteSpace(_name)) return ShowAll;

        return x => x.Name.StartsWith(_name);
    }
}
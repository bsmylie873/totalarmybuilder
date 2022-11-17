using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Extensions;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TotalArmyBuilder.Dal.Specifications.Factions;

public class FactionByUnitSpec : Specification<Faction>
{
    private readonly int _id;
    public FactionByUnitSpec(int id) => _id = id;

    public override Expression<Func<Faction, bool>> BuildExpression()
    {
        return x =>
            x.UnitFactions
                .Any(y => new FactionByUnitIdSpec(_id)
                    .Embed()(y));
    }
}
using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Extensions;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TotalArmyBuilder.Dal.Specifications.Units;

public class UnitByFactionSpec : Specification<Unit>
{
    private readonly int _id;

    public UnitByFactionSpec(int id)
    {
        _id = id;
    }

    public override Expression<Func<Unit, bool>> BuildExpression()
    {
        return x =>
            x.UnitFactions
                .Any(y => new UnitByFactionIdSpec(_id)
                    .Embed()(y));
    }
}
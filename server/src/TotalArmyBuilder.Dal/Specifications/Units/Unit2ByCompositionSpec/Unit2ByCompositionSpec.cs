using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Extensions;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TotalArmyBuilder.Dal.Specifications.Units;

public class Unit2ByCompositionSpec : Specification<Unit>
{
    private readonly int _id;

    public Unit2ByCompositionSpec(int id)
    {
        _id = id;
    }

    public override Expression<Func<Unit, bool>> BuildExpression()
    {
        return x =>
            x.CompositionUnits2
                .Any(y => new Unit2ByCompositionIdSpec(_id)
                    .Embed()(y));
    }
}
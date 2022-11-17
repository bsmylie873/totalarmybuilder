using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Extensions;
using Unosquare.EntityFramework.Specification.Common.Primitive;


namespace TotalArmyBuilder.Dal.Specifications.Units;

public class UnitByCompositionSpec : Specification<Unit>
{
    private readonly int _id;
    public UnitByCompositionSpec(int id) => _id = id;

    public override Expression<Func<Unit, bool>> BuildExpression()
    {
        return x =>
            x.CompositionUnits
                .Any(y => new UnitByCompositionIdSpec(_id)
                    .Embed()(y));
    }
}
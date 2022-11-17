using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Extensions;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TotalArmyBuilder.Dal.Specifications.Units;

public class UnitByLordSpec : Specification<Unit>
{
    private readonly int _id;
    public UnitByLordSpec(int id) => _id = id;

    public override Expression<Func<Unit, bool>> BuildExpression()
    {
        return x =>
            x.LordUnits
                .Any(y => new UnitByLordIdSpec(_id)
                    .Embed()(y));
    }
}
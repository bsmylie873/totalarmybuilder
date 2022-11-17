using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Extensions;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TotalArmyBuilder.Dal.Specifications.Units;

public class UnitByHeroSpec : Specification<Unit>
{
    private readonly int _id;
    public UnitByHeroSpec(int id) => _id = id;
    
    public override Expression<Func<Unit, bool>> BuildExpression()
    {
        return x =>
            x.HeroUnits
                .Any(y => new UnitByHeroIdSpec(_id)
                    .Embed()(y));
    }
}
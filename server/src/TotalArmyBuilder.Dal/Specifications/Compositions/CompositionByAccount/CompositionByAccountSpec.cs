using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Extensions;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TotalArmyBuilder.Dal.Specifications.Compositions;

public class CompositionByAccountSpec : Specification<Composition>
{
    private readonly int _id;

    public CompositionByAccountSpec(int id)
    {
        _id = id;
    }

    public override Expression<Func<Composition, bool>> BuildExpression()
    {
        return x =>
            x.AccountCompositions
                .Any(y => new CompositionByAccountIdSpec(_id)
                    .Embed()(y));
    }
}
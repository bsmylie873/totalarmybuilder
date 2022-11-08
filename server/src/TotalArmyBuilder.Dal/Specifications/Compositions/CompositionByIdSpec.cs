using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TotalArmyBuilder.Dal.Specifications.Compositions;

public class CompositionByIdSpec : Specification<Composition>
{
    private readonly int _id;
    public CompositionByIdSpec(int id) => _id = id;
    
    public override Expression<Func<Composition, bool>> BuildExpression() =>
        x => x.Id == _id;
}
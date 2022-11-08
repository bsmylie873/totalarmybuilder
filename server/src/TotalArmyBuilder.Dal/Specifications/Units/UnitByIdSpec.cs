using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TotalArmyBuilder.Dal.Specifications.Units;

public class UnitByIdSpec : Specification<Unit>
{
    private readonly int _id;
    public UnitByIdSpec(int id) => _id = id;
    
    public override Expression<Func<Unit, bool>> BuildExpression() =>
        x => x.Id == _id;
}
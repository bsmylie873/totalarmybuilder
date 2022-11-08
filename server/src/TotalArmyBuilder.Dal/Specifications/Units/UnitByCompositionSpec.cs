using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;


namespace TotalArmyBuilder.Dal.Specifications.Units;

public class UnitByCompositionSpec : Specification<CompositionUnit>
{
    private readonly int _unitId;
    public UnitByCompositionSpec(int unitId) => _unitId = unitId;

    public override Expression<Func<CompositionUnit, bool>> BuildExpression() =>
        x => x.UnitId == _unitId;
}
using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;


namespace TotalArmyBuilder.Dal.Specifications.Units;

public class UnitByCompositionSpec : Specification<CompositionUnit>
{
    private readonly int _compositionId;
    public UnitByCompositionSpec(int compositionId) => _compositionId = compositionId;

    public override Expression<Func<CompositionUnit, bool>> BuildExpression() =>
        //x => x.Id == _unitId;

        y => y.CompositionId == _compositionId;
}
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Dal.Specifications.Compositions;
using Unosquare.EntityFramework.Specification.Common.Extensions;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TotalArmyBuilder.Dal.Specifications.Compositions;

public class CompositionSearchSpec : Specification<Composition>
{
    private readonly Specification<Composition> _spec;

    public CompositionSearchSpec(string? name, int? battleType, int? factionId)
    {
        _spec = new CompositionByNameSpec(name)
            .Or(new CompositionByBattleTypeSpec((int)battleType))
            .Or(new CompositionByFactionSpec((int)factionId));
    }

    public override Expression<Func<Composition, bool>> BuildExpression() => _spec.BuildExpression();
}
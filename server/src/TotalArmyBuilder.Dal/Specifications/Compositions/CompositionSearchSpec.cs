﻿using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Extensions;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TotalArmyBuilder.Dal.Specifications.Compositions;

public class CompositionSearchSpec : Specification<Composition>
{
    private readonly Specification<Composition> _spec;

    public CompositionSearchSpec(string? name, string? battleType, int? factionId, int? budget)
    {
        _spec = new CompositionByNameSpec(name)
            .Or(new CompositionByBattleTypeSpec(battleType)
                .Or(new CompositionByFactionSpec(factionId))
                    .Or(new CompositionByBudgetSpec(budget)));

    }

    public override Expression<Func<Composition, bool>> BuildExpression()
    {
        return _spec.BuildExpression();
    }
}
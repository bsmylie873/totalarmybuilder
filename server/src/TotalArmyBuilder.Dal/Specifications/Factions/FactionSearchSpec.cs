using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Dal.Specifications.Compositions;
using TotalArmyBuilder.Dal.Specifications.Factions;
using Unosquare.EntityFramework.Specification.Common.Extensions;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TotalArmyBuilder.Dal.Specifications.Factions;

public class FactionSearchSpec : Specification<Faction>
{
    private readonly Specification<Faction> _spec;

    public FactionSearchSpec(string? name)
    {
        _spec = new FactionByNameSpec(name);
    }

    public override Expression<Func<Faction, bool>> BuildExpression() => _spec.BuildExpression();
}
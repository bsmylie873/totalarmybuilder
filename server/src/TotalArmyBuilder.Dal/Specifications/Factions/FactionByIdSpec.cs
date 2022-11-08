using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TotalArmyBuilder.Dal.Specifications.Factions;

public class FactionByIdSpec : Specification<Faction>
{
    private readonly int _id;
    public FactionByIdSpec(int id) => _id = id;
    
    public override Expression<Func<Faction, bool>> BuildExpression() =>
        x => x.Id == _id;
}
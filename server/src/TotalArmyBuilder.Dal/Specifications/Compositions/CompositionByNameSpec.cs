using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TotalArmyBuilder.Dal.Specifications.Compositions;

public class CompositionByNameSpec : Specification<Composition>
{
    private readonly string _name;

    public CompositionByNameSpec(string name)
    {
        _name = name;
    }

    public override Expression<Func<Composition, bool>> BuildExpression()
    {
        if (string.IsNullOrWhiteSpace(_name)) return ShowAll;

        return x => x.Name.StartsWith(_name);
    }
}
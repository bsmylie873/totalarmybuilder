using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TotalArmyBuilder.Dal.Specifications.Units;

public class UnitByNameSpec : Specification<Unit>
{
    private readonly string _name;
    public UnitByNameSpec(string name) => _name = name;
    
    public override Expression<Func<Unit, bool>> BuildExpression(){
        if (string.IsNullOrWhiteSpace(_name)) return ShowAll;
        
        return x => x.Name.StartsWith(_name);
    }
}
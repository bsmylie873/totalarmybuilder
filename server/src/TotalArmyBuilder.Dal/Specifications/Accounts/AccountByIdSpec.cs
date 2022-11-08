using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TotalArmyBuilder.Dal.Specifications.Accounts;

public class AccountByIdSpec : Specification<Account>
{
    private readonly int _id;
    public AccountByIdSpec(int id) => _id = id;
    
    public override Expression<Func<Account, bool>> BuildExpression() =>
        x => x.Id == _id;
}
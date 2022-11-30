using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TotalArmyBuilder.Dal.Specifications.Compositions;

public class CompositionByAccountIdSpec : Specification<AccountComposition>
{
    private readonly int _accountId;

    public CompositionByAccountIdSpec(int id)
    {
        _accountId = id;
    }

    public override Expression<Func<AccountComposition, bool>> BuildExpression()
    {
        if (_accountId <= 0) return ShowNone;

        return x => x.AccountId == _accountId;
    }
}
using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TotalArmyBuilder.Dal.Specifications.Compositions;

public class CompositionByAccountSpec : Specification<AccountComposition>
{
    private readonly int _accountId;
    public CompositionByAccountSpec(int accountId) => _accountId = accountId;

    public override Expression<Func<AccountComposition, bool>> BuildExpression() =>
        x => x.AccountId == _accountId;
}
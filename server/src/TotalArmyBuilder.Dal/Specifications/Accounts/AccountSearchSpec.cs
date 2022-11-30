using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Extensions;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TotalArmyBuilder.Dal.Specifications.Accounts;

public class AccountSearchSpec : Specification<Account>
{
    private readonly Specification<Account> _spec;

    public AccountSearchSpec(string? username, string? email)
    {
        _spec = new AccountByEmailSpec(username)
            .Or(new AccountByUsernameSpec(email));
    }

    public override Expression<Func<Account, bool>> BuildExpression()
    {
        return _spec.BuildExpression();
    }
}
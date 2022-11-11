using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TotalArmyBuilder.Dal.Specifications.Accounts;

public class AccountByEmailSpec : Specification<Account>
{
    private readonly string? _email;
    public AccountByEmailSpec(string? email) => _email = email;

    public override Expression<Func<Account, bool>> BuildExpression()
    {
        if (string.IsNullOrWhiteSpace(_email)) return ShowAll;
        
        return x => x.Email.Contains(_email);
    }
        
}
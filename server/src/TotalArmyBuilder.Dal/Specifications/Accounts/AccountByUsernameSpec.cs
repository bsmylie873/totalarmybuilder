using System.Linq.Expressions;
using TotalArmyBuilder.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TotalArmyBuilder.Dal.Specifications.Accounts;

public class AccountByUsernameSpec : Specification<Account>
{
    private readonly string _username;
    public AccountByUsernameSpec(string username) => _username = username;

    public override Expression<Func<Account, bool>> BuildExpression()
    {
        if (string.IsNullOrWhiteSpace(_username)) return ShowAll;
        
        return x => x.Email.StartsWith(_username);
    }
        
}
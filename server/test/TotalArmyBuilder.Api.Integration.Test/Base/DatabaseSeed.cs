using TotalArmyBuilder.Dal.Contexts;
using TotalArmyBuilder.Dal.Models;

namespace TotalArmyBuilder.Api.Integration.Test.Base;

public static class DatabaseSeed
{
    public static void SeedDatabase(TotalArmyContext database)
    {
        database.Accounts.Add(new Account
        {
            Username = "test",
            Password = "password",
            Email = "email"
        });

        database.SaveChanges();
    }
}
using AutoFixture;
using TotalArmyBuilder.Dal.Models;

namespace TotalArmyBuilder.Services.Test.Customisations;
public class AccountCustomisation : ICustomization
{
    private readonly string _username = "test";
    
    public AccountCustomisation(string username)
    {
        _username = username;
    }

    public void Customize(IFixture fixture)
    {
        fixture.Customize<Account>(composer => composer
            .With(x=> x.Id)
            .With(x => x.Username, _username)
            .With(x => x.Email)
            .With(x => x.Password)
            .Without(x => x.AccountCompositions)
        );
    }
}
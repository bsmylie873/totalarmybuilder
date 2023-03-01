using AutoFixture;
using TotalArmyBuilder.Dal.Models;

namespace TotalArmyBuilder.Services.Test.Customisations;

public class AccountCustomisation : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Customize<Account>(composer => composer
            .With(x => x.Id)
            .With(x => x.Username)
            .With(x => x.Email)
            .With(x => x.Password)
            .With(x => x.AccountCompositions)
        );
    }
}
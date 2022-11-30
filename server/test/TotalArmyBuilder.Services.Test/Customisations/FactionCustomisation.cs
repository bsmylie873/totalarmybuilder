using AutoFixture;
using TotalArmyBuilder.Dal.Models;

namespace TotalArmyBuilder.Services.Test.Customisations;

public class FactionCustomisation : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Customize<Faction>(composer => composer
            .With(x => x.Id)
            .With(x => x.Name)
            .Without(x => x.UnitFactions)
        );
    }
}
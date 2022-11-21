using AutoFixture;
using TotalArmyBuilder.Dal.Models;

namespace TotalArmyBuilder.Services.Test.Customisations;
public class FactionCustomisation : ICustomization
{
    private readonly string _name = "test";
    
    public FactionCustomisation(string name)
    {
        _name = name;
    }

    public void Customize(IFixture fixture)
    {
        fixture.Customize<Faction>(composer => composer
            .With (x=> x.Id)
            .With(x => x.Name, _name)
            .Without(x => x.UnitFactions)
        );
    }
}
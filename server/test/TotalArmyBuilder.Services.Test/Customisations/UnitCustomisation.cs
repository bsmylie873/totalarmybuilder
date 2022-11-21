using AutoFixture;
using TotalArmyBuilder.Dal.Models;

namespace TotalArmyBuilder.Services.Test.Customisations;
public class UnitCustomisation : ICustomization
{
    private readonly string _name = "test";

    public UnitCustomisation() { }
    public UnitCustomisation(string name)
    {
        _name = name;
    }

    public void Customize(IFixture fixture)
    {
        fixture.Customize<Unit>(composer => composer
            .With(x => x.Id)
            .With(x => x.Name, _name)
            .With(x => x.Cost)
            .With(x => x.AvatarId)
            .Without(x => x.CompositionUnits)
            .Without(x=> x.UnitFactions)
            .Without(x => x.LordUnits)
            .Without(x=> x.HeroUnits)
        );
    }
}
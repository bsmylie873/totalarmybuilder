using AutoFixture;
using TotalArmyBuilder.Dal.Models;

namespace TotalArmyBuilder.Services.Test.Customisations;
public class UnitCustomisation : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Customize<Unit>(composer => composer
            .With(x => x.Id)
            .With(x => x.Name)
            .With(x => x.Cost)
            .With(x => x.AvatarId)
            .Without(x => x.CompositionUnits)
            .Without(x=> x.UnitFactions)
        );
    }
}
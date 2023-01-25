using AutoFixture;
using TotalArmyBuilder.Dal.Models;

namespace TotalArmyBuilder.Services.Test.Customisations;

public class CompositionCustomisation : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Customize<Composition>(composer => composer
            .With(x => x.Id)
            .With(x => x.Name)
            .With(x => x.BattleType)
            .With(x => x.FactionId)
            .With(x => x.AvatarId)
            .With(x => x.DateCreated, DateTime.Today)
            .With(x => x.Wins)
            .With(x => x.Losses)
            .Without(x => x.AccountCompositions)
            .Without(x => x.CompositionUnits)
        );
    }
}
using TotalArmyBuilder.Dal.Contexts;
using TotalArmyBuilder.Dal.Models;

namespace TotalArmyBuilder.Api.Integration.Test.Base;

public static class DatabaseSeed
{
    public static void SeedDatabase(TotalArmyContext database)
    {
        var unit1 = new Unit
        {
            Id = 1,
            Name = "unit1",
            Cost = 1,
            AvatarId = 1
        };

        var unit2 = new Unit
        {
            Id = 2,
            Name = "unit2",
            Cost = 2,
            AvatarId = 2
        };

        var unit3 = new Unit
        {
            Id = 3,
            Name = "unit3",
            Cost = 3,
            AvatarId = 3
        };

        var lordUnit1 = new LordUnit
        {
            Id = 1,
            UnitId = 1
        };

        var heroUnit1 = new HeroUnit
        {
            Id = 1,
            UnitId = 2
        };

        var heroUnit2 = new HeroUnit
        {
            Id = 2,
            UnitId = 3
        };

        var faction1 = new Faction
        {
            Id = 1,
            Name = "faction1"
        };

        var faction2 = new Faction
        {
            Id = 2,
            Name = "faction2"
        };

        var unitFaction1 = new UnitFaction
        {
            Id = 1,
            UnitId = 1,
            FactionId = 1
        };

        var unitFaction2 = new UnitFaction
        {
            Id = 2,
            UnitId = 2,
            FactionId = 1
        };

        var unitFaction3 = new UnitFaction
        {
            Id = 3,
            UnitId = 3,
            FactionId = 1
        };

        var compositionUnit1 = new CompositionUnit
        {
            Id = 1,
            UnitId = 1,
            CompositionId = 1
        };

        var compositionUnit2 = new CompositionUnit
        {
            Id = 2,
            UnitId = 2,
            CompositionId = 1
        };

        var compositionUnit3 = new CompositionUnit
        {
            Id = 3,
            UnitId = 3,
            CompositionId = 1
        };

        var compositionUnit4 = new CompositionUnit
        {
            Id = 4,
            UnitId = 3,
            CompositionId = 2
        };

        var compositionUnits1 = new List<CompositionUnit> { compositionUnit1, compositionUnit2, compositionUnit3 };
        var compositionUnits2 = new List<CompositionUnit> { compositionUnit4 };

        var composition1 = new Composition
        {
            Id = 1,
            Name = "composition1",
            BattleType = 1,
            FactionId = 1,
            AvatarId = 1,
            DateCreated = DateTime.MinValue,
            Wins = 1,
            Losses = 1,
            CompositionUnits = compositionUnits1
        };

        var composition2 = new Composition
        {
            Id = 2,
            Name = "composition2",
            BattleType = 1,
            FactionId = 2,
            AvatarId = 2,
            DateCreated = DateTime.MinValue,
            Wins = 2,
            Losses = 2,
            CompositionUnits = compositionUnits2
        };

        var account1 = new Account
        {
            Id = 1,
            Username = "username1",
            Email = "email1@email.com",
            Password = "password1"
        };

        var account2 = new Account
        {
            Id = 2,
            Username = "username2",
            Email = "email2@email.com",
            Password = "password2"
        };

        var account5 = new Account
        {
            Id = 5,
            Username = "username5",
            Email = "email5@email.com",
            Password = "password5"
        };

        var accountComposition1 = new AccountComposition
        {
            Id = 1,
            AccountId = 1,
            CompositionId = 1
        };

        var accountComposition2 = new AccountComposition
        {
            Id = 2,
            AccountId = 2,
            CompositionId = 2
        };

        var accountComposition5 = new AccountComposition
        {
            Id = 5,
            AccountId = 5,
            CompositionId = 5
        };

        var accountCompositions1 = new List<AccountComposition> { accountComposition1 };
        var accountCompositions2 = new List<AccountComposition> { accountComposition2 };
        var accountCompositions5 = new List<AccountComposition> { accountComposition5 };

        database.Accounts.Add(new Account
        {
            Id = account1.Id,
            Username = account1.Username,
            Email = account1.Email,
            Password = account1.Password,
            AccountCompositions = accountCompositions1
        });

        database.Accounts.Add(new Account
        {
            Id = account2.Id,
            Username = account2.Username,
            Email = account2.Email,
            Password = account2.Password,
            AccountCompositions = accountCompositions2
        });

        database.Accounts.Add(new Account
        {
            Id = account5.Id,
            Username = account5.Username,
            Email = account5.Email,
            Password = account5.Password,
            AccountCompositions = accountCompositions5
        });

        database.Compositions.Add(new Composition
        {
            Id = composition1.Id,
            Name = composition1.Name,
            BattleType = composition1.BattleType,
            FactionId = composition1.FactionId,
            AvatarId = composition1.AvatarId,
            DateCreated = composition1.DateCreated,
            Wins = composition1.Wins,
            Losses = composition1.Losses,
            AccountCompositions = accountCompositions1,
            CompositionUnits = compositionUnits1
        });

        database.Compositions.Add(new Composition
        {
            Id = composition2.Id,
            Name = composition2.Name,
            BattleType = composition2.BattleType,
            FactionId = composition2.FactionId,
            AvatarId = composition2.AvatarId,
            DateCreated = composition2.DateCreated,
            Wins = composition2.Wins,
            Losses = composition2.Losses,
            AccountCompositions = accountCompositions2,
            CompositionUnits = compositionUnits2
        });

        database.AccountCompositions.Add(accountComposition1);
        database.AccountCompositions.Add(accountComposition2);

        database.Factions.Add(faction1);
        database.Factions.Add(faction2);

        database.Units.Add(unit1);
        database.Units.Add(unit2);
        database.Units.Add(unit3);

        database.HeroUnits.Add(heroUnit1);
        database.HeroUnits.Add(heroUnit2);

        database.LordUnits.Add(lordUnit1);

        database.UnitFactions.Add(unitFaction1);
        database.UnitFactions.Add(unitFaction2);
        database.UnitFactions.Add(unitFaction3);

        database.CompositionUnits.Add(compositionUnit1);
        database.CompositionUnits.Add(compositionUnit2);
        database.CompositionUnits.Add(compositionUnit3);
        database.CompositionUnits.Add(compositionUnit4);

        database.SaveChanges();
    }
}
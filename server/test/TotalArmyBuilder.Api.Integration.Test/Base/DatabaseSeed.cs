using System.Collections;
using TotalArmyBuilder.Dal.Contexts;
using TotalArmyBuilder.Dal.Models;

namespace TotalArmyBuilder.Api.Integration.Test.Base;

public static class DatabaseSeed
{
    public static void SeedDatabase(TotalArmyContext database)
    {
        Unit unit1 = new Unit
        {
            Id = 1,
            Name = "unit1",
            Cost = 1,
            AvatarId = 1,
        };
        
        Unit unit2 = new Unit
        {
            Id = 2,
            Name = "unit2",
            Cost = 2,
            AvatarId = 2,
        };
        
        Unit unit3 = new Unit
        {
            Id = 3,
            Name = "unit3",
            Cost = 3,
            AvatarId = 3,
        };
        
        LordUnit lordUnit1 = new LordUnit
        {
            Id = 1,
            UnitId = 1
        };
        
        HeroUnit heroUnit1 = new HeroUnit
        {
            Id = 1,
            UnitId = 2
        };
        
        HeroUnit heroUnit2 = new HeroUnit
        {
            Id = 2,
            UnitId = 3
        };

        Faction faction1 = new Faction
        {
            Id = 1,
            Name = "faction",
        };
        
        UnitFaction unitFaction1 = new UnitFaction
        {
            Id = 1,
            UnitId = 1,
            FactionId = 1
        };
        
        UnitFaction unitFaction2 = new UnitFaction
        {
            Id = 2,
            UnitId = 2,
            FactionId = 1
        };
        
        UnitFaction unitFaction3 = new UnitFaction
        {
            Id = 3,
            UnitId = 3,
            FactionId = 1
        };

        CompositionUnit compositionUnit1 = new CompositionUnit
        {
            Id = 1,
            UnitId = 1,
            CompositionId = 1
        };
        
        CompositionUnit compositionUnit2 = new CompositionUnit
        {
            Id = 2,
            UnitId = 2,
            CompositionId = 1
        };
        
        CompositionUnit compositionUnit3 = new CompositionUnit
        {
            Id = 3,
            UnitId = 3,
            CompositionId = 1
        };
        
        var compositionUnits = new List<CompositionUnit> { compositionUnit1, compositionUnit2, compositionUnit3 };

        Composition composition1 = new Composition
        {
            Id = 1,
            Name = "composition",
            BattleType = 1,
            FactionId = 1,
            AvatarId = 1,
            DateCreated = DateTime.MinValue,
            Wins = 1,
            Losses = 1,
            CompositionUnits = compositionUnits
        };

        Account account1 = new Account
        {
            Id = 1,
            Username = "username",
            Email = "email@email.com",
            Password = "password"
        };
        
        AccountComposition accountComposition = new AccountComposition
        {
            Id = 1,
            AccountId = 1,
            CompositionId = 1
        };

        var accountCompositions = new List<AccountComposition> { accountComposition };

        database.Accounts.Add(new Account
        {
            Id = account1.Id,
            Username = account1.Username,
            Email = account1.Email,
            Password = account1.Password,
            AccountCompositions = accountCompositions
        });

        database.Compositions.Add(new Composition
        {
            Id = account1.Id,
            Name = composition1.Name,
            BattleType = composition1.BattleType,
            FactionId = composition1.FactionId,
            AvatarId = composition1.AvatarId,
            DateCreated = composition1.DateCreated,
            Wins = composition1.Wins,
            Losses = composition1.Losses,
            AccountCompositions = accountCompositions,
            CompositionUnits = compositionUnits
        });

        database.AccountCompositions.Add(accountComposition);

        database.Factions.Add(faction1);

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

        database.SaveChanges();
    }
}
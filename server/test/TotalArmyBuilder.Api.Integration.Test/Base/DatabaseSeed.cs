using System.Diagnostics.CodeAnalysis;
using TotalArmyBuilder.Dal.Contexts;
using TotalArmyBuilder.Dal.Models;

namespace TotalArmyBuilder.Api.Integration.Test.Base;
[ExcludeFromCodeCoverage]
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
        
        var compositionUnit5 = new CompositionUnit
        {
            Id = 5,
            UnitId = 3,
            CompositionId = 3
        };

        var compositionUnits1 = new List<CompositionUnit> { compositionUnit1, compositionUnit2, compositionUnit3 };
        var compositionUnits2 = new List<CompositionUnit> { compositionUnit4 };
        var compositionUnits3 = new List<CompositionUnit> { compositionUnit5 };
        var compositionUnits4 = new List<CompositionUnit> {  };
        var compositionUnits5 = new List<CompositionUnit> {  };

        var composition1 = new Composition
        {
            Id = 1,
            Name = "composition1",
            BattleType = "Land Battles",
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
            BattleType = "Land Battles",
            FactionId = 2,
            AvatarId = 2,
            DateCreated = DateTime.MinValue,
            Wins = 2,
            Losses = 2,
            CompositionUnits = compositionUnits2
        };
        
        var composition3 = new Composition
        {
            Id = 3,
            Name = "composition3",
            BattleType = "Land Battles",
            FactionId = 2,
            AvatarId = 3,
            DateCreated = DateTime.MinValue,
            Wins = 3,
            Losses = 3,
            CompositionUnits = compositionUnits3
        };
        
        var composition4 = new Composition
        {
            Id = 4,
            Name = "composition4",
            BattleType = "Land Battles",
            FactionId = 4,
            AvatarId = 4,
            DateCreated = DateTime.MinValue,
            Wins = 4,
            Losses = 4,
            CompositionUnits = compositionUnits4
        };
        
        var composition5 = new Composition
        {
            Id = 5,
            Name = "composition5",
            BattleType = "Land Battles",
            FactionId = 5,
            AvatarId = 5,
            DateCreated = DateTime.MinValue,
            Wins = 5,
            Losses = 5,
            CompositionUnits = compositionUnits5
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
        
        var account3 = new Account
        {
            Id = 3,
            Username = "username3",
            Email = "email3@email.com",
            Password = "password3"
        };
        
        var account4 = new Account
        {
            Id = 4,
            Username = "username4",
            Email = "email4@email.com",
            Password = "password4"
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
        
        var accountComposition3 = new AccountComposition
        {
            Id = 3,
            AccountId = 2,
            CompositionId = 3
        };
        
        var accountComposition4 = new AccountComposition
        {
            Id = 4,
            AccountId = 4,
            CompositionId = 4
        };

        var accountComposition5 = new AccountComposition
        {
            Id = 5,
            AccountId = 4,
            CompositionId = 5
        };

        var accountCompositions1 = new List<AccountComposition> { accountComposition1 };
        var accountCompositions2 = new List<AccountComposition> { accountComposition2 };
        var accountCompositions3 = new List<AccountComposition> { accountComposition3 };
        var accountCompositions4 = new List<AccountComposition> { accountComposition4 };
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
            Id = account3.Id,
            Username = account3.Username,
            Email = account3.Email,
            Password = account3.Password,
            AccountCompositions = null
        });
        
        database.Accounts.Add(new Account
        {
            Id = account4.Id,
            Username = account4.Username,
            Email = account4.Email,
            Password = account4.Password,
            AccountCompositions = accountCompositions4
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
        
        database.Compositions.Add(new Composition
        {
            Id = composition3.Id,
            Name = composition3.Name,
            BattleType = composition3.BattleType,
            FactionId = composition3.FactionId,
            AvatarId = composition3.AvatarId,
            DateCreated = composition3.DateCreated,
            Wins = composition3.Wins,
            Losses = composition3.Losses,
            AccountCompositions = accountCompositions3,
            CompositionUnits = compositionUnits3
        });
        
        database.Compositions.Add(new Composition
        {
            Id = composition4.Id,
            Name = composition4.Name,
            BattleType = composition4.BattleType,
            FactionId = composition4.FactionId,
            AvatarId = composition4.AvatarId,
            DateCreated = composition4.DateCreated,
            Wins = composition4.Wins,
            Losses = composition4.Losses,
            AccountCompositions = accountCompositions4,
            CompositionUnits = compositionUnits4
        });
        
        database.Compositions.Add(new Composition
        {
            Id = composition5.Id,
            Name = composition5.Name,
            BattleType = composition5.BattleType,
            FactionId = composition5.FactionId,
            AvatarId = composition5.AvatarId,
            DateCreated = composition5.DateCreated,
            Wins = composition5.Wins,
            Losses = composition5.Losses,
            AccountCompositions = accountCompositions5,
            CompositionUnits = compositionUnits5
        });

        database.AccountCompositions.Add(accountComposition1);
        database.AccountCompositions.Add(accountComposition2);
        database.AccountCompositions.Add(accountComposition3);
        database.AccountCompositions.Add(accountComposition4);
        database.AccountCompositions.Add(accountComposition5);

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
        database.CompositionUnits.Add(compositionUnit5);

        database.SaveChanges();
    }
}
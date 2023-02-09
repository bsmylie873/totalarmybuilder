using Microsoft.EntityFrameworkCore;
using TotalArmyBuilder.Dal.Interfaces;
using TotalArmyBuilder.Dal.Models;

namespace TotalArmyBuilder.Dal.Contexts;

public class TotalArmyContext : BaseContext, ITotalArmyDatabase
{
    public TotalArmyContext(DbContextOptions option) : base(option)
    {
    }

    public TotalArmyContext(string connectionString) : base(connectionString)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }
    public virtual DbSet<Composition> Compositions { get; set; }
    public virtual DbSet<Faction> Factions { get; set; }
    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<AccountComposition> AccountCompositions { get; set; }
    public virtual DbSet<CompositionUnit> CompositionUnits { get; set; }
    public virtual DbSet<CompositionUnit2> CompositionUnits2 { get; set; }
    public virtual DbSet<HeroUnit> HeroUnits { get; set; }
    public virtual DbSet<LordUnit> LordUnits { get; set; }
    public virtual DbSet<UnitFaction> UnitFactions { get; set; }
}
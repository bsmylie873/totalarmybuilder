using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Npgsql.Replication.PgOutput.Messages;

namespace TotalArmyBuilder.Dal.Models;

[Table("compositions")]
public class Composition
{
    [Key]
    [Column ("id")] public int Id { get; set; }
    
    [Column("name")] public string Name { get; set; }
    
    [Column("battle_type")] public int BattleType { get; set; }
    
    [Column("faction_id")] public int FactionId { get; set; }
    [ForeignKey(nameof(FactionId))] public Faction Faction { get; set; }
    
    [Column("avatar_id")] public int AvatarId { get; set; }
    [ForeignKey(nameof(AvatarId))] public Avatar Avatar { get; set; }
    
    public ICollection<AccountComposition> AccountCompositions { get; set; }
    
    public ICollection<CompositionUnit> CompositionUnits { get; set; }
}
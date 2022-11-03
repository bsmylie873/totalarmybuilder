using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Npgsql.Replication.PgOutput.Messages;

namespace TotalArmyBuilder.Dal.Models;

[Table("compositions")]
public class Composition
{
    [Key]
    [Column ("id")]
    public int Id { get; set; }
    
    [Column("name")]
    public string Name { get; set; }
    
    [Column("battle_type")]
    public string BattleType { get; set; }
    
    [Column("faction_id")]
    public string FactionId { get; set; }
    
    [Column("avatar_id")]
    public string AvatarId { get; set; }
}
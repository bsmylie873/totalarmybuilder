using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Npgsql.Replication.PgOutput.Messages;

namespace TotalArmyBuilder.Dal.Models;
    
[Table("units_factions")]
public class UnitFaction
{
    [Key] [Column ("id")] public int Id { get; set; }
    
    public int UnitId { get; set; }
    [ForeignKey(nameof(UnitId))] public Unit Unit { get; set; }
    
    public int FactionId { get; set; }
    [ForeignKey(nameof(FactionId))] public Faction Faction { get; set; }
    
}
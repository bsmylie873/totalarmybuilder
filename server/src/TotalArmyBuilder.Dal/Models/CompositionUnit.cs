using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Npgsql.Replication.PgOutput.Messages;

namespace TotalArmyBuilder.Dal.Models;
    
[Table("compositions_units")]
public class CompositionUnit
{
    [Key] [Column ("id")] public int Id { get; set; }
    
    public int CompositionId { get; set; }
    [ForeignKey(nameof(CompositionId))] public Composition Composition { get; set; }
    
    public int UnitId { get; set; }
    [ForeignKey(nameof(UnitId))] public Unit Unit { get; set; }
}
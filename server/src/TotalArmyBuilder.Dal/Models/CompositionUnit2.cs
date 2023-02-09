using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TotalArmyBuilder.Dal.Models;

[Table("compositions_units2")]
public class CompositionUnit2
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("composition_id")] public int CompositionId { get; set; }
    [ForeignKey(nameof(CompositionId))] public Composition Composition { get; set; }

    [Column("unit_id")] public int UnitId { get; set; }
    [ForeignKey(nameof(UnitId))] public Unit Unit { get; set; }
}
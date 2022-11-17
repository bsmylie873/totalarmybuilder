using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TotalArmyBuilder.Dal.Models;

[Table("heroes")]
public class HeroUnit
{
    [Key] [Column ("id")] public int Id { get; set; }
    
    [Column ("unit_id")] public int UnitId { get; set; }
    [ForeignKey(nameof(UnitId))] public Unit Unit { get; set; }
}
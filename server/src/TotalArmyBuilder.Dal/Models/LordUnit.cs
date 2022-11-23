using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TotalArmyBuilder.Dal.Models;

[Table("lords")]
public class LordUnit
{
    [Key] [Column ("id")] public int Id { get; set; }
    
    [Column ("unit_id")] public int UnitId { get; set; }
    [ForeignKey(nameof(UnitId))] public Unit Unit { get; set; }
    
    public LordUnit WithUnit(Unit newUnit)
    {
        return new LordUnit(newUnit, this.Unit);
    }
}


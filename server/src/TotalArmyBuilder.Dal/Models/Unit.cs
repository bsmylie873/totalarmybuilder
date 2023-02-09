using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TotalArmyBuilder.Dal.Models;

[Table("units")]
public class Unit
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("name")] public string Name { get; set; }

    [Column("cost")] public int Cost { get; set; }

    [Column("avatar_id")] public int AvatarId { get; set; }
    [ForeignKey(nameof(AvatarId))] public Avatar Avatar { get; set; }

    public ICollection<CompositionUnit> CompositionUnits { get; set; }

    public ICollection<CompositionUnit2> CompositionUnits2 { get; set; }

    public ICollection<UnitFaction> UnitFactions { get; set; }
}
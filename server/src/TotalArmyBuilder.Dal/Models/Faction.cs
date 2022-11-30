using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TotalArmyBuilder.Dal.Models;

[Table("factions")]
public class Faction
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("name")] public string Name { get; set; }

    public ICollection<UnitFaction> UnitFactions { get; set; }
}
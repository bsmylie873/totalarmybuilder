using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Npgsql.Replication.PgOutput.Messages;

namespace TotalArmyBuilder.Dal.Models;

[Table("factions")]
public class Faction
{
    [Key]
    [Column ("id")]
    public int Id { get; set; }
    
    [Column("name")]
    public string Name { get; set; }
}
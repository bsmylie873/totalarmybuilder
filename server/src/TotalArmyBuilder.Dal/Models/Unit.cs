using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Npgsql.Replication.PgOutput.Messages;

namespace TotalArmyBuilder.Dal.Models;
    
[Table("units")]
public class Unit
{
    [Key]
    [Column ("id")]
    public int Id { get; set; }
    
    [Column("name")]
    public string Name { get; set; }
    
    [Column("cost")]
    public int Cost { get; set; }

    [Column("avatar_id")]
    public int AvatarId { get; set; }
}
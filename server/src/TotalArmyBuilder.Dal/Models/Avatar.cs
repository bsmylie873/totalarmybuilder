using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Npgsql.Replication.PgOutput.Messages;

namespace TotalArmyBuilder.Dal.Models;

[Table("avatars")]
public class Avatar
{
    [Key]
    [Column ("id")] public int Id { get; set; }
    
    [Column("url")] public string Url { get; set; }
}
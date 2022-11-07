using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Npgsql.Replication.PgOutput.Messages;

namespace TotalArmyBuilder.Dal.Models;

[Table("accounts")]
public class Account
{
    [Key]
    [Column ("id")] public int Id { get; set; }
    
    [Column("username")] public string Username { get; set; }
    
    [Column("email")] public string Email { get; set; }
    
    [Column("password")] public string Password { get; set; }
    
}
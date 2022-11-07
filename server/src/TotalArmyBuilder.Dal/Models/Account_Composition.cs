using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Npgsql.Replication.PgOutput.Messages;

namespace TotalArmyBuilder.Dal.Models;

[Table("accounts_compositions")]
public class Account_Composition
{
    [Key] [Column ("id")] public int Id { get; set; }
    
    public int AccountId { get; set; }
    [ForeignKey(nameof(AccountId))] public Account Account { get; set; }
    
    public int CompositionId { get; set; }
    [ForeignKey(nameof(CompositionId))] public Composition Composition { get; set; }
}
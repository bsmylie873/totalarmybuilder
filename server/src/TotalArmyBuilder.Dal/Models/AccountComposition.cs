using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TotalArmyBuilder.Dal.Models;

[Table("accounts_compositions")]
public class AccountComposition
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("account_id")] public int AccountId { get; set; }
    [ForeignKey(nameof(AccountId))] public Account Account { get; set; }

    [Column("composition_id")] public int CompositionId { get; set; }
    [ForeignKey(nameof(CompositionId))] public Composition Composition { get; set; }
}
using Microsoft.EntityFrameworkCore;
using TotalArmyBuilder.Dal.Interfaces;
using TotalArmyBuilder.Dal.Models;

namespace TotalArmyBuilder.Dal.Contexts;


public class TotalArmyContext : BaseContext, ITotalArmyDatabase
{
    public TotalArmyContext(DbContextOptions option) : base(option) { }
    public TotalArmyContext(string connectionString) : base(connectionString) { }
    
    public virtual DbSet<Account> Accounts { get; set; }
}
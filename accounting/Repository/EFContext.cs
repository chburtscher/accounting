using accounting.Model;
using Microsoft.EntityFrameworkCore;

namespace accounting.Repository
{
    public class EFContext : DbContext
    {
        public DbSet<CostType> CostTypes {get;set;}

        public DbSet<BankAccount> BankAccounts {get;set;}

        public DbSet<Entries> Entries {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=/home/cbellmann/Accounting.sqlite");
        }
    }
}
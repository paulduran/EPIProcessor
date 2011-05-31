using System.Data.Entity;
using EPIProcessor.Domain;

namespace EPIProcessor
{
    public class EpiRepository : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Adviser> Advisers { get; set; }
        public DbSet<Investment> Investments { get; set; }
        public DbSet<InvestmentBalance> InvestmentBalances { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Entitlement> Entitlements { get; set; }
        public DbSet<AdviserSequence> AdviserSequences { get; set; }
    }
}

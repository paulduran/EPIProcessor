using System;
using System.Linq;
using EPIProcessor.Domain;
using NLog;

namespace EPIProcessor
{
    public class DataPurger
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();
        private readonly EpiRepository repository;

        public DataPurger(EpiRepository repository)
        {
            this.repository = repository;
        }

        public void PurgeForAdviser( string adviserId)
        {
            var adviser = GetAdviser(adviserId);
            if (adviser == null)
            {
                log.Info("no existing adviser data found for id: " + adviserId);
                return;
            }
            log.Debug("purging adviser data for adviser id: " + adviserId);
            DeleteEntitlementsForAdviser(adviser);
            DeleteTransactionsForAdviser(adviser);
            DeleteBalancesForAdviser(adviser);
            DeleteAccountsForAdviser(adviser);
            DeleteAdvisers(adviser);
            repository.SaveChanges();
            log.Debug("done");
        }

        private void DeleteEntitlementsForAdviser(Adviser adviser)
        {
            foreach (var entitlement in repository.Entitlements.Where(x => x.AdviserId == adviser.AdviserId))
            {
                repository.Entitlements.Remove(entitlement);
            }
        }

        private void DeleteAdvisers(Adviser adviser)
        {
            foreach (var a in repository.Advisers.Where(x => x.AdviserId == adviser.AdviserId))
            {
                repository.Advisers.Remove(a);
            }
        }

        private void DeleteAccountsForAdviser(Adviser adviser)
        {
            foreach (var account in repository.Accounts.Where(x => x.Adviser.AdviserId == adviser.AdviserId))
            {
                repository.Accounts.Remove(account);
            }
        }

        private void DeleteBalancesForAdviser(Adviser adviser)
        {
            foreach (var balance in repository.InvestmentBalances.Where(x => x.Adviser.AdviserId == adviser.AdviserId))
            {
                repository.InvestmentBalances.Remove(balance);
            }
        }

        private void DeleteTransactionsForAdviser(Adviser adviser)
        {
            foreach (var transaction in repository.Transactions.Where(x => x.Adviser.AdviserId == adviser.AdviserId))
            {
                repository.Transactions.Remove(transaction);
            }
        }

        private Adviser GetAdviser(string adviserId)
        {
            return repository.Advisers.Find(adviserId);
        }
    }
}
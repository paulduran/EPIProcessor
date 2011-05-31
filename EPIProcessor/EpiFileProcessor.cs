using System;
using System.Collections.Generic;
using System.Data.Entity;
using AutoMapper;
using EPIProcessor.Domain;
using EPIProcessor.Records;
using NLog;

namespace EPIProcessor
{
    public class EpiFileProcessor
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();
        private readonly Func<EpiRepository> repositoryFactory;

        public EpiFileProcessor(Func<EpiRepository> repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;            
        }

        public void ProcessFile(EpiFile file)
        {
            var repository = repositoryFactory();
            var currentTime = DateTime.Now;
            var sequence = repository.AdviserSequences.Find(file.AdviserId);
            if (sequence == null)
            {
                if (!file.Header.Resequence)
                {
                    throw new ApplicationException("Unable to process file as there has not been a 'since inception' file loaded yet for adviser: " + file.AdviserId);
                }
                sequence = new AdviserSequence {AdviserId = file.AdviserId};
                repository.AdviserSequences.Add(sequence);
            }

            if (file.Header.Resequence)
            {
                log.Info("Resequence flag found. Purging existing data");
                new DataPurger(repositoryFactory()).PurgeForAdviser(file.AdviserId);
                sequence.LastReset = currentTime;
            }
            else if(file.Header.SequenceNumber != (sequence.SequenceNumber+1))
            {
                throw new ApplicationException(string.Format("Unable to process file as its sequence number: {0} does not match expected sequence number: {1}", file.Header.SequenceNumber, sequence.SequenceNumber+1));
            }
            ProcessAdvisers(file.AdviserDetails);
            ProcessClients(file.ClientDetails);
            ProcessInvestments(file.InvestmentDetails);
            ProcessStockBalances(file.StockHoldingBalances);
            ProcessCashBalances(file.CashHoldingBalances);
            ProcessStockTransactions(file.StockMovementTransactions);
            ProcessCashTransactions(file.CashMovementTransactions);
            ProcessEntitlements(file.IncomeEntitlements);

            sequence.LastUpdated = currentTime;
            sequence.SequenceNumber = file.Header.SequenceNumber; 
            repository.SaveChanges();
        }
        
        private void ProcessItems<TSource, TDest>(ICollection<TSource> items, Func<TSource, DbSet<TDest>, TDest> findExisting) where TDest : class, new()
        {
            ProcessItems(items, findExisting, shouldDelete=>false);
        }

        private void ProcessItems<TSource, TDest>(ICollection<TSource> items, Func<TSource, DbSet<TDest>, TDest> findExisting, Func<TSource,bool> shouldDelete) where TDest : class, new()
        {
            log.Debug("Processing items of type {0}", typeof(TSource));
            EpiRepository repository = repositoryFactory();
            foreach (var item in items)
            {
                var dbItem = findExisting(item, repository.Set<TDest>());
                if (dbItem == null)
                {
                    dbItem = new TDest();
                    repository.Set<TDest>().Add(dbItem);
                }
                if (shouldDelete(item))
                {
                    repository.Set<TDest>().Remove(dbItem);
                }
                else
                {
                    Mapper.Map(item, dbItem);    
                }                
            }
            repository.SaveChanges();
            log.Debug("{0} items processed", items.Count);
        }

        private void ProcessAdvisers(ICollection<AdviserDetails> adviserDetails)
        {
            ProcessItems<AdviserDetails, Adviser>(adviserDetails, (ad, set)=>set.Find(ad.AdviserId));
        }

        private void ProcessClients(ICollection<ClientDetails> clientDetails)
        {
            ProcessItems<ClientDetails, Account>(clientDetails, (cd, set) => set.Find(cd.AccountId));
        }

        private void ProcessInvestments(ICollection<InvestmentDetails> investmentDetails)
        {
            ProcessItems<InvestmentDetails, Investment>(investmentDetails, (id, set) => set.Find(id.InvestmentCode));
        }

        private void ProcessCashTransactions(ICollection<CashMovementTransaction> cashMovementTransactions)
        {
            ProcessItems<CashMovementTransaction, Transaction>(cashMovementTransactions, (cmt, set) => set.Find(cmt.TransactionId), cmt=>cmt.DeleteTransaction);
        }

        private void ProcessStockTransactions(ICollection<StockMovementTransaction> stockMovementTransactions)
        {
            ProcessItems<StockMovementTransaction, Transaction>(stockMovementTransactions, (smt, set) => set.Find(smt.TransactionId), smt=>smt.DeleteTransaction);
        }

        private void ProcessCashBalances(ICollection<CashHoldingBalance> cashHoldingBalances)
        {
            ProcessItems<CashHoldingBalance, InvestmentBalance>(cashHoldingBalances, (chb, set) => set.Find(chb.Date, chb.AccountId, chb.InvestmentCode));
        }

        private void ProcessStockBalances(ICollection<StockHoldingBalance> stockHoldingBalances)
        {
            ProcessItems<StockHoldingBalance, InvestmentBalance>(stockHoldingBalances, (shb, set) => set.Find(shb.Date, shb.AccountId, shb.InvestmentCode));
        }

        private void ProcessEntitlements(ICollection<IncomeEntitlement> incomeEntitlements)
        {
            ProcessItems<IncomeEntitlement, Entitlement>(incomeEntitlements, (ie, set) => set.Find(ie.TransactionId), ie => ie.DeleteTransaction);
        }
    }
}

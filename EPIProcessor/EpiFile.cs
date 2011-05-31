using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using EPIProcessor.Records;

namespace EPIProcessor
{
    public class EpiFile
    {
        public EpiFile(string fileName, object[]records)
        {
            var match = Regex.Match(fileName, @"(\w+)_(\d{8})_(\w+)_(\d{3})\.csv", RegexOptions.IgnoreCase);
            if (! match.Success)
            {
                throw new ApplicationException(string.Format("Filename: {0} does not match file naming convention: ORG_CCYYMMDD_AdviserID_ZZZ.CSV", fileName));
            }
            AdviserId = match.Groups[3].Value;
            SequenceNumber = Convert.ToInt32(match.Groups[4].Value);

            Header = records[0] as Header;
            if (Header == null)
                throw new ApplicationException("Expect first record to be the header");
            Footer = records[records.Length - 1] as Footer;
            if (Footer == null)
                throw new ApplicationException("Expect last record to be the footer");
            if (records.Length - 2 != Footer.RecordCount)
                throw new ApplicationException(string.Format("Expected {0} records. Found {1}", Footer.RecordCount, records.Length - 2));

            AdviserDetails = (from r in records where r.GetType() == typeof (AdviserDetails) select r).Cast<AdviserDetails>().ToList();
            ClientDetails = (from r in records where r.GetType() == typeof(ClientDetails) select r).Cast<ClientDetails>().ToList();
            InvestmentDetails = (from r in records where r.GetType() == typeof(InvestmentDetails) select r).Cast<InvestmentDetails>().ToList();
            CashMovementTransactions = (from r in records where r.GetType() == typeof(CashMovementTransaction) select r).Cast<CashMovementTransaction>().ToList();
            CashHoldingBalances = (from r in records where r.GetType() == typeof(CashHoldingBalance) select r).Cast<CashHoldingBalance>().ToList();
            StockMovementTransactions = (from r in records where r.GetType() == typeof(StockMovementTransaction) select r).Cast<StockMovementTransaction>().ToList();
            StockHoldingBalances = (from r in records where r.GetType() == typeof(StockHoldingBalance) select r).Cast<StockHoldingBalance>().ToList();
            IncomeEntitlements = (from r in records where r.GetType() == typeof(IncomeEntitlement) select r).Cast<IncomeEntitlement>().ToList();
        }

        public Header Header { get; set; }
        public Footer Footer { get; set; }
        public string AdviserId { get; set; }
        public int SequenceNumber { get; set; }
        public ICollection<AdviserDetails> AdviserDetails { get; set; }
        public ICollection<ClientDetails> ClientDetails { get; set; }
        public ICollection<InvestmentDetails> InvestmentDetails { get; set; }
        public ICollection<CashMovementTransaction> CashMovementTransactions { get; set; }
        public ICollection<CashHoldingBalance> CashHoldingBalances { get; set; }
        public ICollection<StockMovementTransaction> StockMovementTransactions { get; set; }
        public ICollection<StockHoldingBalance> StockHoldingBalances { get; set; }
        public ICollection<IncomeEntitlement> IncomeEntitlements{ get; set; }
    }
}

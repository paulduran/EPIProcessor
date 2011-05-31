using System;
using System.ComponentModel.DataAnnotations;

namespace EPIProcessor.Domain
{
    public class Transaction
    {
        private string reversalOfTransactionId;

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string TransactionId { get; set; }
        public string AccountId { get; set; }
        public Account Account { get; set; }
        public string HoldingId { get; set; } // HIN
        public string InvestmentCode { get; set; }
//        public Investment Investment { get; set; }
        public string TransactionType { get; set; }
        public string TransactionNarrative { get; set; }
        public DateTime TradeDate { get; set; }
        public decimal Quantity { get; set; }
        public decimal NetValue { get; set; }
        public decimal GrossValue { get; set; }
        public decimal CostBase { get; set; }
        public string TransactionStatus { get; set; }
        public DateTime SettlementDate { get; set; }
        public decimal? StampDuty { get; set; }
        public decimal? ClientFees { get; set; }
        public decimal? FeeRebates { get; set; }
        public decimal? OtherFees { get; set; }
        public string PlatformOrderId { get; set; }
        public decimal? OutstandingOrderAmount { get; set; }

        [ForeignKey("ReversalOfTransaction")]
        public string ReversalOfTransactionId { get { return reversalOfTransactionId; } set { if (string.IsNullOrEmpty(value)) reversalOfTransactionId = null; else reversalOfTransactionId = value; } }       
        public Transaction ReversalOfTransaction { get; set; }
        public string AdviserId { get; set; }
        public Adviser Adviser { get; set; }
    }
}

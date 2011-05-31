using System;
using System.ComponentModel.DataAnnotations;

namespace EPIProcessor.Domain
{
    public class Entitlement
    {
        private string reversalOfEntitlementId;
        private string linkedToTransactionId;

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string EntitlementId { get; set; }
        public string AccountId { get; set; }
        public Account Account { get; set; }

        public string VendorId { get; set; }
        public string HoldingId { get; set; }
        public string InvestmentCode { get; set; }
//        public Investment Investment { get; set; }
        public string IncomeType { get; set; }
        public string TransactionNarrative { get; set; }
        public decimal GrossEntitlement { get; set; }
        public DateTime AccrualDate { get; set; }
        public DateTime PayDate { get; set; }
        public decimal? OtherIncome { get; set; }
        public decimal? FrankedAmount { get; set; }
        public decimal? UnfrankedAmount { get; set; }
        public decimal? ImputationCredit { get; set; }
        public decimal? RealisedCapitalGain { get; set; }
        public decimal? ForeignInterest { get; set; }
        public decimal? ForeignCapitalGains { get; set; }
        public decimal? ForeignInvestmentFunds { get; set; }
        public decimal? PropertyIncomeTaxFree { get; set; }
        public decimal? PropertyIncomeTaxDeferred { get; set; }
        public decimal? ReturnOfCapital { get; set; }
        public decimal? ForeignTaxCredits { get; set; }
        public decimal? ForeignWithholdingTax { get; set; }
        public decimal? DomesticWithholdingTax { get; set; }
        [ForeignKey("LinkedToTransaction")]
        public string LinkedToTransactionId { get { return linkedToTransactionId; } set { if (string.IsNullOrEmpty(value)) linkedToTransactionId = null; else linkedToTransactionId = value; } }
        public Transaction LinkedToTransaction { get; set; }
        [ForeignKey("ReversalOfEntitlement")]
        public string ReversalOfEntitlementId { get { return reversalOfEntitlementId; } set { if (string.IsNullOrEmpty(value)) reversalOfEntitlementId = null; else reversalOfEntitlementId = value; } }
        public Entitlement ReversalOfEntitlement { get; set; }
        public string AdviserId { get; set; }
        public Adviser Adviser { get; set; }
    }
}

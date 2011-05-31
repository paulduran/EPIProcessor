using System;
using FileHelpers;

namespace EPIProcessor.Records
{
    public class IncomeEntitlement : Record
    {
        [FieldQuoted] public string VendorId;
        [FieldQuoted] public string TransactionId;
        [FieldQuoted] public string AccountId;
        [FieldQuoted] public string HoldingId;
        [FieldQuoted] public string InvestmentCode;
        [FieldQuoted] public string IncomeType;
        [FieldQuoted] public string TransactionNarrative;
        public decimal GrossEntitlement;
        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")] public DateTime AccrualDate;
        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")] public DateTime PayDate;
        public decimal? OtherIncome;
        public decimal? FrankedAmount;
        public decimal? UnfrankedAmount;
        public decimal? ImputationCredit;
        public decimal? RealisedCapitalGain;
        public decimal? ForeignInterest;
        public decimal? ForeignCapitalGains;
        public decimal? ForeignInvestmentFunds;
        public decimal? PropertyIncomeTaxFree;
        public decimal? PropertyIncomeTaxDeferred;
        public decimal? ReturnOfCapital;
        public decimal? ForeignTaxCredits;
        public decimal? ForeignWithholdingTax;
        public decimal? DomesticWithholdingTax;
        [FieldQuoted] public string LinkedToTransactionId;
        [FieldQuoted] public string ReversalOfTransactionId;
        [FieldQuoted] [FieldConverter(ConverterKind.Boolean, "T", "F")] public bool DeleteTransaction;
        [FieldQuoted] public string AdviserId;
    }
}
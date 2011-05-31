using System;
using FileHelpers;

namespace EPIProcessor.Records
{
    public class StockMovementTransaction : Record
    {
        [FieldQuoted] public string VendorId;
        [FieldQuoted] public string TransactionId;
        [FieldQuoted] public string AccountId;
        [FieldQuoted] public string HoldingId; // HIN
        [FieldQuoted] public string InvestmentCode;
        [FieldQuoted] public string TransactionType;
        [FieldQuoted] public string TransactionNarrative;
        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")] public DateTime TradeDate;
        public decimal Quantity;
        public decimal NetValue;
        public decimal GrossValue;
        public decimal CostBase;
        [FieldQuoted] public string TransactionStatus;
        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")] public DateTime SettlementDate;
        public decimal? StampDuty;
        public decimal? ClientFees;
        public decimal? FeeRebates;
        public decimal? OtherFees;
        [FieldQuoted] public string ReversalOfTransactionId;
        [FieldQuoted] public string PlatformOrderId;
        public decimal? OutstandingOrderAmount;
        [FieldQuoted] [FieldConverter(ConverterKind.Boolean, "T", "F")] public bool DeleteTransaction;
        [FieldQuoted] public string AdviserId;
    }
}
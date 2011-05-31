using System;
using FileHelpers;

namespace EPIProcessor.Records
{
    public class CashMovementTransaction : Record
    {
        [FieldQuoted] public string VendorId;
        [FieldQuoted] public string TransactionId;
        [FieldQuoted] public string AccountId;
        [FieldQuoted] public string TransactionType;
        [FieldQuoted] public string TransactionNarrative;
        [FieldQuoted] public string InvestmentCode;
        public decimal Amount;
        [FieldQuoted] public string TransactionStatus;
        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")] public DateTime TransactionDate;
        [FieldQuoted] public string LinkedToTransactionId;
        [FieldQuoted] public string ReversalOfTransactionId;
        [FieldQuoted] [FieldConverter(ConverterKind.Boolean, "T", "F")] public bool DeleteTransaction;
        [FieldQuoted] public string AdviserId;
    }
}
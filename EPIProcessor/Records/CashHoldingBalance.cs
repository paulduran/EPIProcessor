using System;
using FileHelpers;

namespace EPIProcessor.Records
{
    public class CashHoldingBalance : Record
    {
        [FieldQuoted] public string VendorId;
        [FieldQuoted] public string AccountId;
        [FieldQuoted] public string InvestmentCode;
        public decimal ActualUnitBalance;
        public decimal UnconfirmedUnitBalance;
        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")] public DateTime Date;
        [FieldQuoted] public string AdviserId;
    }
}
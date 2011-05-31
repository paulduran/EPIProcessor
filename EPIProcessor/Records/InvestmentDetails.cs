using System;
using FileHelpers;

namespace EPIProcessor.Records
{
    public class InvestmentDetails : Record
    {
        [FieldQuoted] public string VendorId;
        [FieldQuoted] public string InvestmentCode;
        [FieldQuoted] public string InvestmentName;
        [FieldQuoted] public string InvestmentType;
        [FieldQuoted] public string PlatformContactName;
        [FieldQuoted] public string PlatformContactNumber;
        [FieldQuoted] [FieldConverter(ConverterKind.Boolean, "T", "F")] public bool? UnitLinked;

        public decimal? AssetAllocationCash;
        public decimal? AssetAllocationAustShares;
        public decimal? AssetAllocationIntShares;
        public decimal? AssetAllocationAustFixedInterest;
        public decimal? AssetAllocationIntFixedInterest;
        public decimal? AssetAllocationAustProperty;
        public decimal? AssetAllocationIntProperty;
        public decimal? AssetAllocationDirectProperty;
        public decimal? AssetAllocationOther;
        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")] public DateTime? AssetAllocationDate;

        public decimal? EntryFee;
        public decimal? BrokerageUpfront;
        public decimal? BrokerageOngoing;
        public decimal? Price;
        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")] public DateTime? PriceDate;
    }
}
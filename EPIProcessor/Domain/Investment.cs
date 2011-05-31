using System;
using System.ComponentModel.DataAnnotations;

namespace EPIProcessor.Domain
{
    public class Investment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string InvestmentCode { get; set; }
        public string VendorId { get; set; }        
        public string InvestmentName { get; set; }
        public string InvestmentType { get; set; }
        public string PlatformContactName { get; set; }
        public string PlatformContactNumber { get; set; }
        public bool? UnitLinked { get; set; }

        public decimal? AssetAllocationCash { get; set; }
        public decimal? AssetAllocationAustShares { get; set; }
        public decimal? AssetAllocationIntShares { get; set; }
        public decimal? AssetAllocationAustFixedInterest { get; set; }
        public decimal? AssetAllocationIntFixedInterest { get; set; }
        public decimal? AssetAllocationAustProperty { get; set; }
        public decimal? AssetAllocationIntProperty { get; set; }
        public decimal? AssetAllocationDirectProperty { get; set; }
        public decimal? AssetAllocationOther { get; set; }
        public DateTime? AssetAllocationDate { get; set; }

        public decimal? EntryFee { get; set; }
        public decimal? BrokerageUpfront { get; set; }
        public decimal? BrokerageOngoing { get; set; }
        public decimal? Price { get; set; }
        public DateTime? PriceDate { get; set; }
    }
}

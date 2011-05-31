using System;
using System.ComponentModel.DataAnnotations;

namespace EPIProcessor.Domain
{
    public class InvestmentBalance
    {
        [Key]
        [Column(Order = 0)]
        public DateTime Date { get; set; }

        [Key]
        [Column(Order = 1)]
        public string AccountId { get; set; }
        public Account Account { get; set; }

        [Key]
        [Column(Order = 2)]
        public string InvestmentCode { get; set; }

        public string AdviserId { get; set; }
        public Adviser Adviser { get; set; }
        public string HoldingId { get; set; }
        public decimal ActualUnitBalance { get; set; }
        public decimal UnconfirmedUnitBalance { get; set; }
    }
}
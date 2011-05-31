using System;
using System.ComponentModel.DataAnnotations;

namespace EPIProcessor.Domain
{
    public class AdviserSequence
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string AdviserId { get; set; }
        public int SequenceNumber { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime LastReset { get; set; } 
    }
}

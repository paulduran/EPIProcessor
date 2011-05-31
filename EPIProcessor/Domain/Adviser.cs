using System.ComponentModel.DataAnnotations;

namespace EPIProcessor.Domain
{
    public class Adviser
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string AdviserId { get; set; }
        public string VendorId { get; set; }
        public string PlatformAdviserId { get; set; }
        public string BusinessName { get; set; }
        public string BranchName { get; set; }
        public string AdviserLastName { get; set; }
        public string AdviserFirstName { get; set; }
        public string AdviserTitle { get; set; }
        public Gender AdviserGender { get; set; }
        public string AddressType { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string PreferredPhoneType { get; set; }
        public string HomePhone { get; set; }
        public string BusinessPhone { get; set; }
        public string MobilePhone { get; set; }
        public string Fax { get; set; }
        public string EmailAddressType { get; set; }
        public string EmailAddress { get; set; }
    }
}
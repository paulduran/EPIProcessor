using System;
using System.ComponentModel.DataAnnotations;

namespace EPIProcessor.Domain
{
    public class Account
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string AccountId { get; set; }
        public string AdviserId { get; set; }
        public Adviser Adviser { get; set; }
        public string VendorId { get; set; }
        public string ClientId { get; set; }
        public string PlatformClientId { get; set; }
        public string PlatformAccountId { get; set; }
        public string ProductCode { get; set; }
        public string AccountName { get; set; }
        public string AccountShortName { get; set; }
        public string FullName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
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
        public string Abn { get; set; }
        public bool? Smoker { get; set; }
    }
}

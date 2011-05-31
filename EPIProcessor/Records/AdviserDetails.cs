using FileHelpers;
using EPIProcessor.Domain;

namespace EPIProcessor.Records
{
    public class AdviserDetails : Record
    {
        [FieldQuoted] public string VendorId;
        [FieldQuoted] public string AdviserId;
        [FieldQuoted] public string PlatformAdviserId;
        [FieldQuoted] public string BusinessName;
        [FieldQuoted] public string BranchName;
        [FieldQuoted] public string AdviserLastName;
        [FieldQuoted] public string AdviserFirstName;
        [FieldQuoted] public string AdviserTitle;
        [FieldQuoted] public Gender AdviserGender;
        [FieldQuoted] public string AddressType;
        [FieldQuoted] public string AddressLine1;
        [FieldQuoted] public string AddressLine2;
        [FieldQuoted] public string AddressLine3;
        [FieldQuoted] public string Suburb;
        [FieldQuoted] public string State;
        [FieldQuoted] public string PostCode;
        [FieldQuoted] public string Country;
        [FieldQuoted] public string PreferredPhoneType;
        [FieldQuoted] public string HomePhone;
        [FieldQuoted] public string BusinessPhone;
        [FieldQuoted] public string MobilePhone;
        [FieldQuoted] public string Fax;
        [FieldQuoted] public string EmailAddressType;
        [FieldQuoted] public string EmailAddress;
    }
}
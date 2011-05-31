using System;
using FileHelpers;
using EPIProcessor.Domain;

namespace EPIProcessor.Records
{
    public class ClientDetails : Record
    {
        [FieldQuoted] public string VendorId;
        [FieldQuoted] public string ClientId;
        [FieldQuoted] public string AccountId;
        [FieldQuoted] public string PlatformClientId;
        [FieldQuoted] public string PlatformAccountId;
        [FieldQuoted] public string ProductCode;
        [FieldQuoted] public string AccountName;
        [FieldQuoted] public string AccountShortName;
        [FieldQuoted] public string FullName;
        [FieldQuoted] public string LastName;
        [FieldQuoted] public string FirstName;
        [FieldQuoted] public string Title;
        [FieldQuoted] public Gender Gender;
        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")] public DateTime DateOfBirth;
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
        [FieldQuoted] public string Abn;
        [FieldQuoted] [FieldConverter(ConverterKind.Boolean, "T", "F")] public bool? Smoker;
        [FieldQuoted] public string AdviserId;
    }
}
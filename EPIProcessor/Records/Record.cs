using FileHelpers;

namespace EPIProcessor.Records
{
    [DelimitedRecord(",")]
    public class Record
    {
        [FieldQuoted] public string RecordType;
        [FieldQuoted] public string VersionNumber;
    }
}
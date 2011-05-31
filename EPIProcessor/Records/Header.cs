using System;
using FileHelpers;

namespace EPIProcessor.Records
{
    public class Header : Record
    {
        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")] public DateTime FileDate;
        public int SequenceNumber;
        [FieldQuoted] [FieldConverter(ConverterKind.Boolean, "T", "F")] public bool Resequence;
    }
}
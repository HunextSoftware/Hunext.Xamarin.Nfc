using System;
namespace Hunext.Xamarin.Nfc
{
    public class NfcRecord
    {
        public TagRecType TypeNameFormat { get; set; }
        public byte[] Payload { get; set; }
    }
}

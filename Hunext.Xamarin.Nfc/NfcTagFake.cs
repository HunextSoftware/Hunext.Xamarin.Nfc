using System;
using System.Collections.Generic;
using System.Text;

namespace Hunext.Xamarin.Nfc
{
    public class NfcTagFake : INfcTag
    {
        public static NfcTagFake RandomTextRecord()
        {
            return new NfcTagFake(new NfcRecord[] { new NfcRecord() { TypeNameFormat = TagRecType.Empty, Payload = Encoding.UTF8.GetBytes("   " + System.Guid.NewGuid().ToString()) } });
        }

        public static NfcTagFake SingleTextRecord(string text)
        {
            return new NfcTagFake(new NfcRecord[] { new NfcRecord() { TypeNameFormat = TagRecType.Empty, Payload = Encoding.UTF8.GetBytes("   " + text) } });
        }

        public static NfcTagFake MultipleTextRecord(string[] textList)
        {
            var records = new List<NfcRecord>();

            foreach (var text in textList)
            {
                var rec = new NfcRecord() { TypeNameFormat = TagRecType.Empty, Payload = Encoding.UTF8.GetBytes("   " + text) };
                records.Add(rec);
            }

            return new NfcTagFake(records.ToArray());
        }

        public NfcTagFake(NfcRecord[] recData)
        {
            Records = recData;
        }

        public NfcRecord[] Records { get; }
    }
}

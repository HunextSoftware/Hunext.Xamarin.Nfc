using System;
using System.Text;

namespace Hunext.Xamarin.Nfc
{
    public class NfcTagFake : INfcTag
    {
        private string _recData;

        public NfcTagFake()
        {
            _recData = System.Guid.NewGuid().ToString();
        }
        public NfcTagFake(string recData)
        {
            _recData = recData;
        }
        public bool IsWriteable => true;

        public NfcRecord[] Records
        {
            get
            {
                return new NfcRecord[] {
                                            new NfcRecord() {
                                                                TypeNameFormat = TagRecType.Empty,
                                                                Payload =  Encoding.UTF8.GetBytes("   " + _recData) }
                                                                };
            }
        }
    }

}

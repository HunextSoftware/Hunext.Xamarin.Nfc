using System;
namespace Hunext.Xamarin.Nfc
{
    public class NfcReaderFakeFactory : NfcReaderFactory
    {
        private int _timeout;
        private string _tagdata;

        public NfcReaderFakeFactory()
        {
            _timeout = 2000;
        }

        public NfcReaderFakeFactory(int timeout, string tagdata)
        {
            _timeout = timeout;
            _tagdata = tagdata;
        }

        public override INfcReader Create()
        {
            if (_tagdata ==null) return new NfcReadeFake(_timeout);
            else return new NfcReadeFake(_timeout,_tagdata);

        }
    }
}

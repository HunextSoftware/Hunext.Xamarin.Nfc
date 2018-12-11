using System;
namespace Hunext.Xamarin.Nfc
{
    public class NfcReaderFakeFactory : NfcReaderFactory
    {
        private int _delay;
        private NfcTagFake _tag;

        public NfcReaderFakeFactory()
        {
            _delay = 2000;
        }

        public NfcReaderFakeFactory(int timeout, NfcTagFake tag)
        {
            _delay = timeout;
            _tag = tag;
        }

        public override INfcReader Create()
        {
            if (_tag ==null) return new NfcReadeFake(_delay);
            else return new NfcReadeFake(_delay,_tag);

        }
    }
}

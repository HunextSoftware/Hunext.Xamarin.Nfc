using System;

namespace Hunext.Xamarin.Nfc.iOS
{

    public class NfciOSFactory : NfcReaderFactory
    {
        public override INfcReader Create()
        {
            return new NfcReaderiOS();
        }
    }


}

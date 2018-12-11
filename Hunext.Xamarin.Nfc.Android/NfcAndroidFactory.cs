using System;
using Android.App;
using Android.Content;


namespace Hunext.Xamarin.Nfc.Android
{

    public class NfcReaderAndroidFactory : NfcReaderFactory
    {
        public override INfcReader Create()
        {
            return new NfcReaderAndroid();
        }
    }

}
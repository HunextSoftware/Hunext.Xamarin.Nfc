

using System;
using System.Threading;

namespace Hunext.Xamarin.Nfc
{

    public static class NfcReader{

        private static Lazy<INfcReader> _implementation = new Lazy<INfcReader>(CreateNfcReader, LazyThreadSafetyMode.PublicationOnly);

        private static INfcReader CreateNfcReader()
        {
            return Defaultfactory.Create();
        }

        public static INfcReader Current => _implementation.Value;

        public static NfcReaderFactory Defaultfactory { get; set; }

        public static void Dispose()
        {
            if (_implementation != null && _implementation.IsValueCreated)
            {
                _implementation = new Lazy<INfcReader>(CreateNfcReader, LazyThreadSafetyMode.PublicationOnly);
            }
        }

    }

    public abstract class NfcReaderFactory
    {

        public abstract INfcReader Create();


    }

}

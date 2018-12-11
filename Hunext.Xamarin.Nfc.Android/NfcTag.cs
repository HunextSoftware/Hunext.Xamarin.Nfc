using System;
using System.Collections.Generic;
using System.Linq;
using Android.Nfc;
using Android.Nfc.Tech;

namespace Hunext.Xamarin.Nfc.Android
{
    public class NfcTag : INfcTag
    {
        public NfcRecord[] Records { get; }

        public NfcTag(Ndef tag, IEnumerable<NdefRecord> rcs)
        {
            Records = rcs.Select(r => new AndroidNfcRecord(r)).ToArray();
        }
    }
}

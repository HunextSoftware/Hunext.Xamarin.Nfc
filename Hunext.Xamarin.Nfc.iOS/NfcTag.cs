using System;
using System.Collections.Generic;
using System.Linq;
using CoreNFC;

namespace Hunext.Xamarin.Nfc.iOS
{
    public class NfcTag : INfcTag
    {
        public NfcRecord[] Records { get; }

        public NfcTag(NFCNdefMessage tag, IEnumerable<NFCNdefPayload> rcs)
        {
            Records = rcs.Select(r => new IOSNfcRecord(r)).ToArray();
        }
    }
}

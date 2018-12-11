using System;
using Android.Nfc;

namespace Hunext.Xamarin.Nfc.Android
{
    public class AndroidNfcRecord : NfcRecord
    {
        public AndroidNfcRecord(NdefRecord nativeRecord)
        {
            TypeNameFormat = GetRecordFormat(nativeRecord.Tnf);
            Payload = nativeRecord.GetPayload();
        }

        private TagRecType GetRecordFormat(short nativeRecord)
        {
            switch (nativeRecord)
            {
                case NdefRecord.TnfAbsoluteUri:
                    return TagRecType.AbsoluteUri;
                case NdefRecord.TnfEmpty:
                    return TagRecType.Empty;
                case NdefRecord.TnfExternalType:
                    return TagRecType.External;
                case NdefRecord.TnfMimeMedia:
                    return TagRecType.Media;
                case NdefRecord.TnfUnchanged:
                    return TagRecType.Unchanged;
                case NdefRecord.TnfUnknown:
                    return TagRecType.Unchanged;
                case NdefRecord.TnfWellKnown:
                    return TagRecType.WellKnown;
            }

            return TagRecType.Unknown;
        }
    }
}

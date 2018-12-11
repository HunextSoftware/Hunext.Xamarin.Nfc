using System;
using CoreNFC;

namespace Hunext.Xamarin.Nfc.iOS
{
    public class IOSNfcRecord : NfcRecord
    {
        public IOSNfcRecord(NFCNdefPayload nativeRecord)
        {
            TypeNameFormat = GetTypeFormat(nativeRecord.TypeNameFormat);
            Payload = nativeRecord.Payload.ToArray();
        }

        private TagRecType GetTypeFormat(NFCTypeNameFormat nativeRecordTnf)
        {
            switch (nativeRecordTnf)
            {
                case NFCTypeNameFormat.AbsoluteUri:
                    return TagRecType.AbsoluteUri;
                case NFCTypeNameFormat.Empty:
                    return TagRecType.Empty;
                case NFCTypeNameFormat.NFCExternal:
                    return TagRecType.External;
                case NFCTypeNameFormat.Media:
                    return TagRecType.Media;
                case NFCTypeNameFormat.Unchanged:
                    return TagRecType.Unchanged;
                case NFCTypeNameFormat.Unknown:
                    return TagRecType.Unknown;
                case NFCTypeNameFormat.NFCWellKnown:
                    return TagRecType.WellKnown;
            }
            return TagRecType.Unknown;

        }
    }
}
